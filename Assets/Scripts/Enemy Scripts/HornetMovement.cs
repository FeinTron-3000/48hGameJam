using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;

    public float movespeed;
    public float agrivationrange;

    [Header("Attacking")]
    public float attacktime;
    public float attackdelaytime;
    public float cooldowntime;

    public bool attacking;
    // only start attack script once
    private bool attackingstarted;

    public GameObject attackpoint;

    [Header("Player")]
    public GameObject player;

    [Header("Scripts")]
    public EnemyHealth health;
    public HornetAttack attack;

    [Header("Audio")]
    public AudioSource hornetbuzz;
    public AudioSource attacksound;

    [Header("Animator")]
    public Animator animator;


    void Start()
    {
        health = health.GetComponent<EnemyHealth>();
        attack = attack.GetComponent<HornetAttack>();
    }

    void Update()
    {
        // dont move if player is dead
        if (player == null)
        {
            rb.velocity = Vector3.zero;

            return;
        }

        // if player is within range left
        if (player.transform.position.x > transform.position.x - agrivationrange && !attackingstarted)
        {
            attack.agrivated = true;

            attackingstarted = true;
            StartCoroutine(CoolDown());
        }

        // dont move if enemy is dead
        if (health.isdead)
        {
            rb.velocity = Vector3.zero;

            return;
        }

        if (attack.agrivated == true)
        {
            // move right
            if (player.transform.position.x > transform.position.x)
            {
                // flip direction facing
                transform.localScale = new Vector3(-4, 4, 1);

                transform.Translate(Vector2.right * movespeed * Time.deltaTime);
            }
            // move left
            else
            {
                // flip direction facing
                transform.localScale = new Vector3(4, 4, 1);

                transform.Translate(Vector2.left * movespeed * Time.deltaTime);
            }
        }
    }

    public void Attack()
    {
        // dont attack if dead
        if (health.isdead)
        {
            return;
        }
        // dont attack if player is dead
        if (player == null)
        {
            animator.SetBool("Walk", false);
            return;
        }

        animator.SetBool("Attack", true);
        attacking = true;
        attacksound.Play();

        StartCoroutine(AttackDelay());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);

        // stop attack
        attackpoint.SetActive(false);
        attacking = false;

        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldowntime);

        Attack();
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackdelaytime);

        // attack
        attackpoint.SetActive(true);
        attack.BecomeVisible();

        animator.SetBool("Attack", false);

        StartCoroutine(WeaponReturn());
    }
}

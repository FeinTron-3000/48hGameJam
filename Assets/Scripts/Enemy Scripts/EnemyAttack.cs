using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Variables")]
    public float attacktime;
    public float attackdelaytime;
    public float cooldowntime;

    public bool attacking;
    public int damage;

    // only start attack script once
    private bool attackingstarted;

    public BoxCollider2D attackpoint;

    [Header("Scripts")]
    public EnemyHealth health;
    public PlayerHealth playerhealth;

    [Header("Player")]
    public GameObject player;

    [Header("Audio")]
    public AudioSource attacksound;

    [Header("Animator")]
    public Animator animator;

    private void Start()
    {
        health = health.GetComponent<EnemyHealth>();

        playerhealth = playerhealth.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // start attacking
        if (health.agrivated && !attackingstarted)
        {
            attackingstarted = true;
            StartCoroutine(CoolDown());
        }
    }

    // do damage on hit
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealth.TakeDamage(damage);

            // give player knockback
            if (collision.transform.position.x < transform.position.x)
            {
                // direction right
                playerhealth.AttackKnockback(-1);
            }
            else
            {
                // direction left
                playerhealth.AttackKnockback(1);
            }

            // don't let the player get hit twice
            attackpoint.enabled = false;
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
        animator.SetBool("Attack", false);
        attackpoint.enabled = false;
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

        // stupid plant code
        if (health.plant)
        {
            transform.position = transform.position + new Vector3(0.01f, 0, 0);
        }

        // attack
        attackpoint.enabled = true;

        StartCoroutine(WeaponReturn());
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisAttack : MonoBehaviour
{
    [Header("Variables")]
    public float attacktime;
    public float attackdelaytime;
    public float cooldowntime;

    public bool attacking;
    public int damage;
    private bool attackingstarted;

    public BoxCollider2D attackpoint;

    [Header("Scripts")]
    public EnemyHealth health;

    public PlayerHealth playerhealth;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // damage player
            if (attacking)
            {
                playerhealth.TakeDamage(damage);
            }
        }
    }

    public void Attack()
    {
        // dont move if attack
        if (health.isdead)
        {
            return;
        }

        attacksound.Play();

        animator.SetBool("Attack", true);
        attackpoint.enabled = true;
        attacking = true;

        StartCoroutine(AttackDelay());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);

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

        StartCoroutine(WeaponReturn());
    }
}
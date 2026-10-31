using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Variables")]
    public float attacktime;
    public float attackdelaytime;
    public bool attacking;

    public BoxCollider2D attackpoint;

    [Header("Scripts")]
    public PlayerHealth playerhealth;
    public PlayerScript playerscript;
    public EnemyHealth enemyhealth;

    [Header("Audio")]
    public AudioSource swordsound;

    [Header("Animator")]
    public Animator animator;

    private void Start()
    {
        playerhealth = playerhealth.GetComponent<PlayerHealth>();
        playerscript = playerscript.GetComponent<PlayerScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (attacking)
            {
                // damage enemy
                enemyhealth = collision.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(playerscript.damage);
            }
        }
    }

    public void Attack()
    {
        // do not play if already attacking
        if (attacking)
        {
            return;
        }

        swordsound.Play();
        animator.SetBool("Attack", true);
        attackpoint.enabled = true;
        attacking = true;
        StartCoroutine(AttackDelay());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);

        animator.SetBool("Attack", false);
        attacking = false;
        attackpoint.enabled = false;
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackdelaytime);

        StartCoroutine(WeaponReturn());
    }
}

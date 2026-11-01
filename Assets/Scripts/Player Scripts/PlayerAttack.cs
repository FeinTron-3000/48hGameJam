using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Variables")]
    public float attacktime;
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
            enemyhealth = collision.GetComponent<EnemyHealth>();
            enemyhealth.TakeDamage(playerscript.damage);

            // dont do damage twice
            attackpoint.enabled = false;
        }
    }

    public void Attack()
    {
        // do not play if already attacking
        if (attacking)
        {
            return;
        }

        // stupid plant code
        transform.position = transform.position + new Vector3(0.01f, 0, 0);

        swordsound.Play();
        animator.SetBool("Attack", true);
        attackpoint.enabled = true;
        attacking = true;
        StartCoroutine(WeaponReturn());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);

        animator.SetBool("Attack", false);
        attacking = false;
        attackpoint.enabled = false;
    }
}

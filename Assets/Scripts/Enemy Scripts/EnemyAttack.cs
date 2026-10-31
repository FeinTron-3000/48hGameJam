using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public float weaponRage;
    public LayerMask enemyLayer;
    public int damnage = 1;
    public float attacktime;
    public float cooldowntime;

    public GameObject player;

    public EnemyHealth enemyhealth;
    public PlayerHealth playerHealth;
    public bool isenemy;
    public bool enemyattack;
    public bool attacking;

    public float attackdelay;

    public bool mantis;
    public bool plant;
    public float growspeed;
    public bool plantattackstart;

    public AudioSource mantisattack;

    [SerializeField] private Animator animator;

    private void Start()
    {
        playerHealth = playerHealth.GetComponent<PlayerHealth>();
        if (plant)
        {
            StartCoroutine(CoolDown());
        }
    }
    public void Agrivated()
    {
        StartCoroutine(CoolDown());
    }
    private void Update()
    {
        if (mantis)
        {
            if (isenemy && enemyhealth.agrivated == true)
            {
                if (!enemyattack)
                {

                    animator.SetBool("Attack", false);
                    transform.position = player.transform.position;
                }
                else
                {

                    transform.position = player.transform.position + new Vector3(weaponRage * player.transform.localScale.x * -1, 0, 0);
                }
            }
        }
        if (plant)
        {
            if (isenemy)
            {
                if (!enemyattack)
                {

                    animator.SetBool("Attack", false);
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    animator.SetBool("Attack", true);
                    transform.localScale += new Vector3(growspeed * Time.deltaTime, growspeed * Time.deltaTime, 1);
                }

                if (plantattackstart)
                {
                    animator.SetBool("Attack", true);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isenemy)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                enemyhealth = collision.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(damnage);
            }
        }
        else
        {
            Debug.Log("hit");
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.TakeDamage(damnage);
            }
        }

    }

    public void Attack()
    {
        if (!isenemy)
        {
            transform.position = player.transform.position + new Vector3(weaponRage * player.transform.localScale.x, 0, 0);
            StartCoroutine(WeaponReturn());
        }
        else
        {
            animator.SetBool("Attack", true);
            StartCoroutine(AttackDelay());
        }


    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);
        transform.position = player.transform.position;
        if (isenemy)
        {
            animator.SetBool("Attack", false);
            enemyattack = false;
            plantattackstart = false;
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldowntime);
        Attack();
    }
    IEnumerator AttackDelay()
    {
        plantattackstart = true;
        yield return new WaitForSeconds(attackdelay);
        enemyattack = true;
        StartCoroutine(WeaponReturn());
    }
}

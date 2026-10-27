using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float weaponRage;
    public LayerMask enemyLayer;
    public int damnage = 1;
    public float attacktime;
    public float cooldowntime;

    public GameObject player;

    public EnemyHealth enemyhealth;
    public bool isenemy;
    public bool enemyattack;

    private void Start()
    {
        enemyhealth = enemyhealth.GetComponent<EnemyHealth>();

        if (isenemy && enemyhealth.agrivated == true)
        {
            StartCoroutine(CoolDown());
        }
    }
    private void Update()
    {
        if (isenemy && enemyhealth.agrivated == true)
        {
            if (!enemyattack)
            {
                transform.position = player.transform.position;
            }
            else
            {
                transform.position = player.transform.position + new Vector3(weaponRage * player.transform.localScale.x * -1, 0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isenemy)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyHealth>().TakeDamnge(damnage);
            }
        }
        else
        {
            Debug.Log("hit");
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(damnage);
            }
        }

    }

    public void Attack()
    {
        if (!isenemy)
        {
            enemyhealth.attacking = true;
            transform.position = player.transform.position + new Vector3(weaponRage * player.transform.localScale.x, 0, 0);
        }
        else
        {
            enemyattack = true;
        }

        StartCoroutine(WeaponReturn());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);
        transform.position = player.transform.position;
        if (isenemy)
        {
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()
    {
        enemyattack = false;
        enemyhealth.attacking = false;
        yield return new WaitForSeconds(cooldowntime);
        Attack();
    }
}

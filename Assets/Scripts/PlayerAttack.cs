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

    public bool isenemy;
    public bool enemyattack;

    private void Start()
    {
        if (isenemy)
        {
            StartCoroutine(CoolDown());
        }
    }
    private void Update()
    {
        if (isenemy)
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamnge(damnage);
        }
    }

    public void Attack()
    {
        if (!isenemy)
        {
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
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        enemyattack = false;
        yield return new WaitForSeconds(cooldowntime);
        Attack();
    }
}

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamnge(damnage);
        }
        if (isenemy)
        {
            StartCoroutine(CoolDown());
        }
    }

    public void Attack()
    {
        transform.position = player.transform.position + new Vector3(weaponRage * player.transform.localScale.x, 0, 0);
        StartCoroutine(WeaponReturn());
    }

    IEnumerator WeaponReturn()
    {
        yield return new WaitForSeconds(attacktime);
        transform.position = player.transform.position;
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldowntime);
        Attack();
    }
}

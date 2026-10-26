using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float weaponRage;
    public LayerMask enemyLayer;
    public int damnage = 1;


    public void Attack()
    {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRage, enemyLayer);
            Debug.Log ("Hit enemy");
            if (enemies.Length > 0)
            {
                enemies[0].GetComponent<EnemyHealth>().TakeDamnge(damnage);
            }
    }
}

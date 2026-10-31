using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour

{
    public PlayerHealth playerHealth;
    public int damage = 2;
    public AudioSource damagesound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damagesound.Play();
            playerHealth.TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    [SerializeField] public float knockbackForce;
    [SerializeField] public Rigidbody2D rb;
    public GameObject player;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamnge(int amount)
    {
        currentHealth -= amount;
        Knockback();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Knockback()
    {
        if (player.transform.position.x < transform.position.x)
        {
            if (player.gameObject.CompareTag("Player"))
            {
                rb.AddForce(Vector2.right * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }

        }
        else
        {
            if (player.gameObject.CompareTag("Player"))
            {
                rb.AddForce(Vector2.left * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
}

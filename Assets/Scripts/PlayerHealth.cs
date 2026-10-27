using System.Collections;

using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    private Rigidbody2D rb;
    [SerializeField] public float knockbackForce;
    public Animator animator;
    public int health;
    public int maxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                rb.AddForce(Vector2.right * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                rb.AddForce(Vector2.left * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                rb.AddForce(Vector2.right * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                rb.AddForce(Vector2.left * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Add Juice");
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
        Debug.Log("Game Over");
    }
}

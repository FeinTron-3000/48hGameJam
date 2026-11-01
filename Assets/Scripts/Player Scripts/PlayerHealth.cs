using System.Collections;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Knockback")]
    public Rigidbody2D rb;
    public float knockbackForce;

    [Header("Health")]
    public int health;
    public int maxhealth;

    public bool isdead;

    public GameObject enemytrackingpoint;

    [Header("Audio")]
    public AudioSource deathsound;
    public AudioSource hurtsound;

    [Header("Game Manager")]
    public GMHuntingScene gamemanager;

    [Header("Animator")]
    public Animator animator;
    public float deathanimationtime;

    public SpriteRenderer sprite;


    void Awake()
    {
        // set health
        health = maxhealth;

        gamemanager = gamemanager.GetComponent<GMHuntingScene>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            StartCoroutine(TakeDamageAnimation());
        }
    }
    IEnumerator TakeDamageAnimation()
    {
        sprite.color = Color.red;
        hurtsound.Play();

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;
    }

    public IEnumerator GameOver()
    {
        animator.SetBool("Death", true);
        // stop player from moving
        isdead = true;

        deathsound.Play();

        // stop enemy from following player
        Destroy(enemytrackingpoint);

        yield return new WaitForSeconds(deathanimationtime);

        gamemanager.LevelEnd();
    }

    // knockback
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
        {
            if (collision.gameObject.CompareTag("Knockback"))
            {
                // stop player from resisting knockback
                isdead = true;

                rb.AddForce(Vector2.right * knockbackForce, ForceMode2D.Impulse);

                TakeDamage(1);

                StartCoroutine(AllowMovement());
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Knockback"))
            {
                // stop player from resisting knockback
                isdead = true;

                rb.AddForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);

                TakeDamage(1);

                StartCoroutine(AllowMovement());
            }
        }
    }

    // allow movement after knockback
    IEnumerator AllowMovement()
    {
        yield return new WaitForSeconds(0.2f);

        if (health > 0)
        {
            isdead = false;
        }
    }
}

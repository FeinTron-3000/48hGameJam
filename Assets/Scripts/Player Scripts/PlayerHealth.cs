using System.Collections;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public int maxhealth;

    public bool isdead;

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

        yield return new WaitForSeconds(deathanimationtime);

        gamemanager.LevelEnd();
    }
}

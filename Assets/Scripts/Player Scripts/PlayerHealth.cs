using System.Collections;

using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public Rigidbody2D rb;

    [Header("Health")]
    public int health;
    public int maxhealth;

    public bool isdead;

    [Header("Audio")]
    public AudioSource deathsound;

    [Header("Game Manager")]
    public GMHuntingScene gamemanager;

    [Header("Animator")]
    public Animator animator;
    public float deathanimationtime;


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

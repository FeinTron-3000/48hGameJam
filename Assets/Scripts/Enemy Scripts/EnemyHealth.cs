using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Death")]
    public bool isdead;
    public GameObject deathcollider;
    public GameObject knockback;

    [Header("Enemy Type")]
    public bool mantis;
    public bool plant;
    public bool hornet;

    [Header("Game Manager")]
    public GMHuntingScene gamemanager;

    [Header("Attacking")]
    public bool agrivated;

    [Header("Audio")]
    public AudioSource deathsound;
    public AudioSource hurtsound;

    [Header("Animator")]
    public Animator animator;

    public SpriteRenderer sprite;


    void Awake()
    {
        // set health
        currentHealth = maxHealth;

        gamemanager = gamemanager.GetComponent<GMHuntingScene>();

        if (plant)
        {
            agrivated = true;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        agrivated = true;

        if (currentHealth <= 0)
        {
            Die();
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


    void Die()
    {
        animator.SetBool("Die", true);

        // stop attacking and moving
        isdead = true;

        // increase score
        if (mantis)
        {
            gamemanager.mantisdead += 1;
        }
        if (plant)
        {
            gamemanager.plantdead += 1;
        }
        if (hornet)
        {
            gamemanager.hornetdead += 1;
        }

        // disable knockback damage
        knockback.gameObject.tag = "Untagged";

        // change collider shape to match death sprite
        deathcollider.SetActive(true);
        Destroy(gameObject);
    }
}

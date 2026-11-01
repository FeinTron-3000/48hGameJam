using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Health")]
    public bool isdead;
    public GameObject deathcollider;

    [Header("Enemy Type")]
    [SerializeField] private bool mantis;
    [SerializeField] private bool plant;
    [SerializeField] private bool hornet;

    public GMHuntingScene gamemanager;

    [Header("Attacking")]
    public bool agrivated;

    [Header("Audio")]
    public AudioSource deathsound;
    public AudioSource hurtsound;

    [Header("Animator")]
    public Animator animator;
    public float deathanimationtime;

    public SpriteRenderer sprite;


    void Awake()
    {
        // set health
        currentHealth = maxHealth;

        gamemanager = gamemanager.GetComponent<GMHuntingScene>();
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

        // change collider shape to match death sprite
        deathcollider.SetActive(true);
        // destroy current collider
        Destroy(gameObject);
    }
}

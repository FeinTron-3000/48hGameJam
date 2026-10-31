using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    public bool isdead;

    [Header("Attacking")]
    public bool agrivated;

    [Header("Audio")]
    public AudioSource deathsound;

    [Header("Animator")]
    public Animator animator;
    public float deathanimationtime;

    void Awake()
    {
        // set health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        agrivated = true;

        if (currentHealth <= 0)
        {
            StartCoroutine(die());
        }
    }

    IEnumerator die()
    {
        animator.SetBool("Die", true);
        isdead = true;

        yield return new WaitForSeconds(deathanimationtime);
    }
}

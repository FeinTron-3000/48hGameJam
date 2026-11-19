using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [Header("Tracker")]
    public PlayerStats tracker;

    [Header("Audio")]
    public AudioSource collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collect.Play();

            tracker.money += 5;

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    [Header("Tracker")]
    public ScoreTracker tracker;
    public TextMeshProUGUI moneytracker;

    [Header("Audio")]
    public AudioSource collect;

    void Start()
    {
        moneytracker.text = "Money: " + tracker.money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collect.Play();

            tracker.money += 5;
            moneytracker.text = "Money: " + tracker.money;

            Destroy(gameObject);
        }
    }
}

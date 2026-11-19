using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GMUpgradesPage : MonoBehaviour
{
    [Header("Tracker")]
    public PlayerStats tracker;

    [Header("Audio")]
    public AudioSource click;

    [Header("Variables")]
    public int cost;
    public int upgradeindex;

    public GameObject button;
    public TextMeshProUGUI moneycounter;

    void Start()
    {
        moneycounter.text = "Money: " + tracker.money;
    }

    public void OnMouseDown()
    {
        if (tracker.money >= cost)
        {
            tracker.money -= cost;

            click.Play();

            if (upgradeindex == 1)
            {
                tracker.movespeed += 5;
            }
            if (upgradeindex == 2)
            {
                tracker.damage += 1;
            }
            if (upgradeindex == 3)
            {
                tracker.dashingtime += 0.5f;
            }

            moneycounter.text = "Money: " + tracker.money;
            button.SetActive(false);
        }
    }
}

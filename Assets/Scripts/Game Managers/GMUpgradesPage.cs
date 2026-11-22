using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GMUpgradesPage : MonoBehaviour
{
    [Header("Tracker")]
    public ScoreTracker tracker;

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

        // don't allow upgrade to be bought twice
        if (upgradeindex == 1)
        {
            if (tracker.upgrade1bought)
            {
                button.SetActive(false);
            }
        }
        if (upgradeindex == 2)
        {
            if (tracker.upgrade2bought)
            {
                button.SetActive(false);
            }
        }
        if (upgradeindex == 3)
        {
            if (tracker.upgrade3bought)
            {
                button.SetActive(false);
            }
        }
    }

    public void OnMouseDown()
    {
        if (tracker.money >= cost)
        {
            tracker.money -= cost;

            click.Play();

            if (upgradeindex == 1)
            {
                tracker.jumppower += 2;
                tracker.upgrade1bought = true;
            }
            if (upgradeindex == 2)
            {
                tracker.damage += 1;
                tracker.upgrade2bought = true;
            }
            if (upgradeindex == 3)
            {
                tracker.maxhealth += 3;
                tracker.upgrade3bought = true;
            }

            moneycounter.text = "Money: " + tracker.money;
            button.SetActive(false);
        }
    }
}

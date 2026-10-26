using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;
using UnityEditor.Experimental.GraphView;

public class Countdown : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI timerText;

    public float currentTime = 30f;
    private bool active = true;

    // Update is called once per frame
    void Update()
    {
        if ( active)
        {

            currentTime -= Time.deltaTime;

            UpdateTimerUI();
            {
                if (currentTime <= 0)
                {
                    StopTimer();
                }
            }
        }
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);

    }

    public void StopTimer()
    {
        active = false;
        currentTime = 0f;
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (currentTime > 0 && currentTime < 10)
        {
            timerText.color = Color.yellow;
        }
        else if (currentTime < 1)
        {
            timerText.color = Color.red;
        }
    }
}
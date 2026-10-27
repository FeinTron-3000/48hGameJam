using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public int timelimit;

    [SerializeField] public GMCookingScene gm;

    void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        for (int i = timelimit; i > 0; i--)
        {
            timelimit--;
            int minutes = Mathf.FloorToInt(timelimit / 60);
            int seconds = Mathf.FloorToInt(timelimit % 60);
            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(1);
        }
        StopTimer();
    }

    public void StopTimer()
    {
        timelimit = 0;
        TimesUp();
        gm.GameOver();
    }

    // game over animation
    private void TimesUp()
    {
        if (timelimit > 0 && timelimit < 10)
        {
            timerText.color = Color.yellow;
        }
        else if (timelimit < 1)
        {
            timerText.color = Color.red;
        }
    }
}
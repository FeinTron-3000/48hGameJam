using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GMHuntingScene : MonoBehaviour
{
    [SerializeField] public float worldtime;
    [SerializeField] public GameObject player;
    [SerializeField] public string resultsscreen;

    [SerializeField] public ScoreTracker scoretracker;

    [SerializeField] public HuntingScoring huntingscoring;
    [SerializeField] public GameObject[] mantis;
    [SerializeField] public GameObject[] plant;
    [SerializeField] public GameObject[] hornet;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public int timelimit;



    void Start()
    {
        // reset meat collection
        huntingscoring.mantiscore = 0;

        //start countdown
        StartCoroutine(CountDown());
    }

    void Update()
    {
        worldtime += 1 * Time.deltaTime;

        // level end
        if (player == null)
        {

            LevelEnd();
        }

        else if (timelimit <= 0)
        {
            LevelEnd();
        }
    }

    // Timer/countdown
    IEnumerator CountDown()
    {
        for (int i = timelimit; i > 0; i--)
        {
            timelimit--;
            int minutes = Mathf.FloorToInt(timelimit / 60);
            int seconds = Mathf.FloorToInt(timelimit % 60);
            timerText.text = "Time remaining: " + string.Format("{00:00}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(1);
        }
        StopTimer();
    }

    public void StopTimer()
    {
        timelimit = 0;
        TimesUp();
        LevelEnd();
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
    public void LevelEnd()
    {
        // meat collection
        for (int i = 0; i < mantis.Length; i++)
        {
            if (mantis[i] == null)
            {
                huntingscoring.mantiscore += 1;
            }
        }
        for (int i = 0; i < plant.Length; i++)
        {
            if (mantis[i] == null)
            {
                huntingscoring.plantscore += 1;
            }
        }
        for (int i = 0; i < hornet.Length; i++)
        {
            if (mantis[i] == null)
            {
                huntingscoring.hornetscore += 1;
            }
        }
        SceneManager.LoadScene(resultsscreen);
    }
}

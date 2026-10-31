using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GMHuntingScene : MonoBehaviour
{
    public string nextscenename;

    [Header("Trackers")]
    public ScoreTracker scoretracker;

    public HuntingScoring huntingscoring;
    public GameObject[] mantis;
    public GameObject[] plant;
    public GameObject[] hornet;

    [Header("Countdown")]
    public TextMeshProUGUI timertext;
    public int timelimit;


    void Start()
    {
        // reset level score
        huntingscoring.mantiscore = 0;
        huntingscoring.plantscore = 0;
        huntingscoring.hornetscore = 0;

        // start countdown
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        for (int i = timelimit; i > 0; i--)
        {
            // reduce time remainig
            timelimit--;

            // set timer text to format
            int minutes = Mathf.FloorToInt(timelimit / 60);
            int seconds = Mathf.FloorToInt(timelimit % 60);
            timertext.text = "Time remaining: " + string.Format("{00:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1);
        }

        LevelEnd();
    }

    public void GameOverAnimation()
    {

    }

    public void LevelEnd()
    {
        // tally the level score
        for (int i = 0; i < mantis.Length; i++)
        {
            if (mantis[i] == null)
            {
                huntingscoring.mantiscore += 1;
            }
        }
        for (int i = 0; i < plant.Length; i++)
        {
            if (plant[i] == null)
            {
                huntingscoring.plantscore += 1;
            }
        }
        for (int i = 0; i < hornet.Length; i++)
        {
            if (hornet[i] == null)
            {
                huntingscoring.hornetscore += 1;
            }
        }

        // load the next scene
        SceneManager.LoadScene(nextscenename);
    }
}

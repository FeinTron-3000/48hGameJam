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

    [Header("Score Tracking")]
    public int mantisdead;
    public TextMeshProUGUI mantistext;

    public int plantdead;
    public TextMeshProUGUI planttext;

    public int hornetdead;
    public TextMeshProUGUI hornettext;

    [Header("Countdown")]
    public TextMeshProUGUI timertext;
    public int timelimit;

    void Update()
    {
        // score tracking
        mantistext.text = "Mantis dead: " + mantisdead;
        planttext.text = "Plant dead: " + plantdead;
        hornettext.text = "Hornet dead: " + hornetdead;
    }

    void Start()
    {
        // reset level score tracker
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
        // tally score
        huntingscoring.mantiscore = mantisdead;
        huntingscoring.plantscore = plantdead;
        huntingscoring.hornetscore = hornetdead;


        // load the next scene
        SceneManager.LoadScene(nextscenename);
    }
}

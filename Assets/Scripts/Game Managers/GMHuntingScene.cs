using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GMHuntingScene : MonoBehaviour
{
    public string nextscenename;

    [Header("Tracker")]
    public ScoreTracker scoretracker;

    [Header("Score Tracking")]
    public int mantisdead;
    public int plantdead;
    public int hornetdead;

    [Header("Player")]
    public PlayerHealth playerhealth;
    public Animator healthbar;

    [Header("Countdown")]
    public TextMeshProUGUI timertext;
    public int timelimit;

    void Start()
    {
        playerhealth = playerhealth.GetComponent<PlayerHealth>();

        // reset level score tracker
        scoretracker.mantiscore = 0;
        scoretracker.plantscore = 0;
        scoretracker.hornetscore = 0;

        // start countdown
        StartCoroutine(CountDown());
    }

    void Update()
    {
        // health tracking
        if (playerhealth.health <= playerhealth.maxhealth - 1)
        {
            healthbar.SetBool("2/3 Health", true);
        }
        if (playerhealth.health == 1)
        {
            healthbar.SetBool("1/3 Health", true);
        }
        if (playerhealth.health == 0)
        {
            healthbar.SetBool("0/3 Health", true);
        }
        else
        {
            healthbar.SetBool("3/3 Health", true);
        }
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
        scoretracker.mantiscore = mantisdead;
        scoretracker.plantscore = plantdead;
        scoretracker.hornetscore = hornetdead;


        // load the next scene
        SceneManager.LoadScene(nextscenename);
    }
}

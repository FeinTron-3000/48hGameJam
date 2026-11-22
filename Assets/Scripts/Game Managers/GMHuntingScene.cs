using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GMHuntingScene : MonoBehaviour
{
    [Header("Scene Loading")]
    public string nextscenename;
    public TransitionManager transitionManager;

    [Header("Game Start")]
    public bool gameisrunning = false;
    public TextMeshProUGUI countdowntext;

    public GameObject instructions;
    public GameObject gameui;

    public AudioSource click;

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

    public AudioSource finalseconds;

    void Start()
    {
        playerhealth = playerhealth.GetComponent<PlayerHealth>();
        transitionManager = transitionManager.GetComponent<TransitionManager>();

        // reset level score tracker
        scoretracker.mantiscore = 0;
        scoretracker.plantscore = 0;
        scoretracker.hornetscore = 0;

        if (scoretracker.huntingplayedonce)
        {
            OnMouseDown();
        }
    }

    public void OnMouseDown()
    {
        instructions.SetActive(false);
        gameui.SetActive(true);

        StartCoroutine(GameStart());

        // set time limit
        int minutes = Mathf.FloorToInt(timelimit / 60);
        int seconds = Mathf.FloorToInt(timelimit % 60);
        timertext.text = "Time remaining: " + string.Format("{00:00}:{1:00}", minutes, seconds);

        if (!scoretracker.huntingplayedonce)
        {
            click.Play();
        }

        scoretracker.huntingplayedonce = true;
    }

    IEnumerator GameStart()
    {
        // countdown
        countdowntext.text = "3";
        countdowntext.color = Color.green;
        yield return new WaitForSeconds(1.5f);
        countdowntext.text = "2";
        countdowntext.color = Color.yellow;
        yield return new WaitForSeconds(1);
        countdowntext.text = "1";
        countdowntext.color = Color.red;
        yield return new WaitForSeconds(1);
        countdowntext.text = "0";

        gameisrunning = true;

        StartCoroutine(CountDown());

        yield return new WaitForSeconds(2);

        countdowntext.enabled = false;
    }

    void Update()
    {
        if (!gameisrunning)
        {
            return;
        }

        // health tracking
        if (playerhealth.health == playerhealth.maxhealth)
        {
            healthbar.SetBool("3/3 Health", true);
        }
        if (playerhealth.health <= 4)
        {
            healthbar.SetBool("2/3 Health", true);
        }
        if (playerhealth.health == 1)
        {
            healthbar.SetBool("1/3 Health", true);
        }
        else if (playerhealth.health <= 0)
        {
            healthbar.SetBool("0/3 Health", true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LevelEnd();
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

            if (timelimit == 4)
            {
                finalseconds.Play();
            }

            yield return new WaitForSeconds(1);
        }

        LevelEnd();
    }

    public void LevelEnd()
    {
        // tally score
        scoretracker.mantiscore = mantisdead;
        scoretracker.plantscore = plantdead;
        scoretracker.hornetscore = hornetdead;

        gameisrunning = false;

        transitionManager.QueueSceneChange();
        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextscenename);
    }
}

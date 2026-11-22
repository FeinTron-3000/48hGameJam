using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMCookingScene : MonoBehaviour
{
    [Header("Tracker")]
    public ScoreTracker scoretracker;

    public int score;
    public TextMeshProUGUI scoreui;

    public bool fryingsection;
    public bool stirringsection;
    public bool choppingsection;

    [Header("Level Names")]
    public string[] levelnames;
    public int index;

    public TransitionManager transitionManager;

    [Header("Music")]
    public AudioSource music;

    [Header("Timer")]
    public TextMeshProUGUI timertext;
    public int timelimit;

    public AudioSource finalseconds;

    public bool gameisrunning = false;
    public TextMeshProUGUI countdowntext;

    void Start()
    {
        // increase timelimit
        if (fryingsection)
        {
            timelimit += scoretracker.hornetscore * 5;
        }
        else if (stirringsection)
        {
            timelimit += scoretracker.plantscore * 5;
        }
        else if (choppingsection)
        {
            timelimit += scoretracker.mantiscore * 5;
        }

        // set time limit
        int minutes = Mathf.FloorToInt(timelimit / 60);
        int seconds = Mathf.FloorToInt(timelimit % 60);
        timertext.text = string.Format("{00:00}:{1:00}", minutes, seconds);

        StartCoroutine(GameStart());
    }

    void Update()
    {
        // score ui
        scoreui.text = "Score: " + score;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameOver();
        }
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

        music.Play();
        StartCoroutine(CountDown());

        yield return new WaitForSeconds(2);

        countdowntext.enabled = false;
    }

    IEnumerator CountDown()
    {
        for (int i = timelimit; i > 0; i--)
        {
            timelimit--;
            int minutes = Mathf.FloorToInt(timelimit / 60);
            int seconds = Mathf.FloorToInt(timelimit % 60);
            timertext.text = string.Format("{00:00}:{1:00}", minutes, seconds);

            if (timelimit == 4)
            {
                finalseconds.Play();
            }

            yield return new WaitForSeconds(1);
        }

        timelimit = 0;
        GameOver();
    }

    public void GameOver()
    {
        // scriptable object equal level score
        if (fryingsection)
        {
            scoretracker.fryingscore = score;
        }
        else if (stirringsection)
        {
            scoretracker.stirringscore = score;

            // next cooking level is not previous level
            fryingsection = true;
        }
        else if (choppingsection)
        {
            scoretracker.choppingscore = score;

            // next cooking level is not previous level
            fryingsection = true;
            stirringsection = true;
        }

        // next cooking level
        if (scoretracker.hornetscore > 0 && !fryingsection)
        {
            index = 0;
        }
        else if (scoretracker.plantscore > 0 && !stirringsection)
        {
            index = 1;
        }
        else if (scoretracker.mantiscore > 0 && !choppingsection)
        {
            index = 2;
        }
        else
        {
            index = 3;
        }

        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        gameisrunning = false;

        transitionManager.QueueSceneChange();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelnames[index]);
    }
}

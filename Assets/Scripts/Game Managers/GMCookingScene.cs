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

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public int timelimit;

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

        StartCoroutine(CountDown());
    }

    void Update()
    {
        // score ui
        scoreui.text = "Score: " + score;
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
        transitionManager.QueueSceneChange();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelnames[index]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    void Update()
    {
        // score ui
        scoreui.text = "Score: " + score;
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

        SceneManager.LoadScene(levelnames[index]);
    }
}

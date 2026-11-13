using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GMCookingScene : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreui;

    [Header("Tracker")]
    public ScoreTracker cookingScoring;

    public bool choppingsection;
    public bool stirringsection;
    public bool skillcheck;

    public ScoreTracker scoretracker;

    public string[] levelnames;
    public int index;

    void Start()
    {

    }

    void Update()
    {
        // set text
        scoreui.text = "Score: " + score;
    }

    public void GameOver()
    {
        // scriptable object equal level score
        if (choppingsection)
        {
            cookingScoring.choppingscore = score;
        }
        else if (stirringsection)
        {
            cookingScoring.stirringscore = score;
        }
        else if (skillcheck)
        {
            cookingScoring.skillcheckscore = score;
        }
        SceneManager.LoadScene(levelnames[index]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GMCookingScene : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public TextMeshProUGUI scoreui;

    [SerializeField] public CookingScoring cookingScoring;

    [SerializeField] public bool choppingsection;
    [SerializeField] public bool stirringsection;
    [SerializeField] public bool skillcheck;

    [SerializeField] public ScoreTracker scoretracker;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMResultsPage : MonoBehaviour
{
    [Header("Level Name")]
    public string nextscenename;

    [Header("Tracker")]
    public ScoreTracker score;

    [Header("Rank")]
    public int a;
    public int b;
    public int c;
    public int d;

    public GameObject[] scores;
    public int finalscore;

    [Header("Food")]
    public GameObject[] food;
    public int foodindex;

    void Start()
    {
        // randomly select food
        Debug.Log("Add food determine code");
        foodindex = Random.Range(0, food.Length);
        food[foodindex].SetActive(true);

        // calculate rank
        finalscore = score.choppingscore / 2 + score.fryingscore + score.stirringscore;

        if (finalscore >= a)
        {
            scores[0].SetActive(true);
        }
        else if (finalscore >= b)
        {
                scores[1].SetActive(true);
        }
        else if (finalscore >= c)
        {
                scores[2].SetActive(true);
        }
        else
        {
                scores[3].SetActive(true);
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene(nextscenename);
    }
}

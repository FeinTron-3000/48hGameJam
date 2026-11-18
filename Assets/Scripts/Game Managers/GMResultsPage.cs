using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMResultsPage : MonoBehaviour
{
    [Header("Scene Loading")]
    public string nextscenename;
    public TransitionManager transitionManager;

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
        // determine food
        if (score.hornetscore >= 1)
        {
            foodindex = 0;
            if (score.plantscore >= 1)
            {
                foodindex = 3;
                if (score.mantiscore >= 1)
                {
                    foodindex = 6;
                }
            }
            else if (score.mantiscore >= 1)
            {
                foodindex = 4;
            }
        }
        else if (score.plantscore >= 1)
        {
            foodindex = 1;
            if (score.mantiscore >= 1)
            {
                foodindex = 5;
            }
        }
        else if (score.mantiscore >= 1)
        {
            foodindex = 2;
        }

        food[foodindex].SetActive(true);

        // calculate rank
        finalscore = score.choppingscore + score.fryingscore + score.stirringscore;

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
        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        transitionManager.QueueSceneChange();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextscenename);
    }
}

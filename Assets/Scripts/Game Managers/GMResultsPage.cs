using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GMResultsPage : MonoBehaviour
{
    [Header("Scene Loading")]
    public string nextscenename;
    public TransitionManager transitionManager;

    [Header("Tracker")]
    public ScoreTracker score;

    [Header("Rank")]
    public int s;
    public int a;
    public int b;
    public int c;
    public int d;

    public GameObject[] scores;
    public int finalscore;

    public TextMeshProUGUI moneycounter;

    [Header("Food")]
    public GameObject[] food;
    public int foodindex;

    [Header("Food discovered")]
    public GameObject[] unlockeddishes;

    void Awake()
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
        else
        {
            foodindex = 7;
        }

        food[foodindex].SetActive(true);

        // calculate rank
        finalscore = score.choppingscore + score.fryingscore / 2 + score.stirringscore * 2;

        if (finalscore >= s)
        {
            scores[0].SetActive(true);

            score.money += 20;
            moneycounter.text = "Money: " + score.money;
        }
        else if (finalscore >= a)
        {
            scores[1].SetActive(true);

            score.money += 12;
            moneycounter.text = "Money: " + score.money;
        }
        else if (finalscore >= b)
        {
            scores[2].SetActive(true);

            score.money += 8;
            moneycounter.text = "Money: " + score.money;
        }
        else if (finalscore >= c)
        {
            scores[3].SetActive(true);

            score.money += 5;
            moneycounter.text = "Money: " + score.money;
        }
        else 
        {
            scores[4].SetActive(true);

            score.money += 3;
            moneycounter.text = "Money: " + score.money;
        }
    }

    void Start()
    {
        if (foodindex == 0)
        {
            score.dish1unlocked = true;
        }
        else if (foodindex == 1)
        {
            score.dish2unlocked = true;
        }
        else if (foodindex == 2)
        {
            score.dish3unlocked = true;
        }
        else if (foodindex == 3)
        {
            score.dish4unlocked = true;
        }
        else if (foodindex == 4)
        {
            score.dish5unlocked = true;
        }
        else if (foodindex == 5)
        {
            score.dish6unlocked = true;
        }
        else if (foodindex == 6)
        {
            score.dish7unlocked = true;
        }

        if (score.dish1unlocked)
        {
            unlockeddishes[0].SetActive(false);
        }
        if (score.dish2unlocked)
        {
            unlockeddishes[1].SetActive(false);
        }
        if (score.dish3unlocked)
        {
            unlockeddishes[2].SetActive(false);
        }
        if (score.dish4unlocked)
        {
            unlockeddishes[3].SetActive(false);
        }
        if (score.dish5unlocked)
        {
            unlockeddishes[4].SetActive(false);
        }
        if (score.dish6unlocked)
        {
            unlockeddishes[5].SetActive(false);
        }
        if (score.dish7unlocked)
        {
            unlockeddishes[6].SetActive(false);
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

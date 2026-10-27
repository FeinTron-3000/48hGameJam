using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GMResultsScreen : MonoBehaviour
{
    [SerializeField] public HuntingScoring huntingscoring;
    [SerializeField] public ScoreTracker scoretracker;

    public string[] levelnames;
    public int index;

    public int wait;
    void Start()
    {
        if (huntingscoring.hornetscore > 0)
        {
            scoretracker.choppingsection = true;
            index = 2;
        }
        else
        {
            index = 3;
        }
        if (huntingscoring.plantscore > 0)
        {
            scoretracker.choppingsection = true;
            index = 1;
        }
        else
        {
            index = 3;
        }
        if (huntingscoring.mantiscore > 0)
        {
            scoretracker.choppingsection = true;
            index = 0;
        }
        else
        {
            index = 3;
        }
        StartCoroutine(Juice());
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelnames[index]);
    }
    IEnumerator Juice()
    {
        yield return new WaitForSeconds(wait);
        StartGame();
    }
}

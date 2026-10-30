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
        StartCoroutine(Juice());
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelnames[0]);
    }
    IEnumerator Juice()
    {
        yield return new WaitForSeconds(wait);
        StartGame();
    }
}

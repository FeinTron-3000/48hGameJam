using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GMResultsScreen : MonoBehaviour
{
    public TextMeshProUGUI mantisscoretext;

    [SerializeField] public HuntingScoring huntingscoring;
    [SerializeField] public ScoreTracker scoretracker;

    public string[] levelnames;
    public int index;
    void Start()
    {

        mantisscoretext.text = "Mantis killed: " + huntingscoring.mantiscore;

        if (huntingscoring.mantiscore > 0)
        {
            scoretracker.choppingsection = true;
        }
        else
        {
            scoretracker.choppingsection = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoretracker.choppingsection)
        {
            index = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelnames[index]);
    }
}

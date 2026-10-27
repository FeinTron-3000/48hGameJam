using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMHuntingScene : MonoBehaviour
{
    [SerializeField] public float worldtime;
    [SerializeField] public float levelcompletetime;
    [SerializeField] public GameObject player;
    [SerializeField] public string resultsscreen;

    [SerializeField] public ScoreTracker scoretracker;

    [SerializeField] public HuntingScoring huntingscoring;
    [SerializeField] public GameObject[] mantis;

    void Start()
    {
        // reset meat collection
        huntingscoring.mantiscore = 0;
    }

    void Update()
    {
        worldtime += 1 * Time.deltaTime;

        // level end
        if (player == null)
        {
            // scoretracker.score = worldtime;

            // meat collection
            for(int i = 0; i > mantis.Length; i++)
            {
                if (mantis[i] == null)
                {
                    huntingscoring.mantiscore += 1;
                }
            }
            LevelEnd();
        }
        else if (worldtime >= levelcompletetime)
        {
            LevelEnd();
        }
    }

    public void LevelEnd()
    {
        SceneManager.LoadScene(resultsscreen);
    }
}

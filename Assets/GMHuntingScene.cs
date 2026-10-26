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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        worldtime += 1 * Time.deltaTime;
        if (player == null)
        {
            scoretracker.score = worldtime;
            LevelEnd();
        }
    }

    public void LevelEnd()
    {
        SceneManager.LoadScene(resultsscreen);
    }
}

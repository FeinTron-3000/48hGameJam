using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingGM : MonoBehaviour
{
    public CookingScoring score;
    public int a;
    public int b;
    public int c;
    public int d;
    public GameObject[] scores;

    public ScoreTracker foodtype;
    public GameObject[] food;
    public int foodindex;
    public int finalscore;
    // Start is called before the first frame update
    void Start()
    {
        foodindex = Random.Range(0, food.Length);
        finalscore = score.choppingscore + score.skillcheckscore + score.stirringscore;

        food[foodindex].SetActive(true);

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
        else if (finalscore >= d)
        {
                scores[3].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

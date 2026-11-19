using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMHuntingResults : MonoBehaviour
{
    [Header("Tracker")]
    public ScoreTracker scoretracker;

    [Header("Level Names")]
    public string[] levelnames;
    public int index;

    public TransitionManager transitionManager;

    [Header("Animation")]
    public float animationtime;
    public Animator animator;

    public GameObject UI;

    [Header("Score Tracking")]
    public TextMeshProUGUI mantistext;
    public TextMeshProUGUI planttext;
    public TextMeshProUGUI hornettext;

    [Header("Audio")]
    public AudioSource button;

    void Start()
    {
        // reset cooking score tracker
        scoretracker.fryingscore = 0;
        scoretracker.stirringscore = 0;
        scoretracker.choppingscore = 0;

        // score tracking
        mantistext.text = "Mantis dead: " + scoretracker.mantiscore;
        planttext.text = "Plant dead: " + scoretracker.plantscore;
        hornettext.text = "Hornet dead: " + scoretracker.hornetscore;

        // available cooking level
        if (scoretracker.hornetscore > 0)
        {
            index = 0;
        }
        else if (scoretracker.plantscore > 0)
        {
            index = 1;
        }
        else if (scoretracker.mantiscore > 0)
        {
            index = 2;
        }
        else
        {
            index = 3;
        }
    }
    public void Continue()
    {
        StartCoroutine(TransitionAnimation());
    }
    IEnumerator TransitionAnimation()
    {
        animator.SetBool("Transition", true);
        UI.SetActive(false);

        yield return new WaitForSeconds(animationtime);

        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        button.Play();
        transitionManager.QueueSceneChange();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelnames[index]);
    }
}

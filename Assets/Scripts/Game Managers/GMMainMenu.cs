using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainMenu : MonoBehaviour
{
    [Header("Scene Loading")]
    public string nextscenename;
    public TransitionManager transitionManager;

    [Header("Background Animation")]
    public Animator animator;
    public float animationplaytime;

    [Header("StartButton")]
    public GameObject startbutton;
    public AudioSource buttonclick;

    public void OnMouseDown()
    {
        animator.SetBool("Transition", true);

        startbutton.SetActive(false);
        buttonclick.Play();

        StartCoroutine(AnimationPlayFirst());
    }

    // lets the transition animation play 
    public IEnumerator AnimationPlayFirst()
    {
        yield return new WaitForSeconds(animationplaytime);

        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        transitionManager.QueueSceneChange();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextscenename);
    }
}

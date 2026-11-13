using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainMenu : MonoBehaviour
{
    [Header("Level Name")]
    public string nextscenename;

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

        // load the next scene
        SceneManager.LoadScene(nextscenename);
    }
}

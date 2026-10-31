using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainMenu : MonoBehaviour
{
    public string nextlevename;

    [Header("Background Animation")]
    public Animator animator;
    public float animationplaytime;


    // code refrenced by start button in UI
    public void OnMouseDown()
    {
        animator.SetBool("Transition", true);
        StartCoroutine(AnimationPlayFirst());
    }

    // lets the transition animation play 
    public IEnumerator AnimationPlayFirst()
    {
        yield return new WaitForSeconds(animationplaytime);

        // load the next scene
        SceneManager.LoadScene(nextlevename);
    }
}

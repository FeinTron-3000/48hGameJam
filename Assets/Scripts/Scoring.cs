using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    [SerializeField] public GMCookingScene gm;
    public Animator animator;
    public Animator button;
    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }
    public void OnMouseDown()
    {
        // increase score
        animator.SetBool("Chop", true);
        button.SetBool("Mash", true);
        gm.score++;
        StartCoroutine(Stop());
    }
    public IEnumerator Stop()
    {
        
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("Chop", false);
        button.SetBool("Mash", false);

    }
}

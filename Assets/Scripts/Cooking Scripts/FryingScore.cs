using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingScore : MonoBehaviour
{
    [Header("Scripts")]
    public GMCookingScene gm;

    [Header("Variables")]
    public Collider2D buttoncollision;

    public bool negativepoints;

    [Header("Animator")]
    public Animator animator;

    [Header("Audio")]
    public AudioSource fry;
    public AudioSource bad;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }
    public void OnMouseDown()
    {
        if (negativepoints)
        {
            // decrease score
            gm.score--;
            bad.Play();

            return;
        }

        // increase score
        gm.score++;
        animator.SetBool("Mash", true);

        fry.Play();

        // don't allow for multiple clicks
        buttoncollision.enabled = false;

        StartCoroutine(AnimationPlay());
    }

    IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Mash", false);
    }

    void OnEnable()
    {
        buttoncollision.enabled = true;
    }
}

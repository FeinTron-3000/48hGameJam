using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;
    public Animator smoke;

    private void Start()
    {
        smoke.SetBool("Smoke", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Smash", true);
        StartCoroutine(AnimationPlay());
    }

    public IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Smash", false);
    }
}

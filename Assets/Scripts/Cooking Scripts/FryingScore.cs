using System.Collections;
using UnityEngine;

public class FryingScore : MonoBehaviour
{
    [Header("Scripts")]
    public GMCookingScene gm;
    public StoveKnob stoveknob;

    [Header("Variables")]
    public Collider2D buttoncollision;

    public bool negativepoints;

    [Header("Animator")]
    public Animator animator;
    public Animator fryingpan;

    [Header("Audio")]
    public AudioSource fry;
    public AudioSource bad;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
        stoveknob = stoveknob.gameObject.GetComponent<StoveKnob>();
    }
    public void OnMouseDown()
    {
        if (negativepoints)
        {
            // decrease score
            gm.score--;
            bad.Play();

            animator.SetBool("Mash", true);
            StartCoroutine(AnimationPlay());

            return;
        }

        // increase score
        gm.score++;

        animator.SetBool("Mash", true);
        fryingpan.SetBool("Toss", true);
        fry.Play();

        // change stove knob direction
        if (stoveknob.direction)
        {
            stoveknob.direction = false;
        }
        else
        {
            stoveknob.direction = true;
        }

        // don't allow for multiple clicks
        buttoncollision.enabled = false;

        StartCoroutine(AnimationPlay());
    }

    public IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.1f);

        animator.SetBool("Mash", false);
        if (!negativepoints)
        {
            fryingpan.SetBool("Toss", false);
        }
    }

    void OnEnable()
    {
        animator.SetBool("Mash", false);

        if (!negativepoints)
        {
            fryingpan.SetBool("Toss", false);
        }

        buttoncollision.enabled = true;
    }
}

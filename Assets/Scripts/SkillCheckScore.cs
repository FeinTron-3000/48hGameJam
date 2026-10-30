using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckScore : MonoBehaviour
{
    [SerializeField] public GMCookingScene gm;
    [SerializeField] public SkillCheck skillcheck;
    [SerializeField] public Animator animator;
    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
        skillcheck = skillcheck.gameObject.GetComponent<SkillCheck>();
    }
    public void OnMouseDown()
    {
        // increase score
        if (skillcheck.clickready)
        {
            gm.score++;
            animator.SetBool("Mash", true);

        }
        else
        {
            gm.score--;
            animator.SetBool("Mash", true);
        }
        StartCoroutine(udgygdy());
    }
    IEnumerator udgygdy()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Mash", false);
    }
}

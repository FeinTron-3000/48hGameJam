using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckScore : MonoBehaviour
{
    [SerializeField] public GMCookingScene gm;
    [SerializeField] public SkillCheck skillcheck;
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
        }
        else
        {
            gm.score--;
        }
    }
}

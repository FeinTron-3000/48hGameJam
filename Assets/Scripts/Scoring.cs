using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    [SerializeField] public GMCookingScene gm;
    [SerializeField] public bool stirringmode;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }
    public void OnMouseDown()
    {
        // increase score
        gm.score++;
        if (stirringmode)
        {
            Destroy(gameObject);
        }
    }
}

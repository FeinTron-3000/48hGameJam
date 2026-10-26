using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    public static int score = 0;

    [SerializeField] private TMP_Text scoreText;

    private void OnMouseDown()
    {
        score++;
        if (scoreText  != null )
        {
            scoreText.text = "Score: " + score;
        }
    }
}

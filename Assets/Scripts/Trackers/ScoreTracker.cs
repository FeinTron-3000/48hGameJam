using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreTracker", menuName = "ScoreTracker")]
public class ScoreTracker : ScriptableObject
{
    [Header("Hunting")]
    public int mantiscore;
    public int plantscore;
    public int hornetscore;

    [Header("Cooking")]
    public int choppingscore;
    public int stirringscore;
    public int fryingscore;

    [Header("Player Stats")]
    public float movespeed = 10;
    public bool upgrade1bought;

    public int damage = 1;
    public bool upgrade2bought;

    public float dashingtime = 0.2f;
    public bool upgrade3bought;

    [Header("Money")]
    public int money;
}

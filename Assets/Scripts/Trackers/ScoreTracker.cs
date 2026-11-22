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

    public bool huntingplayedonce;

    [Header("Cooking")]
    public int choppingscore;
    public int stirringscore;
    public int fryingscore;

    [Header("Food Discovered")]
    public bool dish1unlocked;
    public bool dish2unlocked;
    public bool dish3unlocked;
    public bool dish4unlocked;
    public bool dish5unlocked;
    public bool dish6unlocked;
    public bool dish7unlocked;

    [Header("Player Stats")]
    public float jumppower = 8;
    public bool upgrade1bought;

    public int damage = 1;
    public bool upgrade2bought;

    public int maxhealth = 5;
    public bool upgrade3bought;

    [Header("Money")]
    public int money;
}

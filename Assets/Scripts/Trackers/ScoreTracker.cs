using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreTracker", menuName = "ScoreTracker")]
public class ScoreTracker : ScriptableObject
{
    // hunting scoring
    public int mantiscore;
    public int plantscore;
    public int hornetscore;

    // cooking scoring
    public int choppingscore;
    public int stirringscore;
    public int skillcheckscore;
}

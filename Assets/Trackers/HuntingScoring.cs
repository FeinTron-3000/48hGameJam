using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HuntingScoring", menuName = "HuntingScoring")]
public class HuntingScoring : ScriptableObject
{
    [SerializeField] public int mantiscore;
    [SerializeField] public int plantscore;
    [SerializeField] public int hornetscore;
}

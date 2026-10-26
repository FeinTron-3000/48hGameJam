using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CookingScoring", menuName = "CookingScoring")]
public class CookingScoring : ScriptableObject
{
    [SerializeField] public int choppingscore;
    [SerializeField] public int stirringscore;
    [SerializeField] public int skillcheckscore;
}

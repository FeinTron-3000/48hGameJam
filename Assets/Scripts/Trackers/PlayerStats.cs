using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Player Stats")]
    public float movespeed = 10;
    public float jumppower = 10;
    public float dashpower = 20;

    public int damage = 1;

    public float dashingtime = 0.2f;
    public float dashcooldown = 1;

    [Header("Money")]
    public int money;
}

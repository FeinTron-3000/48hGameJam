using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StirringSpawner : MonoBehaviour
{
    [Header("Button")]
    public GameObject button;

    void Update()
    {
        // if button is pressed, respawn it
        if (button.activeInHierarchy == false)
        {
            button.SetActive(true);
        }
    }
}

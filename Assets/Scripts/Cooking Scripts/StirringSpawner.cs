using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StirringSpawner : MonoBehaviour
{
    [Header("Button")]
    public GameObject button;

    public float respawntime;
    bool respawning = false;

    void Update()
    {
        // if button is pressed, respawn it
        if (button.activeInHierarchy == false && !respawning)
        {
            respawning = true;

            StartCoroutine(Respawn());
        }
    }
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawntime);

        respawning = false;

        button.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StirringSpawner : MonoBehaviour
{
    [Header("Game Manager")]
    public GMCookingScene gm;

    [Header("Target")]
    public GameObject target;

    public float respawntime;
    bool respawning = false;

    void Start()
    {
        gm = gm.GetComponent<GMCookingScene>();
    }

    void Update()
    {
        // do not play 
        if (!gm.gameisrunning)
        {
            target.SetActive(false);

            return;
        }

        // if button is pressed, respawn it
        if (target.activeInHierarchy == false && !respawning)
        {
            respawning = true;

            StartCoroutine(Respawn());
        }
    }
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawntime);

        respawning = false;

        target.SetActive(true);
    }
}

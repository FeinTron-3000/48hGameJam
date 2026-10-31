using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Stirring : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private int currentscore;
    [SerializeField] public float spawnspeed;

    [SerializeField] public GMCookingScene gm;

    void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();

        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Debug.Log("Spawn");
        target.SetActive(true);
        yield return new WaitForSeconds(spawnspeed);
        StartCoroutine(spawn());
    }
}

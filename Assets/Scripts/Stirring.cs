using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stirring : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject[] newtargets;
    [SerializeField] public int index;
    [SerializeField] private int currentscore;
    [SerializeField] public float spawnspeed;

    [SerializeField] public GMCookingScene gm;

    void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();

        index = 0;
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        newtargets[index].SetActive(true);
        yield return new WaitForSeconds(spawnspeed);

        // add if statement for game continuing
        StartCoroutine(spawn());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(die());
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

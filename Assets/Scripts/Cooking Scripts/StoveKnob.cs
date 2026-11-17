using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnob : MonoBehaviour
{
    [Header("Variables")]
    public float speed;
    public float reversespeed;

    public bool direction;

    [Header("Buttons")]
    public GameObject goodbutton;
    public GameObject badbutton;

    void Update()
    {
        // change direction
        if (direction)
        {
            // spin
            transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
        }
        else
        {
            // spin
            transform.eulerAngles += Vector3.forward * reversespeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        goodbutton.SetActive(true);

        badbutton.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        goodbutton.SetActive(false);

        badbutton.SetActive(true);
    }
}

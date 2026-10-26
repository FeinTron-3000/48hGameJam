using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public bool clickready;
    public float speed;
    public float difficulty;

    public GameObject button;

    private void Update()
    {
        transform.eulerAngles += Vector3.forward * speed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        clickready = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        clickready = false;
    }
}

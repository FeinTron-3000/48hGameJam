using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public bool clickready;
    public float speed;
    public float difficulty;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.right * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        clickready = true;
        StartCoroutine(SetFalse());
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(difficulty);
        clickready = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 startPos;
    public Vector3 endPos;

    private Vector3 targetPos;

    private void Awake()
    {
        targetPos = startPos;
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        if(currentPos == startPos)
        {
            targetPos = endPos;
        }
        else if (currentPos == endPos)
        {
            targetPos = startPos;
        }

        Vector3 targetDirection = (currentPos - targetPos).normalized;
        rb.MovePosition(targetPos + targetDirection * Time.deltaTime);
    }
}

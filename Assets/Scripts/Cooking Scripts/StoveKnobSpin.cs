using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnobSpin : MonoBehaviour
{
    [Header("Variables")]
    public float speed;

    void Update()
    {
        // spin
        transform.eulerAngles += Vector3.forward * -speed * Time.deltaTime;
    }
}

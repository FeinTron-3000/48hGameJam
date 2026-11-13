using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRandomizer : MonoBehaviour
{
    [Header("Variables")]
    public GameObject trigger;

    public Transform[] transforms;

    public void OnMouseDown()
    {
        // randomize next trigger location
        int Index = Random.Range(0, transforms.Length);
        trigger.transform.position = new Vector3(transforms[Index].transform.position.x, transforms[Index].transform.position.y, 0);
    }
}

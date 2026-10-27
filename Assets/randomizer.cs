using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizer : MonoBehaviour
{
    public GameObject trigger;
    public Transform[] transforms;
    private int Index;
    // Start is called before the first frame update

    public void OnMouseDown()
    {
        Debug.Log("BOOYAH");
        int Index = Random.Range(0, transforms.Length);
        trigger.transform.position = new Vector3(transforms[Index].transform.position.x, transforms[Index].transform.position.y, 0);
    }
}

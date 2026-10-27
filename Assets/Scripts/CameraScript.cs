using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] public GameObject player;
    [SerializeField] public float distance;

    public float maxx;
    public float maxy;

    public float x;
    public float y;

    void Update()
    {
        // check the player is alive
        if (player != null)
        {
            if (player.transform.position.x > maxx)
            {
                 x = player.transform.position.x;
            }
            if (player.transform.position.y > maxy)
            {
                y = player.transform.position.y;
                transform.position = new Vector3(x, y, distance);
            }
            else
            {
                y = player.transform.position.y;
                transform.position = new Vector3(x, 0, distance);
            }
        }
    }
}

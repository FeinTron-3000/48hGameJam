using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] public GameObject player;
    [SerializeField] public float distanceup;
    [SerializeField] public float distance;

    void Update()
    {
        // check the player is alive
        if (player != null)
        {
            // follow the player character's position
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distanceup, distance);
        }
    }
}

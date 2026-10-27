using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public GameObject player;
    public bool playeronright;
    [SerializeField] public Rigidbody2D rb;

    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                playeronright = true;
                rb.AddForce(Vector2.right * movespeed * Time.deltaTime, ForceMode2D.Force);

            }
            else
            {
                playeronright = false;
                rb.AddForce(Vector2.left * movespeed * Time.deltaTime, ForceMode2D.Force);
            }

            if (rb.velocity.magnitude > maxspeed)
            {
                rb.velocity = rb.velocity.normalized * maxspeed;
            }
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] public float movespeed;
    [SerializeField] public KeyCode moveright;
    [SerializeField] public KeyCode moveleft;
    [SerializeField] public float maxspeed;

    [SerializeField] public float jumppower;
    [SerializeField] public KeyCode jump;
    [SerializeField] private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveright))
        {
            MoveRight();
        }
        if (Input.GetKey(moveleft))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(jump))
        {
            Jump();
        }
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
    }

    void MoveRight()
    {
        rb.AddForce(Vector2.right * movespeed, ForceMode2D.Force);
    } 
    void MoveLeft()
    {
        rb.AddForce(Vector2.left * movespeed, ForceMode2D.Force);
    }
    void Jump()
    {
        if (CheckForGround())
        {
            rb.AddForce(Vector2.up * jumppower, ForceMode2D.Force);
        }
    }

    private bool CheckForGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, LayerMask.GetMask("Ground"));
    }
}

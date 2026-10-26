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
    [SerializeField] bool grounded;
    [SerializeField] bool doublejump;

    void Update()
    {
        // movement
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

        // limit speed
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
    }

    // movement
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
            doublejump = true;
            rb.AddForce(Vector2.up * jumppower, ForceMode2D.Force);
        }
        else if (doublejump)
        {
            doublejump = false;
            // smaller jump
            rb.AddForce(Vector2.up * jumppower * 0.5f, ForceMode2D.Force);
        }
    }

    // ground detection
    private bool CheckForGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
    }

    // death
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Add Juice");
            Destroy(gameObject);
        }
    }
}

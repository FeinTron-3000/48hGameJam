using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private Animator animator;

    [SerializeField] public float movespeed;
    [SerializeField] public KeyCode moveright;
    [SerializeField] public KeyCode moveleft;
    [SerializeField] public float maxspeed;

    [SerializeField] public float jumppower;
    [SerializeField] public KeyCode jump;
    [SerializeField] bool grounded;
    [SerializeField] bool doublejump;

    public Transform attackPoint;
    public float weaponRage;
    public LayerMask enemyLayer;
    public int damnage = 1;

    public PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = playerAttack.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        // movement
        if (Input.GetKey(moveright))
        {
            MoveRight();
        }
        else if (Input.GetKey(moveleft))
        {
            MoveLeft();
        }
        else
        {
            animator.SetBool("isWalking", false);
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

        if (Input.GetMouseButtonDown(0))
        {
            playerAttack.Attack();
        }
    }

    // movement
    void MoveRight()
    {
        rb.AddForce(Vector2.right * movespeed, ForceMode2D.Force);
        animator.SetBool("isWalking", true);
    } 
    void MoveLeft()
    {
        rb.AddForce(Vector2.left * movespeed, ForceMode2D.Force);
        animator.SetBool("isWalking", true);
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
}

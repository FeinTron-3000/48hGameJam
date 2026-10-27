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
    [SerializeField] public float gravityscale;
    [SerializeField] public float fallinggravityscale;

    public GameObject attackPoint;
    public float weaponRage;
    public LayerMask enemyLayer;
    public int damnage = 1;

    //Dash 
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    private float dashingTime = 0.2f;
    public float dashCooldown = 0.2f;

    public PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = playerAttack.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        // movement
        if (Input.GetKey(moveright))
        {
            transform.localScale = new Vector3(5, 5, 0);
            MoveRight();
        }
        else if (Input.GetKey(moveleft))
        {
            transform.localScale = new Vector3(-5, 5, 0);
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
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityscale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallinggravityscale;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            playerAttack.Attack();
        }
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    
    private void LateUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (CheckForGround())
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Land", true);
        }
        else
        {
            animator.SetBool("Land", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", false);
        }
    }

    // movement
    void MoveRight()
    {
        if (rb.velocity.magnitude < maxspeed)
        {
            rb.AddForce(Vector2.right * movespeed, ForceMode2D.Force);
        }

        animator.SetBool("isWalking", true);
    } 
    void MoveLeft()
    {
        if (rb.velocity.magnitude < maxspeed)
        {
            rb.AddForce(Vector2.left * movespeed, ForceMode2D.Force);
        }
        animator.SetBool("isWalking", true);
    }
    void Jump()
    {
        if (CheckForGround())
        {
            animator.SetBool("Land", false);
            animator.SetBool("Jump", true);
            doublejump = true;
            rb.AddForce(Vector2.up * jumppower, ForceMode2D.Force);
        }
        else
        {
            if (doublejump)
            {
                doublejump = false;
                // smaller jump
                rb.AddForce(Vector2.up * jumppower * 0.5f, ForceMode2D.Force);
            }
        }
    }

    //Dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        animator.SetBool("isDashing", true);
        yield return new WaitForSeconds(dashingTime);
        animator.SetBool("isDashing", false);
        rb.gravityScale *= originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    // ground detection
    private bool CheckForGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
    }
}

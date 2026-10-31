using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Player Movement")]
    public KeyCode moveright;
    public KeyCode moveleft;
    public KeyCode jump;
    public KeyCode dash;

    [Header("Movement Variabes")]
    public float movespeed;
    public float jumppower;
    public float dashpower;

    [Header("Dashing")]
    [SerializeField] private bool playerismoving;
    [SerializeField] private bool candash;
    [SerializeField] private bool isdashing;
    public float dashingtime;
    public float dashcooldown;

    [Header("Jumping")]
    [SerializeField] private bool grounded;
    [SerializeField] private bool doublejump;
    public float gravityscale;
    public float fallinggravityscale;

    [Header("Attacking")]
    public GameObject attackpoint;
    public LayerMask enemylayer;
    public float weaponrage;
    public int damage;

    public PlayerAttack playerAttack;

    [Header("Audio")]
    public AudioSource jumpsound;
    public AudioSource dashsound;
    public AudioSource swordsound;
    public AudioSource walksound;

    [Header("Animator")]
    public Animator animator;

    private void Start()
    {
        playerAttack = playerAttack.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        // player movement
        if (Input.GetKey(moveright))
        {
            // flip direction facing
            transform.localScale = new Vector3(5, 5, 0);

            MoveRight();
            playerismoving = true;
        }
        else if (Input.GetKey(moveleft))
        {
            // flip direction facing
            transform.localScale = new Vector3(-5, 5, 0);

            MoveLeft();
            playerismoving = true;
        }
        else
        {
            walksound.Play();
            animator.SetBool("isWalking", false);

            playerismoving = false;
        }


        if (Input.GetKeyDown(jump))
        {
            jumpsound.Play();
            Jump();
        }
        // adjust gravity for jumping 
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
            swordsound.Play();
            animator.SetBool("Attack", true);
            playerAttack.Attack();
        }

        if (Input.GetKey(dash) && candash)
        {
            dashsound.Play();
            StartCoroutine(Dash());
        }
    }

    private void LateUpdate()
    {
        // stop animations from playing
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

    void MoveRight()
    {
        transform.Translate(Vector2.right * movespeed * Time.deltaTime);

        animator.SetBool("isWalking", true);
    }
    void MoveLeft()
    {
        transform.Translate(Vector2.left * movespeed * Time.deltaTime);

        animator.SetBool("isWalking", true);
    }

    void Jump()
    {
        if (CheckForGround())
        {
            animator.SetBool("Land", false);
            animator.SetBool("Jump", true);

            doublejump = true;

            rb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
        }
        else
        {
            if (doublejump)
            {
                doublejump = false;

                // smaller jump
                rb.AddForce(Vector2.up * jumppower * 0.5f, ForceMode2D.Impulse);
            }
        }
    }

    private IEnumerator Dash()
    {
        if (playerismoving)
        {
            candash = false;
            isdashing = true;
            float originalspeed = movespeed;

            // dash
            movespeed = dashpower;
            animator.SetBool("isDashing", true);

            // stop dash
            yield return new WaitForSeconds(dashingtime);
            animator.SetBool("isDashing", false);
            isdashing = false;
            movespeed = originalspeed;

            // reset dash
            yield return new WaitForSeconds(dashcooldown);
            candash = true;
        }
    }

    // ground detection
    private bool CheckForGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
    }
}

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

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRage, enemyLayer);
        Debug.Log("Hit enemy");
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().TakeDamnge(damnage);
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
}

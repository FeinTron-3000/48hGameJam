using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Variables")]
    public float movespeed;
    public float maxspeed;

    [Header("Player")]
    public GameObject player;

    [Header("Scripts")]
    public EnemyHealth health;
    public EnemyAttack attack;

    [Header("Audio")]
    public AudioSource mantiswalk;

    [Header("Animator")]
    public Animator animator;


    void Start()
    {
        health = health.GetComponent<EnemyHealth>();
        attack = attack.GetComponent<EnemyAttack>();
    }

    void Update()
    {
        // dont move if player is dead
        if (player == null)
        {
            animator.SetBool("Walk", false);
            mantiswalk.Stop();
            rb.velocity = Vector3.zero;

            return;
        }

        // dont move if enemy is dead
        if (health.isdead)
        {
            animator.SetBool("Walk", false);
            mantiswalk.Stop();
            rb.velocity = Vector3.zero;

            return;
        }

        if (health.agrivated && !attack.attacking)
        {
            animator.SetBool("Walk", true);
            if (player.transform.position.x > transform.position.x)
            {
                // flip direction facing
                transform.localScale = new Vector3(-8, 8, 1);

                rb.AddForce(Vector2.right * movespeed * Time.deltaTime, ForceMode2D.Force);
            }
            else
            {
                // flip direction facing
                transform.localScale = new Vector3(8, 8, 1);

                rb.AddForce(Vector2.left * movespeed * Time.deltaTime, ForceMode2D.Force);
            }

            if (rb.velocity.magnitude > maxspeed)
            {
                rb.velocity = rb.velocity.normalized * maxspeed;
            }
        }
        else
        {
            mantiswalk.Play();
            rb.velocity = Vector3.zero;
        }
    }
}

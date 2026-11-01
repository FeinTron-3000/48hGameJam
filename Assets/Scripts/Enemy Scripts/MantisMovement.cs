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
    public MantisAttack attack;

    [Header("Audio")]
    public AudioSource mantiswalk;
    private bool firstplay;

    [Header("Animator")]
    public Animator animator;


    void Start()
    {
        health = health.GetComponent<EnemyHealth>();
        attack = attack.GetComponent<MantisAttack>();
    }

    void Update()
    {
        // dont move if player is dead
        if (player == null)
        {
            animator.SetBool("Walk", false);
            mantiswalk.Stop();

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

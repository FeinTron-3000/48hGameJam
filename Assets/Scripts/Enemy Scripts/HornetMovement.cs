using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public GameObject player;
    public bool playeronright;
    [SerializeField] public Rigidbody2D rb;

    public bool mantis;
    public bool plant;
    public bool hornet;

    [SerializeField] private Animator animator;

    public EnemyHealth health;

    public float maxspeed;

    public HornetAttack attack;
    public bool startattack = false;

    public bool endattack;
    public float range;
    public AudioSource mantiswalk;
    public AudioSource hornetbuzz;


    void Start()
    {
        health = health.GetComponent<EnemyHealth>();
        attack = attack.GetComponent<HornetAttack>();
    }

    void Update()
    {
        
        if (plant)
        {
            if (player != null)
            {
                animator.SetBool("Idle", true);
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
        else if (hornet)
        {
            hornetbuzz.Play();
            if (player != null)
            {
                hornetbuzz.Play();
                animator.SetBool("Idle", true);
                if (player.transform.position.x > transform.position.x - range)
                {
                    hornetbuzz.Play();
                    if (player.transform.position.x > transform.position.x)
                    {
                        hornetbuzz.Play();
                        playeronright = true;
                        rb.AddForce(Vector2.right * movespeed * Time.deltaTime, ForceMode2D.Force);

                    }

                    else
                    {
                        hornetbuzz.Play();
                        playeronright = false;
                        rb.AddForce(Vector2.left * movespeed * Time.deltaTime, ForceMode2D.Force);
                    }

                    if (rb.velocity.magnitude > maxspeed)
                    {
                        hornetbuzz.Play();
                        rb.velocity = rb.velocity.normalized * maxspeed;
                    }
                }
                else if (player.transform.position.x > transform.position.x - range)
                {
                    hornetbuzz.Play();
                    if (player.transform.position.x > transform.position.x)
                    {
                        hornetbuzz.Play();
                        playeronright = true;
                        rb.AddForce(Vector2.right * movespeed * Time.deltaTime, ForceMode2D.Force);

                    }

                    else
                    {
                        hornetbuzz.Play();
                        playeronright = false;
                        rb.AddForce(Vector2.left * movespeed * Time.deltaTime, ForceMode2D.Force);
                    }

                    if (rb.velocity.magnitude > maxspeed)
                    {
                        hornetbuzz.Play();
                        rb.velocity = rb.velocity.normalized * maxspeed;
                    }
                }
            }
        }
    }


}

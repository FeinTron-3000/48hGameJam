using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public GameObject player;
    public bool playeronright;
    [SerializeField] public Rigidbody2D rb;

    public bool mantis;
    public bool plant;
    public bool hornet;

    [SerializeField] private Animator animator;

    public EnemyHealth script;

    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {
        script = script.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // mantis idle
        if (mantis)
        {
            if (script.agrivated == true && script.attacking == false)
            {
                if (player != null)
                {
                    animator.SetBool("Walk", true);
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
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
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

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [Header("Game Manager")]
    public GMCookingScene gm;

    [Header("Variables")]
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float maxx;
    public float maxy;
    public float minx;
    public float miny;

    public bool chopready;

    [Header("Animator")]
    public Animator animator;
    public Animator mantisanimator;

    [Header("Audio")]
    public AudioSource chop;

    void Start()
    {
        gm = gm.GetComponent<GMCookingScene>();
    }

    void Update()
    {
        // do not play 
        if (!gm.gameisrunning)
        {
            return;
        }

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // track to mouse position if within range
        if (mousePosition.x > minx)
        {
            if (mousePosition.x < maxx)
            {
                if (mousePosition.y > miny)
                {
                    if (mousePosition.y < maxy)
                    {
                        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ChopTrigger"))
        {
            if (chopready)
            {
                gm.score += 1;

                chopready = false;

                chop.Play();    
                animator.SetBool("Chop", true);

                mantisanimator.SetBool("Chop", true);
                StartCoroutine(PlayAnimation());
            }
        }

        if (collision.CompareTag("KnifeReset"))
        {
            chopready = true;

            animator.SetBool("Chop", false);
        }
    }

    public IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.2f);

        mantisanimator.SetBool("Chop", false);
    }
}

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

    public bool chopready;

    [Header("Animator")]
    public Animator animator;

    private void Start()
    {
        gm = gm.GetComponent<GMCookingScene>();
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ChopTrigger"))
        {
            if (chopready)
            {
                gm.score += 1;

                chopready = false;
                animator.SetBool("Chop", true);
            }
        }

        if (collision.CompareTag("KnifeReset"))
        {
            chopready = true;

            animator.SetBool("Chop", false);
        }
    }
}

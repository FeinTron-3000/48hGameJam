using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public GameObject player;
    public bool playeronright;
    [SerializeField] public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                Debug.Log("right");
                playeronright = true;
                rb.AddForce(Vector2.right * movespeed * Time.deltaTime, ForceMode2D.Impulse);

            }
            else
            {
                Debug.Log("left");
                playeronright = false;
                rb.AddForce(Vector2.left * movespeed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
    private bool CheckForGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnobScript : MonoBehaviour
{
    [Header("Variables")]
    public GMCookingScene gm;

    public int index = 0;

    public AudioSource click;

    void Start()
    {
        gm = gm.GetComponent<GMCookingScene>();
    }

    void Update()
    {
        // face towards mouse
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FryingCheckpoint1"))
        {
            if (index == 0)
            {
                index = 1;
            }
        }
        if (collision.CompareTag("FryingCheckpoint2"))
        {
            if (index == 1)
            {
                index = 2;
            }
        }

        if (collision.CompareTag("FryingCheckpoint3"))
        {
            if (index == 2)
            {
                gm.score++;

                index = 0;

                click.Play();
            }
        }
    }
}

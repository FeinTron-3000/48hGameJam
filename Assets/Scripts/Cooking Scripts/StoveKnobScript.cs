using System.Collections;

using UnityEngine;

public class StoveKnobScript : MonoBehaviour
{
    [Header("Variables")]
    public float speed;

    public float speeddec;
    public float speedinc;

    public float maxspeed;
    public float minspeed;

    [Header("Scripts")]
    public GMCookingScene gm;

    [Header("Audio")]
    public AudioSource cick;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }

    void Update()
    {
        // spin
        transform.eulerAngles += Vector3.forward * -speed * Time.deltaTime;

        // do not play 
        if (!gm.gameisrunning)
        {
            return;
        }

        if (speed <= minspeed)
        {
            speed = minspeed;
        }
        else
        {
            speed -= speeddec * Time.deltaTime;
        }
    }

    public void OnMouseDown()
    {
        // do not play 
        if (!gm.gameisrunning)
        {
            return;
        }

        cick.Play();

        gm.score++;

        SpeedUp();
    }

    public void SpeedUp()
    {
        if (speed < maxspeed)
        {
            speed += speedinc;
        }
    }
}

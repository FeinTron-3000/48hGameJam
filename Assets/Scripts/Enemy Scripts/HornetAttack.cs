using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HornetAttack : MonoBehaviour
{
    [Header("Variabes")]
    public GameObject enemy;
    public GameObject player;
    public PlayerHealth playerhealth;

    public float y;
    public float x;

    [Header("Sprite")]
    public GameObject sprite;

    [Header("Attack")]
    public float attackspeed;
    public float relativeattackspeedy;
    public float relativeattackspeedx;

    public int damage;
    public bool agrivated;

    void Start()
    {
        playerhealth = playerhealth.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // move towards the players last position
        transform.Translate(x * relativeattackspeedx * Time.deltaTime, y * relativeattackspeedy * Time.deltaTime, 0);
    }

    public void BecomeVisible()
    {
        transform.position = enemy.transform.position;

        // make the target aim for the players current position

        // if player is below hornet equals negitive
        if (player.transform.position.y <= transform.position.y)
        {
            y = -transform.position.y + player.transform.position.y;
        }
        // if player is above hornet equals positive
        else if (player.transform.position.y >= transform.position.y)
        {
            y = player.transform.position.y - transform.position.y;
        }

        // if player is on hornet right
        if (player.transform.position.x >= transform.position.x)
        {
            x = player.transform.position.x - transform.position.x;
        }
        // if player is on hornet left
        else if (player.transform.position.x <= transform.position.x)
        {
            x = player.transform.position.x - transform.position.x;
        }

        Debug.Log("Fix relative speed in gornet attack script");
        // don't change speed based on distance
        if (x <= 0)
        {
            relativeattackspeedx = attackspeed + x * 0.01f;
        }
        else
        {
            relativeattackspeedx = attackspeed - x * 0.01f;
        }

        if (y <= 0)
        {
            relativeattackspeedy = attackspeed + y * 0.01f;
        }
        else
        {
            relativeattackspeedy = attackspeed - y * 0.01f;
        }

        // face spike towards player
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    // do damage on hit
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealth.TakeDamage(damage);

            // don't let the player get hit twice
            gameObject.SetActive(false);
        }
    }
}

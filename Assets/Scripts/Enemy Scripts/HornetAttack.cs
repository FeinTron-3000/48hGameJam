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

    public int damage;
    public bool agrivated;

    void Start()
    {
        playerhealth = playerhealth.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // move towards the players last position
        transform.Translate(Vector2.up * attackspeed * Time.deltaTime);
    }

    public void BecomeVisible()
    {
        transform.position = enemy.transform.position;

        // face spike towards player
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
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

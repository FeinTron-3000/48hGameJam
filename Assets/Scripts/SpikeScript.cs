using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpikeScript : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public float spikespeed;
    public int damnage;


    private void Update()
    {
        transform.position = transform.position + Vector3.MoveTowards(transform.position, target.transform.position, spikespeed * Time.deltaTime);
    }
    private void OnBecameVisible()
    {
        transform.position = player.transform.position;
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            Debug.Log("hit");
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(damnage);
            }
            gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.EventSystems;

public class StirringTarget : MonoBehaviour
{
    [Header("Scripts")]
    public GMCookingScene gm;

    [Header("Button Randomizer")]
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;

    public float minsize;
    public float maxsize;

    [Header("Animator")]
    public Animator animator;

    public Collider2D buttoncollision;

    [Header("Audio")]
    public AudioSource buttonpress;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }

    public void OnMouseDown()
    {
        animator.SetBool("Mash", true);
        buttonpress.Play();

        // don't allow for multiple clicks
        buttoncollision.enabled = false;

        StartCoroutine(Stop());

        // increase score
        gm.score++;
    }

    private void OnEnable()
    {
        buttoncollision.enabled = true;

        // randomize position
        float x = Random.Range(minx, maxx);
        float y = Random.Range(miny, maxy);
        transform.position = new Vector3(x, y, 0);

        // randomize size
        float size = Random.Range(minsize, maxsize);
        transform.localScale = new Vector3(size, size, size);
    }

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Mash", false);
        gameObject.SetActive(false);
    }
}
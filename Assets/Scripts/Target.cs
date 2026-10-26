using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public GMCookingScene gm;
    [SerializeField] public Stirring stirringscript;

    [Header("Stirring Mode")]
    [SerializeField] public float minx;
    [SerializeField] public float maxx;
    [SerializeField] public float miny;
    [SerializeField] public float maxy;

    [SerializeField] public float minsize;
    [SerializeField] public float maxsize;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
        stirringscript = stirringscript.gameObject.GetComponent<Stirring>();
    }

    private void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // increase score
            gm.score++;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        float x = Random.Range(minx, maxx);
        float y = Random.Range(miny, maxy);
        transform.position = new Vector3(x, y, 0);
        float size = Random.Range(minsize, maxsize);
        transform.localScale = new Vector3(size, size, size);
    }
}
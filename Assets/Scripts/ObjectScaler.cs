using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    // Scaling setting
    public float shrinkSpeed = 0.5f;
    public float growSpeed = 0.5f;
    public float minScale = 0.1f;
    public float maxScale = 1f;

    public GameObject triggerObject;

    private bool isGrowing = false;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrowing)
        {
            if (transform.localScale.x > minScale)
            {
                transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            }
            else
            {
                if (transform.localScale.x < maxScale)
                {
                    transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
                }
                else
                {
                    isGrowing = false;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == triggerObject)
            {
                isGrowing = true;
            }
        }
    }
}

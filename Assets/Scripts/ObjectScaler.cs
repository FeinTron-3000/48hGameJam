using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    // Scaling setting
    public float shrinkSpeed;
    public float growSpeed;
    public float minScale;
    public float maxScale;
    public float waitTime;

    public GameObject triggerObject;

    public bool isGrowing = false;
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
                transform.localScale -= Vector3.one * shrinkSpeed *Time.deltaTime;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == triggerObject)
            {

                StartCoroutine(Grow());
            }
        }
    } 

    IEnumerator Grow()
    {
        if (transform.localScale.x < maxScale)
        {
            isGrowing = true;
            transform.localScale += Vector3.one * growSpeed;
            yield return new WaitForSeconds(waitTime);
            isGrowing = false;
        }
    }
}

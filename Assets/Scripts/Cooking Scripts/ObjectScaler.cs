using System.Collections;

using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [Header("Variables")]
    public float shrinkspeed;
    public float growspeed;

    public float minScale;
    public float maxScale;

    public bool isGrowing;

    [Header("Scripts")]
    public GMCookingScene gm;

    [Header("Animators")]
    public Animator knifemantis;
    public Animator button;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
    }

    void Update()
    {
        // shrink
        if (!isGrowing)
        {
            if (transform.localScale.x > minScale)
            {
                transform.localScale -= Vector3.one * shrinkspeed * Time.deltaTime;
            }
        }
    }

    public void OnMouseDown()
    {
        // increase score
        knifemantis.SetBool("Chop", true);
        button.SetBool("Mash", true);

        gm.score++;

        StartCoroutine(Grow());
        StartCoroutine(AnimationPlay());
    }

    public IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.01f);

        knifemantis.SetBool("Chop", false);
        button.SetBool("Mash", false);

    }

    IEnumerator Grow()
    {
        if (transform.localScale.x < maxScale)
        {
            Debug.Log("Grow input delay?");

            isGrowing = true;
            transform.localScale += Vector3.one * growspeed;

            yield return new WaitForSeconds(0.01f);

            isGrowing = false;
        }
    }
}

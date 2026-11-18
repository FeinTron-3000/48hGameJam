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
    public StoveKnobSpin stoveknob;

    [Header("Animators")]
    public Animator button;

    [Header("Audio")]
    public AudioSource cick;

    private void Start()
    {
        gm = gm.gameObject.GetComponent<GMCookingScene>();
        stoveknob = stoveknob.GetComponent<StoveKnobSpin>();
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
        button.SetBool("Mash", true);

        gm.score++;

        StartCoroutine(Grow());
        StartCoroutine(AnimationPlay());
    }

    public IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.01f);

        button.SetBool("Mash", false);

        cick.Play();
    }

    IEnumerator Grow()
    {
        if (transform.localScale.x < maxScale)
        {
            isGrowing = true;
            transform.localScale += Vector3.one * growspeed;

            stoveknob.speed += growspeed;

            yield return new WaitForSeconds(0.01f);

            isGrowing = false;
        }
    }
}

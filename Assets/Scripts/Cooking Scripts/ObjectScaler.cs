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
        cick.Play();

        gm.score++;

        StartCoroutine(Grow());
        StartCoroutine(AnimationPlay());
    }

    public IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(0.01f);

        button.SetBool("Mash", false);
    }

    IEnumerator Grow()
    {
        if (transform.localScale.x < maxScale)
        {
            isGrowing = true;
            transform.localScale += Vector3.one * growspeed;

            // increase stove knob speed
            stoveknob.speed += growspeed / 2;

            yield return new WaitForSeconds(0.01f);

            isGrowing = false;
        }
    }
}

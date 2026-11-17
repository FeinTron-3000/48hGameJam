using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [Header("Sprite")]
    public GameObject sprite;

    [Header("Variabes")]
    public bool transitionout;
    public float speed;

    public float maxsize;
    public float minsize;

    void Start()
    {
        sprite.gameObject.SetActive(true);

        transitionout = false;
    }

    void Update()
    {
        // don't change transformation if not active
        if (!sprite.activeInHierarchy)
        {
            return;
        }

        if (!transitionout)
        {
            sprite.transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }
        else
        {
            sprite.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }

        if (sprite.transform.localScale.x <= minsize)
        {
            sprite.gameObject.SetActive(false);

            transitionout = true;
        }
    }

    public void QueueSceneChange()
    {
        sprite.gameObject.SetActive(true);
    }
}

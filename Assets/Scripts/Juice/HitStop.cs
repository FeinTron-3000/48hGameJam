using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    public static HitStop instance;

    bool waiting = false;

    private void OnEnable()
    {
        instance = this;
    }

    public void Stop(float duration, float timeScale)
    {
        if (waiting)
        {
            return;
        }
            
        Time.timeScale = timeScale;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1.0f;
        waiting = false;
    }
}
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Transform sprite;
    public float transitionlength;

    private TransitionType transType;

    public static TransitionManager instance;

    public enum TransitionType
    {
        T_In,
        T_Out
    }

    private void Start()
    {
        sprite.gameObject.SetActive(true);
        Transition(TransitionType.T_In);
    }

    private void OnEnable()
    {
        instance = this;
    }

    private void Update()
    {
        float targetScale = transType == TransitionType.T_In ? 0 : 10.0f;
        sprite.localScale = Vector3.Lerp(sprite.localScale, new Vector3(targetScale, targetScale, 1), transitionlength / 100);
    }


    public void Transition(TransitionType type)
    {
        float targetScale = (type == TransitionType.T_In ? 10.0f : 0.0f);
        sprite.localScale = new Vector3(targetScale, targetScale, 1);

        transType = type;
    }

    public void QueueSceneChange(int sceneIndex)
    {
        Transition(TransitionType.T_Out);

        this.Invoke("SceneManager.LoadScene(sceneIndex)", 0.7f);
    }
}

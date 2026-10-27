using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainMenu : MonoBehaviour
{
    public string startlevel;
    [SerializeField] private Animator bganim;

    // Scaling setting

    public GameObject Bg;

    public void OnMouseDown()
    {
        bganim.SetBool("Transition", true);
        StartCoroutine(GameStart());
    }
    public IEnumerator GameStart()
    {
        Debug.Log("hit");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(startlevel);
    }
}

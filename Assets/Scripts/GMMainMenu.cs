using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainMenu : MonoBehaviour
{
    public string startlevel;
    public void GameStart()
    {
        Debug.Log("hit");
        SceneManager.LoadScene(startlevel);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GMCookingScene : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public TextMeshProUGUI scoreui;

    [SerializeField] public CookingScoring cookingScoring;
    [SerializeField] public string nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreui.text = "Score: " + score;
    }

    public void GameOver()
    {
        // scriptable object equal level score
        cookingScoring.choppingscore = score;

        SceneManager.LoadScene(nextlevel);
    }
}

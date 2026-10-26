using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    [SerializeField] public GameObject[] gameplaymode;
    [SerializeField] public int index;
    [SerializeField] public GameObject currentgame;

    [SerializeField] public bool gameactive;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        currentgame = GameObject.Instantiate(gameplaymode[index]);
        gameactive = true;
    }  
}

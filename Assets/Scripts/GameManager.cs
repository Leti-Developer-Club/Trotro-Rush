using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameStarted = false;
    public bool gameover = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartGame()
    {
        gameStarted = true;
        Debug.Log("Game Started!");
        gameover = false;
        // Start spawning, timer, etc.
    }
    public void EndGame()
    {
        gameover = true;
      
    }
}

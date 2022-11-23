using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text KNameText;
    private bool gameEnded = false;

    private void Start()
    {
        KNameText.text =PlayerPrefs.GetString("nameTextKey");
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            SceneManager.LoadScene("GameOver");
        }
        
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
        
    }
}

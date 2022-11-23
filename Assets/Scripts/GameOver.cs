using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    private int rounds;
    private void OnEnable()
    {
        rounds = PlayerStats.Rounds - 1;
        if (rounds < 0)
        {
            rounds = 0;
            roundsText.text = rounds.ToString();
        }
        else
        {
            roundsText.text = rounds.ToString();
        }
        
    }
}

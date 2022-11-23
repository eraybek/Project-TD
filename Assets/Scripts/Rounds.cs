using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    public Text roundsText;
    void Start()
    {
        roundsText.text = PlayerPrefs.GetInt("roundsKey").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

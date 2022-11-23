using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuControl : MonoBehaviour
{
    private string nameText;
    private string kingdom;
    public TMP_Text kingdomScene1;
    public TMP_InputField kingdomName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeName()
    {
        nameText = kingdomName.text;
        PlayerPrefs.SetString("nameTextKey",nameText);
        SceneManager.LoadScene("Scene_1");

    }
    
    
    
}

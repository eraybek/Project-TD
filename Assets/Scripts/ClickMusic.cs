using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMusic : MonoBehaviour
{
    public Text dialogueText;
    public AudioSource _audio;
    
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            _audio.Play();
            yield return null;
        }
    }
}

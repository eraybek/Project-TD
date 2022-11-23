using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public DefenderBlueprint standardDefender;
    public DefenderBlueprint anotherDefender;

    BuildManager buildManager;

    public AudioSource clickAudio;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardDefender()
    {
        clickAudio.Play();
        Debug.Log("Standart DefenderChar1 Purchased!");
        buildManager.SelectDefenderToBuild(standardDefender);
    }
    
    public void SelectAnotherDefender()
    {
        clickAudio.Play();
        Debug.Log("Standart DefenderChar2 Purchased!");
        buildManager.SelectDefenderToBuild(anotherDefender);
    }
}

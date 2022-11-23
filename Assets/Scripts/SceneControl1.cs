using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
public class SceneControl1 : MonoBehaviour
{
    //public GameObject enemyPrefab;
    //private GameObject enemy; 
    //public float speed = 1.0f;
    //public GameObject[] waypoints;

    public void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void doExitGame() {
        Debug.Log("Exiting the Game");
        Application.Quit();
    }

    //void Start()
    //{
    //    InvokeRepeating("EnemySpawn", 3, 3);
    //}

    void Update()
    {
        
    }

    //private void EnemySpawn()
    //{
    //    enemy = Instantiate(enemyPrefab, waypoints[0].transform.position, Quaternion.identity);
    //}
    
    

}

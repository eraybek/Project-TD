using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    private GameObject[] enemies;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    private int waveTime;
    public Text wave;
    
    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    private int waveIndex = 0;
    public int waveCount = 5;

    private void Start()
    {
        waveTime = waveCount;
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        wave.text = "Round: " + waveTime;

        if (waveTime > 0)
        {
            if (countdown <= 0f)
            {

                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;


            }

            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            waveCountdownText.text = string.Format("{0:00.00}", countdown);
            

        }
        
                
        if (PlayerStats.Lives > 0 && waveTime == 0 && enemies.Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        waveTime = waveCount-waveIndex;
        PlayerStats.Rounds++;
        
        if (waveTime >= 0)
        {
            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            
        }



    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

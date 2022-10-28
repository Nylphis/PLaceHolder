using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public int enemiesCheck = 0;

    
    public static int enemiesAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countDown = 2f;

    public TextMeshProUGUI waveCountdownText;
    public GameManager gameManager;

    private int waveIndex = 0;

    private void Update() 
    {
        enemiesCheck = enemiesAlive;

        if(enemiesAlive > 0)
        {
            return;
        }

        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWaves());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countDown);
        //waveCountdownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWaves()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++){
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy){
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}

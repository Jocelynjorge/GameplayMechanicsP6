using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
       

    }

    // Update is called once per frame
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave (int enemiesToSpawn)
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        {
            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(),
                enemyPrefab[randomEnemy].transform.rotation);
        }
    }
     void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount ==0) { waveNumber++; SpawnEnemyWave(waveNumber); }
    }
}


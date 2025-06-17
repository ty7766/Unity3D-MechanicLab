using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public int enemyCount;
    public int waveNumber = 1;

    private float spawnRange = 9;       //스폰 범위

    void Start()
    {
        //적 생성
        SpawnEnemyWave(waveNumber);

        //파워업 생성
        SpawnPowerup();
    }

    private void Update()
    {
        //FindObject 대신 태그를 이용하여 탐색
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Enemy가 맵에 없으면 웨이브 증가시키고 생성
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }
    //적 생성 알고리즘
    private Vector3 GenerateSpawnPosition()
    {
        //적 생성할 위치
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    //여러 적 생성 메소드
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    //파워 업 생성 메소드
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}

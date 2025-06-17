using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public int enemyCount;
    public int waveNumber = 1;

    private float spawnRange = 9;       //���� ����

    void Start()
    {
        //�� ����
        SpawnEnemyWave(waveNumber);

        //�Ŀ��� ����
        SpawnPowerup();
    }

    private void Update()
    {
        //FindObject ��� �±׸� �̿��Ͽ� Ž��
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Enemy�� �ʿ� ������ ���̺� ������Ű�� ����
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }
    //�� ���� �˰���
    private Vector3 GenerateSpawnPosition()
    {
        //�� ������ ��ġ
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    //���� �� ���� �޼ҵ�
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    //�Ŀ� �� ���� �޼ҵ�
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}

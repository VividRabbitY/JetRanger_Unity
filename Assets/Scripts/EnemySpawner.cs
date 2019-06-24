using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timer;
    public GameObject[] enemyPrefabs;
    public Transform[] SpawnPoints;

    public Transform enemys;

    List<SpawnEnemy> stage1;
    SpawnEnemy[] stage1_array;
    GameObject[] enemysPool;

    float nextSpawnTime;
    int spawncount;
    int enemycount;
    bool stageEnd;

    private void Awake()
    {
        CreateStage();
        stage1_array = stage1.ToArray();
        stage1.Clear();
    }

    void Start()
    {
        timer = 0.0f;
        enemysPool = new GameObject[enemyPrefabs.Length];

        int poolcount = 0;
        foreach (var e in enemyPrefabs)
        {
            GameObject enemyins= Instantiate(e, enemys);
            enemyins.SetActive(false);
            enemysPool[poolcount] = enemyins;
            poolcount++;
        }

        spawncount = 0;
        enemycount = 0;
        nextSpawnTime = stage1_array[spawncount].spawnTime;
        stageEnd = false;
    }

    void Update()
    {
        timer+=Time.deltaTime;
        if (!stageEnd)
        {
            if (timer >= nextSpawnTime)
            {
                for (int i = 0; i < stage1_array[spawncount].enemycount; i++)
                {
                    enemysPool[enemycount + i].SetActive(true);
                }
                if (spawncount < stage1_array.Length - 1)
                {
                    enemycount += stage1_array[spawncount].enemycount;
                    spawncount++;
                    nextSpawnTime = stage1_array[spawncount].spawnTime;
                }
                else
                {
                    stageEnd = true;
                }
            }
        }
    }

    void CreateStage()
    {
        stage1 = new List<SpawnEnemy>();
    //01 Element_0
        var spawn = new SpawnEnemy()
        {
            spawnTime = 3.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //02 Element_1
         spawn = new SpawnEnemy()
        {
            spawnTime = 10.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //03 Element_2 & 3
        spawn = new SpawnEnemy()
        {
            spawnTime = 17.0f,
            enemycount = 2,
        };
        stage1.Add(spawn);
    //04 Element_4 
        spawn = new SpawnEnemy()
        {
            spawnTime = 24.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //05 Element_5 & 6
        spawn = new SpawnEnemy()
        {
            spawnTime = 31.0f,
            enemycount = 2,
        };
        stage1.Add(spawn);
    //06 Element_7 & 8
        spawn = new SpawnEnemy()
        {
            spawnTime = 38.0f,
            enemycount = 2,
        };
        stage1.Add(spawn);
    //07 Element_9
        spawn = new SpawnEnemy()
        {
            spawnTime = 45.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //08 Element_10
        spawn = new SpawnEnemy()
        {
            spawnTime = 47.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //09 Element_11 & 12
        spawn = new SpawnEnemy()
        {
            spawnTime = 54.0f,
            enemycount = 2,
        };
        stage1.Add(spawn);
    }

    public GameObject[] GetEnemyPool()
    {
        return enemysPool;
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
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

    public GameObject[] bossHitParts;
    public GameObject bossModel;
    public GameObject boss;

    float nextSpawnTime;
    int spawncount;
    int enemycount;
    bool stageEnd;

    public GameObject ClearUI;

    private void Awake()
    {
        CreateStage();
        stage1_array = stage1.ToArray();
        stage1.Clear();
    }

    void Start()
    {
        timer = 0.0f;
        enemysPool = new GameObject[enemyPrefabs.Length+bossHitParts.Length];

        int poolcount = 0;
        foreach (var e in enemyPrefabs)
        {
            GameObject enemyins= Instantiate(e, enemys);
            enemyins.SetActive(false);
            enemysPool[poolcount] = enemyins;
            poolcount++;
        }

        Array.Copy(bossHitParts, 0, enemysPool, enemyPrefabs.Length, bossHitParts.Length);

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
        if(stageEnd&&timer>=60.0f)
        {
            bossModel.GetComponent<Animator>().SetTrigger("appear");
            boss.SetActive(true);
        }
        GameClear();
    }

    void CreateStage()
    {
        stage1 = new List<SpawnEnemy>();
    //01 Element_0 wave1_L
        var spawn = new SpawnEnemy()
        {
            spawnTime = 7.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 7.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 8.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 8.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 9.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 9.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);

        //02 Element_1 wave1_R
        spawn = new SpawnEnemy()
        {
            spawnTime = 11.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 11.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 12.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 12.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 13.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 13.5f,
            enemycount = 1,
        };
        stage1.Add(spawn);
    //03 wave3
        spawn = new SpawnEnemy()
        {
            spawnTime = 15.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 24.0f,
            enemycount = 2,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 33.0f,
            enemycount = 4,
        };
        stage1.Add(spawn);
        //wave4
        spawn = new SpawnEnemy()
        {
            spawnTime = 43.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 45.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 47.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 49.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 51.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 53.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);
        spawn = new SpawnEnemy()
        {
            spawnTime = 55.0f,
            enemycount = 1,
        };
        stage1.Add(spawn);



    }

    public GameObject[] GetEnemyPool()
    {
        return enemysPool;
    }

    public void GameClear()
    {
        if (bossHitParts[bossHitParts.Length - 1].GetComponent<Enemy>().IsDead())
        {
            ClearUI.SetActive(true);
        }
    }

}

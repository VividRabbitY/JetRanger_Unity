using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnEnemy
{
    public float spawnTime;
    public int enemycount;

     public SpawnEnemy(float spawnTime,int enemycount)
    {
        this.spawnTime = spawnTime;
        this.enemycount=enemycount;
    }
}


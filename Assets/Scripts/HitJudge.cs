using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudge : MonoBehaviour
{
    public GameObject player;
    Transform playerPos;
    private Dictionary<EnemyshotType, GameObject[]> enemyshotPools;
    private GameObject[] playershotPool;

    //debug
    public GameObject[] enemys;
    public EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = PlayerPosition.playerTransform;
        enemyshotPools = GetComponent<ShotPool>().GetEnemyShotPool();
        playershotPool = GetComponent<ShotPool>().GetPlayerShotPool();

        //enemys = spawner.GetEnemyPool();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyshotPools.Count; i++)
        {
            float hitradiosqr = (HitConstant.enemyShotHitRadio[(EnemyshotType)i])* (HitConstant.enemyShotHitRadio[(EnemyshotType)i]);
            foreach (var es in enemyshotPools[(EnemyshotType)i])
            {
                if(es.activeInHierarchy&&player.activeInHierarchy)
                {
                    if((es.transform.position-playerPos.position).sqrMagnitude<hitradiosqr)
                    {
                        es.SetActive(false);
                        player.GetComponent<Player>().Hit();
                        Debug.Log("Hit!");
                    }
                }
            }
        }

        foreach (var ps in playershotPool)
        {
            if (ps.activeInHierarchy)
            {
                foreach (var e in enemys)
                {
                    if (e.activeInHierarchy)
                    {
                        if ((e.transform.position - ps.transform.position).sqrMagnitude < HitConstant.playerShotRadio * HitConstant.playerShotRadio)
                        {
                            e.GetComponent<Enemy>().Hit();
                        }
                    }
                }
            
            }
        }


    }
}

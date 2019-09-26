using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudge : MonoBehaviour
{
//プレイヤー位置
    public GameObject player;
    Transform playerPos;
//プレイヤー、エネミー弾プール
    private Dictionary<EnemyshotType, GameObject[]> enemyshotPools;
    private GameObject[] playershotPool;
//エネミー
    public GameObject[] enemys;
    public EnemySpawner spawner;
//エフェクト
    public GameObject enemyHitperfab;
    GameObject[] enemyHitParticles;
    int particleNo;
    public GameObject playerHitperfab;
    GameObject playerHitparticle;
    public GameObject enemyDiedParticle;

    // Start is called before the first frame update
    void Start()
    {
    //プレイヤー位置取得
        playerPos = PlayerPosition.playerTransform;
    //弾プール取得    
        enemyshotPools = GetComponent<ShotPool>().GetEnemyShotPool();
        playershotPool = GetComponent<ShotPool>().GetPlayerShotPool();
    //敵取得
        enemys = spawner.GetEnemyPool();
    //エフェクトオブジェクト初期化
        enemyHitParticles = new GameObject[5];
        for (int i = 0; i < enemyHitParticles.Length; i++)
        {
            enemyHitParticles[i] = Instantiate(enemyHitperfab);
        }
        particleNo = 0;
        playerHitparticle = Instantiate(playerHitperfab);
    }


    // Update is called once per frame
    void Update()
    {
    //プレイヤーと敵弾
    //弾種ごとに、当たりを判定する
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
                        if (!player.GetComponent<Player>().IsDamaged())
                        {
                            playerHitparticle.GetComponent<ParticleSystem>().Play();
                        }
                        player.GetComponent<Player>().Hit();
                        playerHitparticle.transform.position = player.transform.position;

                    }
                }
            }
        }
    //プレイヤー弾と敵
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
                            bool isdead = e.GetComponent<Enemy>().IsDead();
                            Vector3 hitpos = ps.transform.position;
                            if (isdead)
                            {
                                enemyDiedParticle.transform.position = e.transform.position;
                                enemyDiedParticle.GetComponent<ParticleSystem>().Play();
                            }

                            EnemyHit(hitpos );
                            ps.SetActive(false);
                        }
                    }
                }
            
            }
        }


    }

    void EnemyHit(Vector3 pos)
    {
        enemyHitParticles[particleNo].transform.position = pos;
        enemyHitParticles[particleNo].GetComponent<ParticleSystem>().Play();
        particleNo++;
        particleNo = particleNo % enemyHitParticles.Length;
    }
}

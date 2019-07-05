using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudge : MonoBehaviour
{
    public GameObject player;
    Transform playerPos;
    private Dictionary<EnemyshotType, GameObject[]> enemyshotPools;
    private GameObject[] playershotPool;

    public GameObject[] enemys;
    public EnemySpawner spawner;

    public GameObject enemyHitperfab;
    GameObject[] enemyHitParticles;
    int particleNo;
    public GameObject playerHitperfab;
    GameObject playerHitparticle;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = PlayerPosition.playerTransform;
        enemyshotPools = GetComponent<ShotPool>().GetEnemyShotPool();
        playershotPool = GetComponent<ShotPool>().GetPlayerShotPool();

        enemys = spawner.GetEnemyPool();

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
                            Vector3 hitpos = ps.transform.position;
                            hitpos.x += 0.2f;
                            hitpos.y += 0.1f;
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

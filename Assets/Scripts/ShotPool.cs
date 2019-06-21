using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPool : MonoBehaviour
{
    public static ShotPool instance;

    public GameObject playershot;
    public Transform shots;
    GameObject[] playershotpool;
    public int maxOfPlayerPool;

    public GameObject[] enemyshot;
    public Transform[] enemyshots;
    private Dictionary<EnemyshotType, GameObject[]> enemyshotPools;
    public int maxOfEnemyPool;

    private int playernextshot;
    private Dictionary<EnemyshotType, int> enemyNextshot;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playershotpool = new GameObject[maxOfPlayerPool];
        for (int i = 0; i < maxOfPlayerPool; i++)
        {
            GameObject b = Instantiate(playershot, shots);
            b.SetActive(false);
            playershotpool[i] = b;
        }
        playernextshot = 0;

        enemyshotPools = new Dictionary<EnemyshotType, GameObject[]>();
        enemyNextshot = new Dictionary<EnemyshotType, int>();
        for (int i = 0; i < enemyshot.Length; i++)
        {
            enemyshotPools.Add((EnemyshotType)i, new GameObject[maxOfEnemyPool]);
            for (int j = 0; j < maxOfEnemyPool; j++)
            {
                GameObject b = Instantiate(enemyshot[i], enemyshots[i]);
                b.SetActive(false);
                enemyshotPools[(EnemyshotType)i][j] = b;
            }
            enemyNextshot[(EnemyshotType)i]=0;
        }
        Debug.Log(enemyshotPools.Count);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootFromPool(Vector3 position)
    {
        playershotpool[playernextshot].transform.position = position;
        playershotpool[playernextshot].SetActive(true);
        playernextshot++;
        playernextshot = playernextshot % maxOfPlayerPool;
    }
    public GameObject ShootFromPool( EnemyshotType shotType,Vector3 position)

    {
        GameObject eb = enemyshotPools[shotType][enemyNextshot[shotType]];
       eb.transform.position = position;
       eb.SetActive(true);
        enemyNextshot[shotType]++;
        enemyNextshot[shotType] = enemyNextshot[shotType] % maxOfEnemyPool;
        return eb;
    }
}

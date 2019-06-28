using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    BossState state;
    BossState nextState;
    float timer;

    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject level3;

    float prepareTime;
    float endingTime;
    float betweenTime;

    // Start is called before the first frame update
    void Start()
    {
        state = BossState.Prepare;
        nextState = BossState.L1;
        prepareTime = 3.0f;
        endingTime = 3.0f;
        betweenTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //ボス状態制御
        switch (state)
        {
            //入場
            case BossState.Prepare:
                if(timer>=prepareTime)
                {
                    state = BossState.L1;
                    foreach (var e in level1)
                    {
                        e.SetActive(true);
                    }
                }
                break;
                //段階1
            case BossState.L1:
                {
                    int enemycount = 4;
                    foreach (var e in level1)
                    {
                        if(!e.activeInHierarchy)
                        {
                            enemycount--;
                        }
                    }

                    if(enemycount<=0)
                    {
                        state = BossState.Between;
                        nextState = BossState.L2;
                        timer = 0.0f;

                        foreach (var e in level2)
                        {
                            e.SetActive(true);
                        }
                    }
                }

          break;
                //段階2
            case BossState.L2:
                {
                    int enemycount = 2;
                    foreach (var e in level2)
                    {
                        if (!e.activeInHierarchy)
                        {
                            enemycount--;
                        }
                    }

                    if (enemycount <= 0)
                    {
                        state = BossState.Between;
                        nextState = BossState.L3;
                        timer = 0.0f;
                        level3.SetActive(true);
                    }
                }
                break;
                //段階3
            case BossState.L3:
                {
                    if(!level3.activeInHierarchy)
                    {
                        state = BossState.Finish;
                    }
                }

                break;
                //勝利
            case BossState.Finish:
                Debug.Log("Victory!");
                break;
                //段階切り替え中
            case BossState.Between:
                {
                    if(timer>=betweenTime)
                    {
                        state = nextState;
                    }
                }
                break;
        }

        Debug.Log(state);
    }
}

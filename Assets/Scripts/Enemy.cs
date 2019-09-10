using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp=40;
    bool isDeadFlag=false;
    public int score;

    public GameObject enemymodel;

    public Material activeMat;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        isDeadFlag = false;
        audioManager = AudioManager.instance;
        if(activeMat!=null)
        {
            enemymodel.GetComponent<Renderer>().material = activeMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score-=10;
        score = Mathf.Max(score, 1000);
    }
    public void Hit()
    {
        hp -= 1;
        ScoreManager.instance.AddScore(10);
        audioManager.PlaySe(SE.EnemyHit);
        if(hp<=0)
        {
            isDeadFlag = true;
            if(enemymodel!=null)
            {
                enemymodel.SetActive(false);
            }
            ScoreManager.instance.AddScore(score);
            gameObject.SetActive(false);
            audioManager.PlaySe(SE.EnemyDie);
        }
    }

    public bool IsDead()
    {
        return isDeadFlag;
    }
}

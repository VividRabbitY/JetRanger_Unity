using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp=40;
    bool isDeadFlag=false;
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        isDeadFlag = false;
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
        if(hp<=0)
        {
            isDeadFlag = true;
            ScoreManager.instance.AddScore(score);
            gameObject.SetActive(false);
        }
    }

    public bool IsDead()
    {
        return isDeadFlag;
    }
}

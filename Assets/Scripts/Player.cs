using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int Hp;
    float timeBetweenDamage;
    bool damaged;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 500;
        timeBetweenDamage = 3.0f;
        damaged = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            timer += Time.deltaTime;
        }
        if(timer>=timeBetweenDamage)
        {
            damaged = false;
        }
    }

    public void Hit()
    {
        if (!damaged)
        {
            Hp -= 250;
            damaged = true;
            timer = 0.0f;
        }
        if(Hp<=0)
        {
            //gameover();
            gameObject.SetActive(false);
        }
    }
}

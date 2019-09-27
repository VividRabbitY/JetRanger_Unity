using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//プレイヤーHP管理
public class Player : MonoBehaviour
{
    int maxHp = 5;
    int Hp;
    float timeBetweenDamage;
    bool damaged;
    float timer;

    public GameObject overUI;
    public GameObject[] hpBar;
    public GameObject hpclef;
    public Material hp1;
    public Material hp2;

    public Material normalMat;
    public Material damageMat;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        Hp = maxHp;
        timeBetweenDamage = 3.0f;
        damaged = false;
        timer = 0.0f;

        audioManager = AudioManager.instance;
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
            GetComponent<Renderer>().material = normalMat;
        }
    }

    public void Hit()
    {
        if (!damaged)
        {
            Hp -= 1;
            damaged = true;
            GetComponent<Renderer>().material = damageMat;

            GetComponent<Animator>().SetTrigger("damage");

            timer = 0.0f;

            Hp = Mathf.Max(Hp, 0);

            
            hpBar[Hp].SetActive(false);
            if(Hp<=3)
            {
                foreach(var h in hpBar)
                {
                    hpclef.GetComponentInChildren<Renderer>().material = hp1;
                    h.GetComponentInChildren<Renderer>().material = hp1;
                }
            }
            if (Hp <= 1)
            {
                foreach (var h in hpBar)
                {
                    hpclef.GetComponentInChildren<Renderer>().material = hp2;
                    h.GetComponentInChildren<Renderer>().material = hp2;
                }
            }


            audioManager.PlaySe(SE.PlayerHit);
        }
        if (Hp<=0)
        {
            overUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public bool IsDamaged()
    {
        return damaged;
    }
}

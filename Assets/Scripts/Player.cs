using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int maxHp = 500;
    int Hp;
    float timeBetweenDamage;
    bool damaged;
    float timer;

    public GameObject overUI;
    public GameObject hpBar;

    public Material normalMat;
    public Material damageMat;

    // Start is called before the first frame update
    void Start()
    {
        Hp = maxHp;
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
            GetComponent<Renderer>().material = normalMat;
        }
    }

    public void Hit()
    {
        if (!damaged)
        {
            Hp -= 250;
            damaged = true;
            GetComponent<Renderer>().material = damageMat;

            timer = 0.0f;

            Hp = Mathf.Max(Hp, 0);
            Debug.Log(Hp);

            Vector3 hpscal = hpBar.transform.localScale;
            hpscal.z = hpscal.z * ((float)Hp / maxHp);
            Debug.Log(hpscal);
            hpBar.transform.localScale = hpscal;

        }
        if(Hp<=0)
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

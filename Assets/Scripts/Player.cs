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
            Hp -= 100;
            damaged = true;
            GetComponent<Renderer>().material = damageMat;

            GetComponent<Animator>().SetTrigger("damage");

            timer = 0.0f;

            Hp = Mathf.Max(Hp, 0);


            Vector3 hpscal = hpBar.transform.localScale;
            hpscal.z = hpscal.z * ((float)Hp / maxHp);

            hpBar.transform.localScale = hpscal;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー射撃
public class PlayerShoot : MonoBehaviour
{


    private bool canShoot;
    private float shootCooldown=0.1f;//射撃間隔
    private float timer;

    public ShotPool shotPool;//弾プール
    public Transform shootPoint;//射撃位置

    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;

        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire2")&&canShoot)
        {
            shotPool.ShootFromPool(shootPoint.position);
            canShoot = false;
            timer = 0f;
            audioManager.PlaySe(SE.PlayerShoot);
            
        }
        if(timer>shootCooldown)
        {
            canShoot = true;
        }

    }
}

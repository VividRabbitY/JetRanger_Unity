using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{


    private bool canShoot;
    private float shootCooldown=0.1f;
    private float timer;

    public ShotPool shotPool;
    public Transform shootPoint;

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

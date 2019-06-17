using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool canShoot;
    private float shootCooldown=0.1f;
    private float timer;

    public GameObject Bullet;
    public Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire2")&&canShoot)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            canShoot = false;
            timer = 0f;
        }
        if(timer>shootCooldown)
        {
            canShoot = true;
        }

    }
}

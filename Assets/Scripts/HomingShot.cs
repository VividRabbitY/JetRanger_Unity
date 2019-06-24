using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShot : MonoBehaviour
{
    private ShotPool enemyshotpool;


    public int shotAmount;
    public float prepareTime;
    public float coolDown;
    public int waveAmount;

    public float speed;
    public float rotate;
    private Vector3 startdirection;
    

    private float timer;

    private ShootState state;

    

    void Start()
    {
        enemyshotpool = ShotPool.instance;
        timer = 0.0f;
        state = ShootState.Prepare;
        startdirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (state)
        {
            case ShootState.Prepare:
                if (timer > prepareTime)
                {
                    state = ShootState.Shooting;
                    timer = coolDown;
                    Vector3 posXZ = new Vector3(transform.position.x, 0.0f, transform.position.z);
                    startdirection = (PlayerPosition.position - posXZ).normalized;
                }
                break;
            case ShootState.Shooting:
                if (timer > coolDown)
                {
                    Shoot(startdirection);
                    startdirection = Quaternion.Euler(0.0f, rotate, 0.0f) * startdirection;
                    timer = 0.0f;
                    waveAmount--;
                }
                if (waveAmount == 0)
                {
                    state = ShootState.Ending;
                }
                break;
            case ShootState.Ending:
                break;
        }
    }

    private void Shoot(Vector3 start)
    {
            GameObject shot = enemyshotpool.ShootFromPool(EnemyshotType.SmallBall, transform.position);
            EnemyShot_Movement ebm = shot.GetComponent<EnemyShot_Movement>();
            ebm.Create(start, speed);

    }


}

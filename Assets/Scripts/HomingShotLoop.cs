using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShotLoop : MonoBehaviour
{
    private ShotPool enemyshotpool;


    public int shotAmount;
    public float prepareTime;
    public float coolDown;
    public int waveAmount;
    public float waveCoolDown;
    bool iscoolDown;

    public float speed;
    public float rotate;
    private Vector3 startdirection;
    public float startRotate;

    private float timer;
    private int shotCount;

    private ShootState state;



    void Start()
    {
        enemyshotpool = ShotPool.instance;
        Debug.Log(enemyshotpool);
        timer = 0.0f;
        state = ShootState.Prepare;
        startdirection = Vector3.left;
        shotCount = 0;
        iscoolDown = false;
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
                    startdirection = Quaternion.Euler(0.0f, startRotate, 0.0f) * startdirection;
                }
                break;
            case ShootState.Shooting:
                if (!iscoolDown&& timer > coolDown)
                {
                    Shoot(startdirection);
                    startdirection = Quaternion.Euler(0.0f, rotate, 0.0f) * startdirection;
                    timer = 0.0f;
                    shotCount++;
                }
                if(shotCount>=shotAmount)
                {
                    iscoolDown = true;
                    waveAmount--;
                    shotCount = 0;
                }
                if(iscoolDown&&timer>=waveCoolDown)
                {
                    iscoolDown = false;
                    timer = 0.0f;
                    Vector3 posXZ = new Vector3(transform.position.x, 0.0f, transform.position.z);
                    startdirection = (PlayerPosition.position - posXZ).normalized;
                    startdirection = Quaternion.Euler(0.0f, startRotate, 0.0f) * startdirection;
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

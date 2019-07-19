using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShot : MonoBehaviour
{
    protected ShotPool enemyshotpool;


    public int shotAmount;
    public float prepareTime;
    public float coolDown;
    public int waveAmount;

    public float speed;
    public float rotate;
    private Vector3 startdirection;

    private float timer;

    private ShootState state;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyshotpool = ShotPool.instance;

        timer = 0.0f;
        state = ShootState.Prepare;
        startdirection = Vector3.left;

        audioManager = AudioManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch(state)
        {
            case ShootState.Prepare:
                if(timer>prepareTime)
                {
                    state = ShootState.Shooting;
                    timer = coolDown;
                }
                break;
            case ShootState.Shooting:
                if(timer>coolDown)
                {
                    audioManager.PlaySe(SE.EnemyShoot);
                    Shoot(startdirection);
                    startdirection = Quaternion.Euler(0.0f, rotate, 0.0f) * startdirection;
                    timer = 0.0f;
                    waveAmount--;
                }
                if(waveAmount==0)
                {
                    state = ShootState.Ending;
                }
                break;
            case ShootState.Ending:
                break;
        }
    }

    virtual public  void Shoot(Vector3 start)
    {
        for (int i = 0; i < shotAmount; i++)
        {
            GameObject shot =enemyshotpool.ShootFromPool(EnemyshotType.SmallBall,transform.position);
            EnemyShot_Movement ebm = shot.GetComponent<EnemyShot_Movement>();
            ebm.Create(Quaternion.Euler(0, 360/shotAmount * i, 0) * start, speed);

        }
    }
    
}

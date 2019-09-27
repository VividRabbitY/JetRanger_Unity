using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自身から円形の弾を発射する
public class CircleShot : MonoBehaviour
{
    protected ShotPool enemyshotpool;


    public int shotAmount;//一回発射数
    public float prepareTime;//生成から発射の時間
    public float coolDown;//発射間隔
    public int waveAmount;//発射回数（-1時無限）

    public float speed;//弾速度
    public float rotate;//隣接弾の角度
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

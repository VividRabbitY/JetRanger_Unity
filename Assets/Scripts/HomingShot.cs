using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに向かって射撃する（一回のみ）
public class HomingShot : MonoBehaviour
{
    private ShotPool enemyshotpool;


    public float prepareTime;//生成から発射の時間
    public float coolDown;//発射間隔
    public int waveAmount;//一回発射数

    public float speed;//弾速度
    public float rotate;//隣接弾の角度
    private Vector3 startdirection;
    private Vector3 shootPos;

    private float timer;

    private ShootState state;

    AudioManager audioManager;

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

        switch (state)
        {
            case ShootState.Prepare:
                if (timer > prepareTime)
                {
                    state = ShootState.Shooting;
                    timer = coolDown;
                    Vector3 posXZ = new Vector3(transform.position.x, 0.0f, transform.position.z);
                    startdirection = (PlayerPosition.position - posXZ).normalized;
                    shootPos = transform.position;
                }
                break;
            case ShootState.Shooting:
                if (timer > coolDown)
                {
                    audioManager.PlaySe(SE.EnemyShoot);
                    Shoot(startdirection,shootPos);
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

    private void Shoot(Vector3 start,Vector3 pos)
    {
        GameObject shot = enemyshotpool.ShootFromPool(EnemyshotType.SmallBall, pos);
        EnemyShot_Movement ebm = shot.GetComponent<EnemyShot_Movement>();
        ebm.Create(start, speed);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに向かって射撃する
public class HomingShotLoop : MonoBehaviour
{
    private ShotPool enemyshotpool;


    public int shotAmount;//一回の発射数
    public float prepareTime;//生成から発射の時間
    public float coolDown;//発射間隔
    public int waveAmount;//発射回数
    public float waveCoolDown;//発射ウェーブ間の間隔
    bool iscoolDown;

    public float speed;//弾速度
    public float rotate;//隣接弾の角度
    private Vector3 startdirection;
    public float startRotate;//開始角度

    private float timer;
    private int shotCount;

    private ShootState state;

    AudioManager audioManager;

    void Start()
    {
        enemyshotpool = ShotPool.instance;
        Debug.Log(enemyshotpool);
        timer = 0.0f;
        state = ShootState.Prepare;
        startdirection = Vector3.left;
        shotCount = 0;
        iscoolDown = false;

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
                    startdirection = Quaternion.Euler(0.0f, startRotate, 0.0f) * startdirection;
                }
                break;
            case ShootState.Shooting:
                if (!iscoolDown&& timer > coolDown)
                {
                    audioManager.PlaySe(SE.EnemyShoot);
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

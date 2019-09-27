using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上空から落ちる弾
//画面後ろから前の順で波状落ちる
public class EnemyShot_Drop : MonoBehaviour
{
    Vector3 velocity;
    float speed;
    float timer;

    float prepareTime;
    public float maxPrepareTime; //一番後ろ落ちる時間
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.down;
        speed = 0.0f;
        timer = 0.0f;
        //生成から落ちるまでの時間計算
        prepareTime = 1.0f + (1-((transform.position.x - FieldSetting.fieldMin.x) / 18.0f)) * maxPrepareTime;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > prepareTime)
        {
            speed += FieldSetting.gravity * Time.deltaTime;
            velocity.y = speed;
            transform.Translate(velocity * Time.deltaTime);
        }
    }

   public void Create(Vector3 position)
    {
        transform.position = position;
    }
}

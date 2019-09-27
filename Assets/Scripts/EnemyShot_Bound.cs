using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//壁に当たる時反射する弾
public class EnemyShot_Bound : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    public int boundTime;//反射回数

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);


        if (transform.position.x < FieldSetting.fieldMin.x ||
    transform.position.x > FieldSetting.fieldMax.x)
        {
            if(boundTime>0)
            {
                direction.x = -direction.x;
                boundTime--;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (    transform.position.z < FieldSetting.fieldMin.z ||
    transform.position.z > FieldSetting.fieldMax.z)
        {
            if (boundTime > 0)
            {
                direction.z = -direction.z;
                boundTime--;
            }
            else
            {
                gameObject.SetActive(false);
            }

        }


    }

    public void Create(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }
}

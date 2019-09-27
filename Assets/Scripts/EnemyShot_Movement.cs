using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//直線発射する弾
public class EnemyShot_Movement : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    void Update()
    {
        transform.Translate(direction * speed*Time.deltaTime);
    }

    public void Create(Vector3 direction,float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }
}

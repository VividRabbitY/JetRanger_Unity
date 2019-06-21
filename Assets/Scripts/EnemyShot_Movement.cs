using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot_Movement : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    // Start is called before the first frame update

    // Update is called once per frame
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

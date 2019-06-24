using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot_Drop : MonoBehaviour
{
    Vector3 velocity;
    float speed;
    float timer;

    float prepareTime;
    public float maxPrepareTime; 
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.down;
        speed = 0.0f;
        timer = 0.0f;

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

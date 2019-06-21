using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed=0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x += bulletSpeed*Time.fixedDeltaTime;
        transform.position = position;

        if (position.x > FieldSetting.fieldMax.x)
            gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<FieldSetting.fieldMin.x||
            transform.position.x > FieldSetting.fieldMax.x||
            transform.position.y < FieldSetting.fieldMin.y||
            transform.position.y > FieldSetting.fieldMax.y||
            transform.position.z < FieldSetting.fieldMin.z||
            transform.position.z > FieldSetting.fieldMax.z)
        {
            gameObject.SetActive(false);
        }
    }
}

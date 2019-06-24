using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightLeave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        //敵がｘ座標12まで来たら
        if( transform.position.x < 13.0f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }

    }
}

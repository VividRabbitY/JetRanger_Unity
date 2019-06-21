using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 40;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*Time.deltaTime);
    }
    public void Hit()
    {
        hp -= 1;
        if(hp<=0)
        {
            gameObject.SetActive(false);
        }
    }
}

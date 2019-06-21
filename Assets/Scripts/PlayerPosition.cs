using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static Vector3 position;
    private void Start()
    {
        position = Vector3.zero;
    }
    void Update()
    {
        position.x = transform.position.x;
        position.z = transform.position.z;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static Vector3 position;
    public static Transform playerTransform;
    private void Start()
    {
        position = Vector3.zero;
        playerTransform = transform;
    }
    void Update()
    {
        position.x = transform.position.x;
        position.z = transform.position.z;
    }
}

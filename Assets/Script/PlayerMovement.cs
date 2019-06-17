using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=5f;
    public float jetForce = 10f;

    private Vector3 moveinput;
    private bool isOnGround;


    private Rigidbody rig;
    private void Awake()
    {
        moveinput = Vector3.zero;
        rig = GetComponent<Rigidbody>();
        isOnGround = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveinput = new Vector3(v, 0, -h)*speed;

        if (Input.GetButton("Fire1"))
        {
           rig.AddForce(Vector3.up * jetForce*2f);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * jetForce * 30f);
        }
    }


    private void FixedUpdate()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.x = moveinput.x;
        velocity.z = moveinput.z;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    public float speed=5.0f;
    public float jetForce = 10.0f;
    public float gravity=-10.0f;

    private Vector3 moveinput;
    private Vector3 velocity;
    private bool onGround;
    private bool lastonground;

    private float playerRadio = 0.5f;

    public ParticleSystem jetpackParticle;

    AudioManager audioManager;

    private void Awake()
    {
        velocity = Vector3.zero;
        moveinput = Vector3.zero;
        onGround = true;
        lastonground = true;

   }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveinput = new Vector3(v, 0, -h).normalized*speed;

        moveinput = Quaternion.Euler(0, -45, 0) * moveinput;
            

        if (Input.GetButton("Fire1"))
        {
                velocity.y += jetForce *1.2f*Time.deltaTime;
            jetpackParticle.Emit(1);
            audioManager.PlayLoopSE(SE.PlayerJet);

        }
        if (Input.GetButtonDown("Fire1"))
        {
            audioManager.PlayLoopSE(SE.PlayerJet);

            jetpackParticle.Emit(20);
            velocity = Vector3.zero;
            if (onGround)
                velocity.y += jetForce * 18.0f * Time.deltaTime;
            else
                velocity.y += jetForce * 8.0f * Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            audioManager.StopSe(SE.PlayerJet);
        }


        velocity.x = moveinput.x;
        velocity.z = moveinput.z;

        if (!onGround)
            velocity.y += gravity * Time.deltaTime;


        onGround = IsOnGround();
        if (!lastonground && onGround)
        {
            velocity.y = 0.0f;
        }

        transform.position += velocity * Time.deltaTime;
        ClampPosition();


        lastonground = onGround;
    }




    private void ClampPosition()
    {
        Vector3 position = transform.position;

        position.x=Mathf.Clamp(position.x,FieldSetting.fieldMin.x+playerRadio,FieldSetting.fieldMax.x-playerRadio);
        position.y= Mathf.Clamp(position.y,FieldSetting.fieldMin.y+playerRadio,FieldSetting.fieldMax.y-playerRadio);
        position.z= Mathf.Clamp(position.z,FieldSetting.fieldMin.z+playerRadio,FieldSetting.fieldMax.z-playerRadio);

        transform.position = position;
    }

    private bool IsOnGround()
    {
        if (transform.position.y > playerRadio)
            return false;
        else

        return true;
    }
}

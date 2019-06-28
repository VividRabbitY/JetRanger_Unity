using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShoot : MonoBehaviour
{
    private ShotPool enemyshotPool;

    private float timer;

    public float coolDown;
    public int shotAmount;

    public float shotPosY;

    // Start is called before the first frame update
    void Start()
    {
        enemyshotPool = ShotPool.instance;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= coolDown)
        {
            Shoot();
            timer=0.0f;
        }


    }

    private void Shoot()
    {
        for (int i = 0; i < shotAmount; i++)
        {
            float x = Random.Range(FieldSetting.fieldMin.x, FieldSetting.fieldMax.x);
            float z = Random.Range(FieldSetting.fieldMin.z, FieldSetting.fieldMax.z);
            Vector3 pos = new Vector3(x, shotPosY, z);
            enemyshotPool.ShootFromPool(EnemyshotType.Drop, pos);
        }
    }
}

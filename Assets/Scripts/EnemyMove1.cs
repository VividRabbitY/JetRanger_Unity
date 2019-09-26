﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove1 : MonoBehaviour
{
    enum MoveState
    {
        Enter,
        Shooting,
        Exit
    }
    MoveState state;

    Vector3 startPos;

    public float enterTime;
    public Vector3  enterTargetPos;
    float entertimer;
    public float shootTime;
    public Vector3 shootTargetPos;
    float shootTimer;
    public float exitTime;
    public Vector3 exitTargetPos;
    float exittimer;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        state = MoveState.Enter;
        timer = 0f;
        entertimer = 0f;
        exittimer = 0f;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (state)
        {
            case MoveState.Enter:
                Vector3 pos = transform.position;
                entertimer += Time.deltaTime / enterTime;
                pos = Vector3.Lerp(pos, enterTargetPos, Time.deltaTime);
                transform.position = pos;
                if(timer>=enterTime)
                {
                    state = MoveState.Shooting;
                    startPos = transform.position;
                }
                break;
            case MoveState.Shooting:
                if (shootTargetPos != Vector3.zero)
                {
                    Vector3 spos = transform.position;
                    shootTimer += Time.deltaTime / shootTime;
                    spos = Vector3.Lerp(startPos, shootTargetPos, shootTimer);
                    transform.position = spos;
                }
                if (timer>=enterTime+shootTime)
                {
                    state = MoveState.Exit;
                    startPos = transform.position;
                }
                break;
            case MoveState.Exit:
                Vector3 epos = transform.position;
                exittimer += Time.deltaTime / exitTime;
                epos = Vector3.Lerp(startPos, exitTargetPos, exittimer);
                transform.position = epos;

                if (transform.position.x < FieldSetting.fieldMin.x ||
                    transform.position.x > FieldSetting.fieldMax.x ||
                    transform.position.y < FieldSetting.fieldMin.y ||
                    transform.position.y > 10.0f ||
                    transform.position.z < FieldSetting.fieldMin.z ||
                    transform.position.z > FieldSetting.fieldMax.z)
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }


}


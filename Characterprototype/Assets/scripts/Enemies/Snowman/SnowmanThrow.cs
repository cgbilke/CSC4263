﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour, ISetTarget
{

    public float timeToFire;
    public GameObject projectile;
    public GameObject obj;
    public GameObject Player;
    public GameObject trigger;
    public GameObject target;

    public GameObject snowballSpawner;
    public GameObject arm;
    public GameObject rotateAround;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    private Vector2 ObjPos; //position of your object
    private Vector2 PlayerPos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private Vector2 moveDirection;
    private float angle; //degrees 
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = timeToFire;
    }

    public void setTarget(GameObject targetPlayer)
    {
        Player = targetPlayer;
        Debug.Log("Set in shoot");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player != null)
        {
            rotate();
            ObjPos = obj.transform.position;
            PlayerPos = Player.transform.position;
            RelPos = PlayerPos - ObjPos;

            angle = Mathf.Atan2(RelPos.x, RelPos.y);

            angle = angle * Mathf.Rad2Deg;
            timeToFire = timeToFire - Time.deltaTime;
            ////triggered = trigger.GetComponent<BossTrigger>().fight;
            if (/*triggered &&*/ gameObject.GetComponent<BoxCollider2D>().enabled)
            {
                if (timeToFire <= 0)
               {
                    GameObject proj = Instantiate(projectile, snowballSpawner.transform.position, Quaternion.identity) as GameObject;
                   moveDirection = (RelPos).normalized * 10;
                   proj.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);
                    timeToFire = time;
               }
            }
        }
    }

    private int canFire(float a)
    {
        if (a <= -30 && a > -40)//look up left
            return 1;
        if (a <= -40 && a > -50)
            return 2;
        if (a <= -50 && a > -60)
            return 3;
        if (a <= -60 && a > -70)
            return 4;
        if (a <= -70 && a > -80)
            return 5;
        if (a <= -80 && a > -90)//look straight left
            return 6;
        if (a <= -90 && a > -100)//look down left
            return 7;
        else
            return 0;
    }

    void rotate()
    {
        arm.transform.RotateAround(rotateAround.transform.position, zAxis, 150 * Time.deltaTime);
    }
}

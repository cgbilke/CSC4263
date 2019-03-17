﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiMove : EnemyMove
{

    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;

    public float localScaleSetNum;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float xdir = target.transform.position.x - rb.transform.position.x;
            float ydir = target.transform.position.y - rb.transform.position.y;

            if (GetComponent<EnemyDamage>().health > 0)
            {
                if (Mathf.Abs(xdir) > 2.2)
                {
                    rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    Debug.Log("Check");
                    StartCoroutine(GetComponent<YetiAttack>().Attack());
                }
            }
                

            if (target.transform.position.x > rb.transform.localScale.x)
            {
                transform.localScale = new Vector3(-localScaleSetNum, transform.localScale.y, 0);
            }
            else
            {
                transform.localScale = new Vector3(localScaleSetNum, transform.localScale.y, 0);
            }

        }
    }
}

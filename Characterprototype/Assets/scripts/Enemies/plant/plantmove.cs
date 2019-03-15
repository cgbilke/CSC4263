﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantmove : EnemyMove
{
    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;
    public bool triggered;

    public float localScaleSetNum;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        triggered = false;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 dir = target.transform.position - rb.transform.position;

            if (GetComponent<EnemyDamage>().health > 0)
                rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;

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

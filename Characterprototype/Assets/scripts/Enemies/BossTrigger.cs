﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{

    public bool fight;
    void Start()
    {
        fight = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //enemy.GetComponent<flameShoot>().triggered = true;
            gameObject.GetComponentInChildren<ISetTarget>().setTarget(col.gameObject);
            //GetComponent<FlameMove>().player = col.gameObject;
            //target = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //enemy.GetComponent<flameShoot>().triggered = false;
            gameObject.GetComponentInChildren<ISetTarget>().setTarget(null);
            //target = null;
        }
    }

}

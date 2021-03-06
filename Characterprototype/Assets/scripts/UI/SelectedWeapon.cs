﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject inv;
    private int weaponType;
    private SpriteRenderer sr;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        weaponType = inv.GetComponent<Inventory>().weaponType;
        switch (weaponType)
        {
            case 0:
                sr.enabled = false;
                break;
            case 1:
                sr.enabled = true;
                gameObject.transform.position = weapons[0].transform.position;
                break;
            case 2:
                sr.enabled = true;
                gameObject.transform.position = weapons[1].transform.position;
                break;
            case 3:
                sr.enabled = true;
                gameObject.transform.position = weapons[2].transform.position;
                break;
            case 4:
                sr.enabled = true;
                gameObject.transform.position = weapons[3].transform.position;
                break;
            case 5:
                sr.enabled = true;
                gameObject.transform.position = weapons[4].transform.position;
                break;
            case 6:
                sr.enabled = true;
                gameObject.transform.position = weapons[5].transform.position;
                break; 
        }
    }
}

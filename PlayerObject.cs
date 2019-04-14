using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class PlayerObject : MonoBehaviour
{

    public bool isDead; 
    public bool Guard;
    public bool Evasion;
    public bool isPoisoned;


    [HideInInspector]
    public float baseHP = 200, currentHP, baseStamina = 100, currentStamina;
    public float a1h, a1s, a2h, a2s, recovh, recovs, specialh, specials;

    //lambrogini, leg lock, dungeon slam

    public void Start()
    {
        currentHP = baseHP;
        currentStamina = baseStamina;
        Debug.Log(currentHP);
        currentHP = Mathf.Clamp(currentHP, 0, 200);
        currentStamina = Mathf.Clamp(currentStamina, 0, 100);
        getPlayer();
    }

    void getPlayer()
    {
        if (GlobalControl.Instance.p1 == true)
        {
            populateP1();
        }
        else if (GlobalControl.Instance.p2 == true)
        {
            populateP2();
        }
    }

    void populateP1()
    {
        a1h = 100;//5
        a1s = 10;//increases stamina
        a2h = 10;
        a2s = 15;//decreases stamina
        recovh = 30;//increases health
        recovs = 30;//deacreases stamina
        specialh = 40;
        specials = 35;//decreases stamina
    }

    void populateP2()
    {
        //Need to change values
        a1h = 100;//10
        a1s = 15;//increases stamina
        a2h = 20;
        a2s = 15;//decreases stamina
        recovh = 40;//increases health
        recovs = 30;//deacreases stamina
        specialh = 50;
        specials = 35;//decreases stamina
    }

    void Update()
    {

    }
}
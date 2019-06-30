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

    public Image PlayerHPProgressBar;
    public Image PlayerStaminaProgressBar;


    [HideInInspector]
    public float baseHP, currentHP, baseStamina, currentStamina, HPpercentage, staminaPercentage;

    public void Start()
    {
        baseHP = 200;
        baseStamina = 100;
        currentHP = baseHP;
        currentStamina = baseStamina;
        currentHP = Mathf.Clamp(currentHP, 0, 200);
        currentStamina = Mathf.Clamp(currentStamina, 0, 100);
    }

    void Update()
    {

    }

    public void playerUpdateBars()
    {
        HPpercentage = (float)currentHP / baseHP;
        PlayerHPProgressBar.fillAmount = HPpercentage;
        staminaPercentage = (float)currentStamina / baseStamina;
        PlayerStaminaProgressBar.fillAmount = staminaPercentage;
    }
}
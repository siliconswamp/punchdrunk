using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseAttack : MonoBehaviour
{
    public string attackName;
    public Button attack;
    public Animator playAnimate;
    public string description; //might need to change to type Text for UI
    
    public int attackDmg;
    public int attackStm;
}

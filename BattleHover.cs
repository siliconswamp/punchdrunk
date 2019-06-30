using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHover : MonoBehaviour
{
    public Text a1, a2, recov, spec, menu;
    // Start is called before the first frame update
    void Start()
    {
        a1.enabled = false;
        a2.enabled = false;
        recov.enabled = false;
        spec.enabled = false;
        menu.enabled = false;
    }
    public void attack1()
    {
        a1.enabled = true;
    }

    public void attack2()
    {
        a2.enabled = true;
    }

    public void recover()
    {
        recov.enabled = true;
    }

    public void special()
    {
        spec.enabled = true;
    }

    public void menuHover()
    {
        menu.enabled = true;
    }

    public void turnOffHover()
    {
        a1.enabled = false;
        a2.enabled = false;
        recov.enabled = false;
        spec.enabled = false;
        menu.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Image p1, p2, e1, e2, e3;
    public Text a1, a2, a3, a4, a5, a6;
    // Start is called before the first frame update
    void Start()
    {
        initialize();
        feats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initialize()
    {
        p1.enabled = false;
        p2.enabled = false;
        e1.enabled = false;
        e2.enabled = false;
        e3.enabled = false;
        a1.enabled = false;
        a2.enabled = false;
        a3.enabled = false;
        a4.enabled = false;
        a5.enabled = false;
        a6.enabled = false;
    }

    public void feats()
    {
        if (GlobalControl.Instance.array[0, 0] == true)
        {
            a1.enabled = true;
        }
        if (GlobalControl.Instance.array[0, 1] == true)
        {
            a2.enabled = true;
        }
        if (GlobalControl.Instance.array[0, 2] == true)
        {
            a3.enabled = true;
        }
        if (GlobalControl.Instance.array[1, 0] == true)
        {
            a4.enabled = true;
        }
        if (GlobalControl.Instance.array[1, 1] == true)
        {
            a5.enabled = true;
        }
        if (GlobalControl.Instance.array[1, 2] == true)
        {
            a6.enabled = true;
        }

        /*for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (GlobalControl.Instance.array[i, j] == true)
                {
                    //do stuff with achievements button
                }
            }
        }
        */
    }


    public void A1()
    {
        p1.enabled = true;
        e1.enabled = true;
    }

    public void A2()
    {
        p1.enabled = true;
        e2.enabled = true;
    }

    public void A3()
    {
        p1.enabled = true;
        e3.enabled = true;
    }

    public void A4()
    {
        p2.enabled = true;
        e1.enabled = true;
    }

    public void A5()
    {
        p2.enabled = true;
        e2.enabled = true;
    }

    public void A6()
    {
        p2.enabled = true;
        e3.enabled = true;
    }
    public void turnOffHover()
    {
        p1.enabled = false;
        p2.enabled = false;
        e1.enabled = false;
        e2.enabled = false;
        e3.enabled = false;
    }
}

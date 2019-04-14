using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populateUI : MonoBehaviour
{
    public Image p1Img, p2Img;
    public Text p1Txt, p2Txt;
    // Start is called before the first frame update
    void Start()
    {
        p1Img.enabled = false;
        p1Txt.enabled = false;
        p2Img.enabled = false;
        p2Txt.enabled = false;
    }
    public void turnOnHoverP1()
    {
        p1Img.enabled = true;
        p1Txt.enabled = true;
    }

    public void turnOffHover()
    {
        p1Img.enabled = false;
        p1Txt.enabled = false;
        p2Img.enabled = false;
        p2Txt.enabled = false;
    }

    public void turnOnHoverP2()
    {
        p2Img.enabled = true;
        p2Txt.enabled = true;
    }
}

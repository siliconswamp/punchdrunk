using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuEnable : MonoBehaviour
{
    public Text overview;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        overview.enabled = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCick()
    {
        overview.enabled = true;
        count += 1;
        if (count % 2 == 0)
        {
            overview.enabled = false;
        }
    }

}

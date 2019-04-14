using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRound : MonoBehaviour
{
    public SceneChanger SC;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nR()
    {
        if (GlobalControl.Instance.nextRound == "f2")
        {
            SC.SceneSelector("round2");
        }

        if (GlobalControl.Instance.nextRound == "f3")
        {
            SC.SceneSelector("round3");
        }

        if (GlobalControl.Instance.nextRound == "f22")
        {
            SC.SceneSelector("2round2");
        }

        if (GlobalControl.Instance.nextRound == "f23")
        {
            SC.SceneSelector("2round3");
        }

        if (GlobalControl.Instance.nextRound == "main")
        {
            SC.SceneSelector("main");
        }
    }
}

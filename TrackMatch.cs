using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMatch : MonoBehaviour
{
    public MatchTurn turn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMatrix()
    {
        if (GlobalControl.Instance.p1 == true)
        {
            if (turn.won && turn.e1)
            {                
                GlobalControl.Instance.array[0, 0] = true;
                GlobalControl.Instance.nextRound = "f2";
            }

            if (turn.won && turn.e2)
            {
                GlobalControl.Instance.array[0, 1] = true;
                GlobalControl.Instance.nextRound = "f3";
            }

            if (turn.won && turn.e3)
            {
                GlobalControl.Instance.array[0, 2] = true;
                GlobalControl.Instance.nextRound = "main";
            }
        }

        else if (GlobalControl.Instance.p2)
        {
            if (turn.won && turn.e1)
            {
                GlobalControl.Instance.array[1, 0] = true;
                GlobalControl.Instance.nextRound = "f22";
            }

            if (turn.won && turn.e2)
            {
                GlobalControl.Instance.array[1, 1] = true;
                GlobalControl.Instance.nextRound = "f23";
            }

            if (turn.won && turn.e3)
            {
                GlobalControl.Instance.array[1, 2] = true;
                GlobalControl.Instance.nextRound = "main";
            }
        }


    }
}

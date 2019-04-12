using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMatch : MonoBehaviour
{
    
    public bool[,] array = new bool[2, 3];
    public PlayerObject player;
    public MatchTurn turn;

    // Start is called before the first frame update
    void Start()
    {
        array = GlobalControl.Instance.array;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMatrix()
    {
     if (player.p1)
        {
            if (turn.won && turn.e1)
            {
                array[0, 0] = true;
            }

            if (turn.won && turn.e2)
            {
                array[0, 1] = true;
            }

            if (turn.won && turn.e3)
            {
                array[0, 2] = true;
            }
        }

        else if (player.p2)
        {
            if (turn.won && turn.e1)
            {
                array[1, 0] = true;
            }

            if (turn.won && turn.e2)
            {
                array[1, 1] = true;
            }

            if (turn.won && turn.e3)
            {
                array[1, 2] = true;
            }
        }
    }

    public bool charSelectAvailable()
    {
        if ((array[0,0]==true) && (array[0, 1]==true) && (array[0, 2]==true))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void feats()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array [i, j] == true)
                {
                    //do stuff with achievements button
                }
            }
        }
    }

    public void Save()
    {
        GlobalControl.Instance.array = array;
    }


}

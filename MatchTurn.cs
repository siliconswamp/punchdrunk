using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class MatchTurn : MonoBehaviour 
{
    public MatchTurnPlayer pScript;
    public MatchTurnEnemy eScript;
    public TrackMatch TM;
    public SceneChanger scene;
    //public Animator player_animate;

    public bool PlayerTurn, EnemyTurn, DoingTurn, End;
    public bool e1, e2, e3, won;

    void Start()
    {
        Debug.Log("matchturn start");
        PlayerTurn = false;
        EnemyTurn = false;
        DoingTurn = false;
        End = false;
    }

    public void doTurn()
    {
        if (!End && !EnemyTurn)
        {
            if (!PlayerTurn)
            {
                PlayerTurn = true;
                
                pScript.doPlayerTurn();
                
            }
        }
        if (!End && !PlayerTurn)
        {
            EnemyTurn = true;
            eScript.doEnemyTurn();
            EnemyTurn = false;
        }
        if (End)
        {
            if (pScript.player.currentHP <= 0)
            {
                //Lose game
                won = false;
                scene.lose();
            }
            else
            {
                //Win game
                won = true;
                TM.updateMatrix();
                scene.win();
            }
        }
        DoingTurn = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (End)
        {
            doTurn();

        }
        if (DoingTurn)
        {
            doTurn();
        }
        else if (!DoingTurn && !End)
        {
            DoingTurn = true;
            doTurn();
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MatchTurn : MonoBehaviour 
{
    public MatchTurnPlayer pScript;
    public MatchTurnEnemy eScript;
    public SceneChanger scene;

    public bool PlayerTurn, EnemyTurn, DoingTurn, End;

    void Start()
    {
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
                scene.masterSceneFadeOut(1);
            }
            else
            {
                //Win game
                scene.masterSceneFadeOut(7);
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
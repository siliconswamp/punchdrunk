using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class MatchTurn : MonoBehaviour 
{
    public MatchTurnPlayer pScript;
    public MatchTurnEnemy eScript;
    public PlayerObject player;
    public EnemyObject enemy;
    public SceneChanger scene;

    public bool PlayerTurn, EnemyTurn;
    public object prevTurn;

    public void Start()
    {
        if (prevTurn == null)
        {
            setUpGame();
        }
        doTurn();
    }

    public void setUpGame()
    {
        PlayerTurn = true;
        EnemyTurn = false;
    }

    public void doTurn()
    {
        if (PlayerTurn)
        {
            pScript.doPlayerTurn();
            prevTurn = pScript;
        }
        else if (EnemyTurn)
        {
            eScript.doEnemyTurn();
            prevTurn = eScript;
        }
        else if (PlayerTurn == false && EnemyTurn == false)
        {
            if (player.isDead)
            {
                //Lose game
                scene.lose();
            }
            else if (enemy.isDead)
            {
                //Win game
                scene.win();
            }
        }
    }


    // Update is called once per frame
    public void Update()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTurnEnemy : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    private MatchTurn turn;

    public void doEnemyTurn()
    {
        Debug.Log("Enemy state: in enemy turn");

        if (enemy.currentHP <= 0)
        {
            enemy.isDead = true;
            turn.End = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;
        }
        else
        { 
            enemy.Guard = false;

            enemy.tree.RunBehaviorTree();

           
            if (player.currentHP <= 0)
            {
                player.isDead = true;
                turn.End = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }

        }
    }

    public void EnemyMove1()
    {
        //WIP
    }

    // EnemyMove2,3,4
}

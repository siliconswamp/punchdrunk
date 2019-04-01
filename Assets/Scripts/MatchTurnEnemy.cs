using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Don
[System.Serializable]
public class MatchTurnEnemy : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    public MatchTurn turn;
    public BaseAttack enemyAtk;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void doEnemyTurn()
    {
        Debug.Log("Enemy state: In enemy turn");

        if (enemy.currentHP <= 0)
        {
            enemy.isDead = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;
        }
        else
        {
            enemy.Guard = false;

            if (player.currentHP <= 0)
            {
                player.isDead = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }
        }
        EnemyMove1();
        yieldETurn();
    }

    public void EnemyMove1()
    {
        Debug.Log("Enemy state: In EnemyMove1");
        enemyAtk.attackDmg = 10;
        enemyAtk.attackStm = 5;
        player.currentHP -= enemyAtk.attackDmg;
        enemy.currentStamina -= enemyAtk.attackStm;
        enemy.enemyUpdateBars();
        player.playerUpdateBars();
    }

    public void yieldETurn()
    {
        Debug.Log("Enemy state: In yieldETurn");
        turn.PlayerTurn = true;
        turn.EnemyTurn = false;
    }
    // EnemyMove2,3,4
}

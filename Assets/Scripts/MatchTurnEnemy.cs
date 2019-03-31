using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MatchTurnEnemy : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    private MatchTurn turn;
    private MatchTurnPlayer MTP;

    public float HPpercentage;
    public float staminaPercentage;
    public Image EnemyHPProgressBar;
    public Image EnemyStaminaProgressBar;

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

    public void enemyUpdateBars()
    {
        HPpercentage = (float)enemy.currentHP / enemy.baseHP;
        EnemyHPProgressBar.fillAmount = HPpercentage;
        staminaPercentage = (float)enemy.currentStamina / enemy.currentStamina;
        EnemyStaminaProgressBar.fillAmount = staminaPercentage;
    }

    public void EnemyMove1()
    {
        //WIP
    }

    // EnemyMove2,3,4
}

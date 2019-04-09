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
    public MatchTurnPlayer MTP;
    public BaseAttack enemyAtk;

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

            if (player.currentHP <= 0)
            {
                player.isDead = true;
                turn.End = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }
        }
        enemy.StaminaCheck = enemy.HasEnoughStamina();
        Debug.Log("Checking stamina level..." + enemy.HasEnoughStamina());
        Debug.Log("Enemy's StaminaCheck is " + enemy.StaminaCheck);
        enemy.tree = enemy.BuildTree();
        enemy.tree.RunBehaviorTree();
        yieldETurn();
    }

    public void yieldETurn()
    {
        turn.PlayerTurn = true;
        turn.EnemyTurn = false;
        Debug.Log("Player Turn: " + turn.PlayerTurn + " Enemy Turn: " + turn.EnemyTurn);
        
    }

    public void enemyUpdateBars()
    {
        HPpercentage = (float)enemy.currentHP / enemy.baseHP;
        EnemyHPProgressBar.fillAmount = HPpercentage;
        staminaPercentage = (float)enemy.currentStamina / enemy.baseStamina;
        EnemyStaminaProgressBar.fillAmount = staminaPercentage;
    }

    public void EnemyMove1()
    {
        Debug.Log("inside EnemyMove1");
        //enemyAtk.attackDmg = 5;
       // enemyAtk.attackStm = +10;
        player.currentHP -= 5;
        Debug.Log("Enemy attacks... player hp: " + player.currentHP);
        enemy.currentStamina += 10;
        if (enemy.currentStamina > enemy.baseStamina)
            enemy.currentStamina = enemy.baseStamina;
        Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
        enemyUpdateBars();
        MTP.playerUpdateBars();
    }

    public void EnemyMove2()
    {
        Debug.Log("inside EnemyMove2");
        //enemyAtk.attackDmg = 10;
        // enemyAtk.attackStm = 5;
        player.currentHP -= 10;
        Debug.Log("Enemy attacks... player hp: " + player.currentHP);
        enemy.currentStamina -= 5;
        Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
        enemyUpdateBars();
        MTP.playerUpdateBars();
    }

    public void EnemyMove3()
    {
        Debug.Log("inside EnemyMove3");
        //enemyAtk.attackDmg = 20;
        // enemyAtk.attackStm = 15;
        player.currentHP -= 20;
        Debug.Log("Enemy attacks... player hp: " + player.currentHP);
        enemy.currentStamina -= 15;
        Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
        enemyUpdateBars();
        MTP.playerUpdateBars();
    }

    public void EnemyMove4()
    {
        Debug.Log("inside EnemyMove4");
        //enemyAtk.attackDmg = 30;
        // enemyAtk.attackStm = 20;
        player.currentHP -= 30;
        Debug.Log("Enemy attacks... player hp: " + player.currentHP);
        enemy.currentStamina -= 20;
        Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
        enemyUpdateBars();
        MTP.playerUpdateBars();
    }

    public void EnemySkipTurn()
    {
        Debug.Log("Enemy is charging attack!");
    }
}

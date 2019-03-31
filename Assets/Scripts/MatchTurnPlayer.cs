using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MatchTurnPlayer : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    private MatchTurn turn;
    private MatchTurnEnemy MTE;
    private BaseAttack bA; //what the attacks call upon

    public float HPpercentage;
    public float staminaPercentage;
    public Image PlayerHPProgressBar;
    public Image PlayerStaminaProgressBar;

    public Button jab, cross, recover, special;//can be renamed


    public void doPlayerTurn()
    {
        Debug.Log("Player state: In player turn");

        if (player.currentHP <= 0)
        {
            player.isDead = true;
            turn.End = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;

        }
        else
        {
            player.Guard = false;
            if (enemy.currentHP <= 0)
            {
                //enemy.isDead = true;
                turn.End = true;
                Debug.Log("match end = " + turn.End);
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;


            }
        }
        selectAction();
        doAction();
        yieldPTurn();
    }

    public void playerUpdateBars()
    {
        HPpercentage = (float)player.currentHP / player.baseHP;
        PlayerHPProgressBar.fillAmount = HPpercentage;
        staminaPercentage = (float)player.currentStamina / player.currentStamina;
        PlayerStaminaProgressBar.fillAmount = staminaPercentage;
    }

    void selectAction()
    {
        //moveset.doMove(moveNum);
        //Player chooses action to do
        ChooseAction();
    }

    void doAction()
    {
        //update enemy and player stats
        //include evasion and guard stuff here
        enemy.currentHP -= bA.attackDmg;
        player.currentStamina -= bA.attackStm;
        playerUpdateBars();
        MTE.enemyUpdateBars();
    }
    void yieldPTurn()
    {
         turn.PlayerTurn = false;
         turn.EnemyTurn = true;

    }


    void ChooseAction() //Does different tasks based on what user chooses
        //need to rename
    {
        jab.onClick.AddListener(jabTask);
        cross.onClick.AddListener(crossTask);
        recover.onClick.AddListener(recoverTask);
        special.onClick.AddListener(specialTask);
    }

    //Various Tasks relative to each button

    void jabTask()
    {
        bA.attackName = "Jab";
        bA.playAnimate.SetTrigger("Jab");
        bA.description = "Simple attack that deals 10 damage to enemy and does not affect stamina";
        bA.attackDmg = 10;
        bA.attackStm = 0;
    }

    void crossTask()
    {
        bA.attackName = "Cross";
        bA.playAnimate.SetTrigger("Cross");
        bA.description = "Medium attack that deals 20 damage to enemy and reduces stamina 25 points";
        bA.attackDmg = 20;
        bA.attackStm = 25;
        if (player.currentStamina < bA.attackStm)
        {
            //Need to display that there is not enough stamina
            Debug.Log("There is not enough stamina for this move");

        }
    }

    void recoverTask()
    {
        if (player.currentStamina < player.baseStamina)
        {
            player.currentStamina += 30;
        }
        if (player.currentHP < player.baseHP)
        {
            player.currentHP += 30;
        }
        bA.attackName = "Recover";
        bA.playAnimate.SetTrigger("Recover");
        bA.description = "Recovers 30 health and stamina points";
        bA.attackDmg = 0;
        bA.attackStm = 0;
    }

    void specialTask()
    {
        bA.attackName = "Special";
        bA.playAnimate.SetTrigger("Special");
        bA.description = "Difficult attack that deals 40 damage to enemy and reduces stamina 35 points";
        bA.attackDmg = 40;
        bA.attackStm = 35;
        if (player.currentStamina < bA.attackStm)
        {
            //Need to display that there is not enough stamina
            Debug.Log("There is not enough stamina for this move");

        }
    }

}

//Buttons done from https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
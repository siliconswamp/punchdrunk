using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MatchTurnPlayer : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    public MatchTurn turn;
    public BaseAttack bA; //what the attacks call upon
    public SceneChanger scene;

    public Button atck1, atck2, recover, special, menu;//can be renamed

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void doPlayerTurn()
    {
        Debug.Log("Player state: In doPlayerTurn");

        if (player.currentHP <= 0)
        {
            player.isDead = true;
            turn.PlayerTurn = false;
            turn.EnemyTurn = false;

        }
        else
        {
            player.Guard = false;
            if (enemy.currentHP <= 0)
            {
                enemy.isDead = true;
                turn.PlayerTurn = false;
                turn.EnemyTurn = false;
            }
        }
        selectAction();
        doAction();
        yieldPTurn();
    }



    void selectAction()
    {
        Debug.Log("Player state: In selectAction");
        //moveset.doMove(moveNum);
        //Player chooses action to do
        //Believe I need to add a wait for player to choose action
        //https://forum.unity.com/threads/button-click-and-enumerator-solved.433367/
        atck1.onClick.AddListener(atck1Task);
        atck2.onClick.AddListener(atck2Task);
        recover.onClick.AddListener(recoverTask);
        special.onClick.AddListener(specialTask);
        menu.onClick.AddListener(menuTask);
    }

    void doAction()
    {
        Debug.Log("Player state: In doAction");
        //update enemy and player stats
        //include evasion and guard stuff here
        enemy.currentHP -= bA.attackDmg;
        player.currentStamina -= bA.attackStm;
        player.playerUpdateBars();
        enemy.enemyUpdateBars();
    }
    void yieldPTurn()
    {
        Debug.Log("Player state: In yieldPTurn");
         turn.PlayerTurn = false;
         turn.EnemyTurn = true;

    }


    //Various Tasks relative to each button

    void atck1Task()
    {
        //bA.attackName = "Jab";
        //Need to rename attack
        bA.playAnimate.SetTrigger("atck1");
        bA.description = "Simple attack that deals 10 damage to enemy and does not affect stamina";
        bA.attackDmg = 10;
        bA.attackStm = 0;
    }

    void atck2Task()
    {
        //bA.attackName = "Cross";
        //Need to rename attack
        bA.playAnimate.SetTrigger("atck2");
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

    void menuTask()
    {
        scene.mainMenu();
    }

}

//Buttons done from https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
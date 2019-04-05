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
    public MatchTurnEnemy MTE;
    public BaseAttack bA; //what the attacks call upon
    public SceneChanger scene;

    private float HPpercentage;
    private float staminaPercentage;
    public Image PlayerHPProgressBar;
    public Image PlayerStaminaProgressBar;
    public Text output;

    public Button atck1, atck2, recover, special, menu;//can be renamed


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
        //selectAction();
        //doAction();
        //yieldPTurn();
    }

    public void playerUpdateBars()
    {
        HPpercentage = (float)player.currentHP / player.baseHP;
        PlayerHPProgressBar.fillAmount = HPpercentage;
        staminaPercentage = (float)player.currentStamina / player.baseStamina;
        PlayerStaminaProgressBar.fillAmount = staminaPercentage;
    }

    /*void selectAction()
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
    }*/

    //****** might want to rename function *********
    public void playerSelect(int move)
    {

        var rand = Random.Range(0, 100);
        Debug.Log("The random value is: " + rand);

        if(move == 1)
        {
            enemy.currentHP -= 5;
            player.currentStamina += 10;
            Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
            Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
            playerUpdateBars();
            MTE.enemyUpdateBars();
        }

        if(move == 2)
        {


            if (rand > 10)
            {
                if (canDoMove(15) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    yieldPTurn();
                }
                else
                {
                    enemy.currentHP -= 10;
                    player.currentStamina -= 15;
                    Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
                    Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
                    playerUpdateBars();
                    MTE.enemyUpdateBars();
                }
            }

            else
            {
                Debug.Log("Player Missed!");
                output.text = "You missed!";
                yieldPTurn();
            }
        }

        if(move == 3)
        {
            /*if (player.currentStamina < player.baseStamina)
        {
            player.currentStamina += 30;
        }*/

            if (rand > 50)
            {
                if (canDoMove(30) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    yieldPTurn();
                }
                else
                {
                    if (player.currentHP < player.baseHP)
                    {
                        player.currentHP += 30;
                        player.currentStamina -= 30;
                    }
                }
            }
            else
            {
                Debug.Log("Player Missed!");
                output.text = "You missed!";
                yieldPTurn();
            }
       
        }

        if (rand > 60)
        {
            if (move == 4)
            {
                if (canDoMove(35) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    yieldPTurn();
                }
                else
                {
                    enemy.currentHP -= 40;
                    player.currentStamina -= 35;
                    Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
                    Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
                    playerUpdateBars();
                    MTE.enemyUpdateBars();
                }

            }
        }

        if (move == 5)
        {
            menuTask();
        }

        else
        {
            Debug.Log("Player Missed!");
            output.text = "You missed!";
            yieldPTurn();
        }

        yieldPTurn();
    }

    bool canDoMove(float stmAmt) //checks to see if there is enough stamina
    {
        float stm;
        stm = player.currentStamina - stmAmt;
        if (stm <= 0)
        {
            return false;
        }
        return true;

    }

    void yieldPTurn()
    {
        output.text = "";
        turn.PlayerTurn = false;
        turn.EnemyTurn = true;

    }

    /*
    void ChooseAction() //Does different tasks based on what user chooses
        //need to rename
    {
        Debug.Log("Choose Attack!");
        atck1.onClick.AddListener(atck1Task);
        atck2.onClick.AddListener(atck2Task);
        recover.onClick.AddListener(recoverTask);
        special.onClick.AddListener(specialTask);
        menu.onClick.AddListener(menuTask);
    }

    //Various Tasks relative to each button

        
    void atck1Task()
    {
        bA.attackName = "Jab";
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
        //bA.playAnimate.SetTrigger("atck2");
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
    }*/


    void menuTask()
    {
        scene.mainMenu();
    }

}

//Buttons done from https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
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
    public SceneChanger scene;
    public Animator player_animate;

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
            turn.won = false;

        }
        else
        {
            player.Guard = false;
            if (enemy.currentHP <= 0)
            {
                turn.won = true;
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

    void moveTowards() {
        float speed = 20.0f;
        //MOVE ON ATTACK
        player.transform.position = Vector2.MoveTowards(player.transform.position, enemy.transform.position, speed);
    }

    void updateSize() {
        if(player.currentHP > enemy.currentHP) {
            player.transform.localScale = new Vector2(200.0f, 200.0f);
            enemy.transform.localScale = new Vector2(100.0f, 100.0f);

        }

        if(enemy.currentHP > player.currentHP) {
            enemy.transform.localScale = new Vector2(200.0f, 200.0f);
            player.transform.localScale = new Vector2(100.0f, 100.0f);
        }
    }

    //****** might want to rename function *********
    public void playerSelect(int move)
    {
        var rand = Random.Range(0, 100);
        Debug.Log("The random value is: " + rand);
        
        if (player.isPoisoned)
        {
            player.currentHP -= 5;
            playerUpdateBars();
        }

        if (move == 1)
        {
            player_animate.SetTrigger("player_blackhole_attack");
            enemy.currentHP -= player.a1h;
            player.currentStamina += player.a1s;
            Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
            Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
            playerUpdateBars();
            MTE.enemyUpdateBars();
            moveTowards();
            StartCoroutine(waitTime());
        }

        if(move == 2)
        {


            if (rand > 10)
            {
                if (canDoMove(15) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    atck2.interactable = false;
                    // yieldPTurn();

                }
                else
                {
                    player_animate.SetTrigger("player_blackhole_attack");
                    enemy.currentHP -= player.a2h;
                    player.currentStamina -= player.a2s;

                    Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
                    Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
                    playerUpdateBars();
                    MTE.enemyUpdateBars();
                    moveTowards();
                    StartCoroutine(waitTime());
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
            
            if (rand > 10)
            {
                if (canDoMove(30) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    recover.interactable = false;
                    //yieldPTurn();
                }
                else
                {
                    if (player.currentHP < player.baseHP)
                    {
                        player_animate.SetTrigger("player_blackhole_attack");
                        player.currentHP += player.recovh;
                        player.currentStamina -= player.recovs;
                        moveTowards();
                        StartCoroutine(waitTime());
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

        if (move == 4)   
        {
            if (rand > 60)
            {
                if (canDoMove(35) == false)
                {
                    Debug.Log("Not enough player stamina");
                    output.text = "Not enough stamina to perform action!";
                    special.interactable = false;
                    //yieldPTurn();
                }
                else
                {
                    player_animate.SetTrigger("player_blackhole_attack");
                    enemy.currentHP -= player.specialh;
                    player.currentStamina -= player.specials;
                    Debug.Log("Player Attacks... enemy hp: " + enemy.currentHP);
                    Debug.Log("Player Attacks... player stamina: " + player.currentStamina);
                    playerUpdateBars();
                    MTE.enemyUpdateBars();
                    moveTowards();
                    StartCoroutine(waitTime());
                }

            }

            else
            {
                Debug.Log("Player Missed!");
                output.text = "You missed!";
                yieldPTurn();
            }
        }

        if (move == 5)
        {
            menuTask();
        }

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


    IEnumerator waitTime()
    {
        atck1.interactable = false;
        atck2.interactable = false;
        recover.interactable = false;
        special.interactable = false;
        menu.interactable = false;
        yield return new WaitForSeconds(2);
        yieldPTurn();
    }

    void menuTask()
    {
        scene.mainMenu();
    }

    public void Start()
    {
        atck1.interactable = true;
        atck2.interactable = true;
        recover.interactable = true;
        special.interactable = true;
        menu.interactable = true;
    }
    public void Update() {
        updateSize();
    }

}

//Buttons done from https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Don
[System.Serializable]
public class MatchTurnEnemy : MonoBehaviour
{
    public PlayerObject player;
    public EnemyObject enemy;
    public MatchTurn turn;
    public MatchTurnPlayer MTP;
    public BaseAttack enemyAtk;
    public Animator enemy_animate;
    public float HPpercentage;
    public float staminaPercentage;
    public Image EnemyHPProgressBar;
    public Image EnemyStaminaProgressBar;
    public bool skipTurn = false;
    public SceneChanger scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void moveTowards() {
        float speed = 20.0f;
        //MOVE ON ATTACK
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed);
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
        if (skipTurn == false)
            enemy.tree = enemy.BuildTree();
        if (skipTurn == true)
            skipTurn = false;
        enemy.tree.RunBehaviorTree();
        yieldETurn();
    }

    public void yieldETurn()
    {
        if (player.currentHP <= 0)
        {
            scene.lose();
        }
        turn.PlayerTurn = true;
        MTP.atck1.interactable = true;
        MTP.atck2.interactable = true;
        MTP.recover.interactable = true;
        MTP.special.interactable = true;
        MTP.menu.interactable = true;
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
        moveTowards();
        Debug.Log("***EnemyMove1***");
        
        enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
        //enemyAtk.attackDmg = 5;
        // enemyAtk.attackStm = +10;
        player.currentHP -= 5;
        enemy.currentStamina += 10;
        if (enemy.currentStamina > enemy.baseStamina)
            enemy.currentStamina = enemy.baseStamina;
        Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
        enemyUpdateBars();
        MTP.playerUpdateBars();
    }

    
    public void EnemyMove2()
    {
        float chance = MissGenerator();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "FIGHT3")
        {
            if (chance > 0.03)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove2***");
                //enemyAtk.attackDmg = 10;
                // enemyAtk.attackStm = 5;
                player.currentHP -= 10;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 5;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else if (sceneName == "FIGHT2")
        {
            if (chance > 0.05)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove2***");
                //enemyAtk.attackDmg = 10;
                // enemyAtk.attackStm = 5;
                player.currentHP -= 10;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 5;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else
        {
            if (chance > 0.10)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove2***");
                //enemyAtk.attackDmg = 10;
                // enemyAtk.attackStm = 5;
                player.currentHP -= 10;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 5;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!)");
        }
    }

    public void EnemyMove3()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        float chance = MissGenerator();

        if (sceneName == "FIGHT3")
        {
            if (chance > 0.3)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove3***");
                //enemyAtk.attackDmg = 20;
                // enemyAtk.attackStm = 15;
                player.currentHP -= 20;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 15;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else if (sceneName == "FIGHT2")
        {
            if (chance > 0.4)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove3***");
                //enemyAtk.attackDmg = 20;
                // enemyAtk.attackStm = 15;
                player.currentHP -= 20;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 15;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else
        {
            if (chance > 0.5)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove3***");
                //enemyAtk.attackDmg = 20;
                // enemyAtk.attackStm = 15;
                player.currentHP -= 20;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 15;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
    }

    public void EnemyMove4()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        float chance = MissGenerator();

        if (sceneName == "FIGHT3")
        {
            if (chance > 0.6)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove4***");
                //enemyAtk.attackDmg = 30;
                // enemyAtk.attackStm = 20;
                player.currentHP -= 30;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 20;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else if (sceneName == "FIGHT2")
        {
            if (chance > 0.7)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove4***");
                //enemyAtk.attackDmg = 30;
                // enemyAtk.attackStm = 20;
                player.currentHP -= 30;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 20;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
        else
        {
            if (chance > 0.8)
            {
                moveTowards();
                enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
                Debug.Log("***EnemyMove4***");
                //enemyAtk.attackDmg = 30;
                // enemyAtk.attackStm = 20;
                player.currentHP -= 30;
                Debug.Log("Enemy attacks... player hp: " + player.currentHP);
                enemy.currentStamina -= 20;
                Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
                enemyUpdateBars();
                MTP.playerUpdateBars();
            }
            else
                Debug.Log("Enemy missed!");
        }
    }

    public void EnemySkipTurn()
    {
        skipTurn = true;
        Debug.Log("Enemy is charging attack!");
    }

    public float MissGenerator()
    {
        return UnityEngine.Random.Range(0f, 1f);
    }

    // Depletes Player Stamina
    public void EnemyMove5()
    {
        float chance = MissGenerator();
        if (chance > 0.5)
        {
            moveTowards();
            //enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
            Debug.Log("***EnemyMove5***");
            //enemyAtk.attackDmg = 10;
            // enemyAtk.attackStm = 15;
            player.currentHP -= 10;
            player.currentStamina = player.currentStamina / 2;
            Debug.Log("Enemy attacks... player stamina: " + player.currentHP);
            enemy.currentStamina -= 15;
            Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
            enemyUpdateBars();
            MTP.playerUpdateBars();
        }
        else
            Debug.Log("Enemy missed!");
    }

    //Poison attack
    public void EnemyMove6()
    {
        float chance = MissGenerator();
        if (chance > 0.5)
        {
            moveTowards();
            //enemy_animate.SetTrigger("BlackHole_DarkRed3_Attack");
            Debug.Log("***EnemyMove6***");
            //enemyAtk.attackDmg = 10;
            // enemyAtk.attackStm = 15;
            if (player.isPoisoned == false)
            {
                player.currentHP -= 10;
                player.isPoisoned = true;
                Debug.Log("Enemy attacks... player poisoned " + player.currentHP);
            }
            else
                player.currentHP -= 15;
                Debug.Log("Enemy attacks... player hp:" + player.currentHP);
            enemy.currentStamina -= 15;
            Debug.Log("Enemy attacks... enemy stamina: " + enemy.currentStamina);
            enemyUpdateBars();
            MTP.playerUpdateBars();
        }
        else
            Debug.Log("Enemy missed!");
    }
}

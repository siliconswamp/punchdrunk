using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public SavePrefs prefs;
    public float HPpercentage;
    public Image HPProgressBar;

    public bool isDead;
    public bool Guard;
    public bool Evasion;

    public EnemyBehaviorTree tree;
    public int TurnCount { get; set; }
    public bool HighHPStatus = true;
    public bool MiddleHPStatus = false;
    public bool LowHpStatus = false;
    public bool FirstTurnStatus = true;
    public bool SkipStatus = false;

    [HideInInspector]
    public float baseHP = 200, currentHP;

    public Result EnemyMove1inTree(EnemyBehaviorTree tree)
    {
        //enemyMove1();
        return new Result(true);
    }

    public Result EnemyMove2inTree(EnemyBehaviorTree tree)
    {
        //enemyMove2();
        return new Result(true);
    }

    public Result EnemyMove3inTree(EnemyBehaviorTree tree)
    {
        //enemyMove3();
        return new Result(true);
    }

    public Result EnemyMove4inTree(EnemyBehaviorTree tree)
    {
        //enemyMove4();
        return new Result(true);
    }

    public bool IsAboveThreeQuartersHP()
    {
        if (currentHP >= 0.75 * baseHP)
            return true;
        else
            return false;
    }

    public bool IsBetweenOneQuarterAndThreeQuartersHP()
    {
        if (currentHP >= 0.25 * baseHP && currentHP < 0.75 * baseHP)
            return true;
        else
            return false;
    }

    public bool IsBelowOneQuarterHP()
    {
        if (currentHP < 0.25 * baseHP)
            return true;
        else
            return false;
    }

    public Result IfHighHP(EnemyBehaviorTree tree)
    {
        if (IsAboveThreeQuartersHP())
            HighHPStatus = true;
        else
            HighHPStatus = false;
        return new Result(HighHPStatus);
    }

    public Result IfMiddleHP(EnemyBehaviorTree tree)
    {
        if (IsBetweenOneQuarterAndThreeQuartersHP())
            MiddleHPStatus = true;
        else
            MiddleHPStatus = false;
        return new Result(MiddleHPStatus);
    }

    public Result IfLowHp(EnemyBehaviorTree tree)
    {
        if (IsBelowOneQuarterHP())
            LowHpStatus = true;
        else
            LowHpStatus = false;
        return new Result(LowHpStatus);
    }

    public Result IfFirstTurnInHpState(EnemyBehaviorTree tree)
    {
        if (IsFirstTurnInHPState())
            FirstTurnStatus = true;
        else
            FirstTurnStatus = false;
        return new Result(FirstTurnStatus);
    }

    public bool IsFirstTurnInHPState()
    {
        if (TurnCount == 0)
            return true;
        else
            return false;
    }

    public Result DummyNode(EnemyBehaviorTree tree)
    {
        return new Result(true);
    }

    public EnemyBehaviorTree BuildTree()
    {

        Dictionary<Node, float> HighHPMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove1inTree), 0.5F },
                { new Leaf(EnemyMove2inTree), 0.5F }
            };

        Dictionary<Node, float> MiddleHPMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove2inTree), 0.5F },
                { new Leaf(EnemyMove3inTree), 0.5F },
            };

        Dictionary<Node, float> LowHPMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove1inTree), 0.25F },
                { new Leaf(EnemyMove2inTree), 0.25F },
                { new Leaf(EnemyMove3inTree), 0.25F },
                { new Leaf(EnemyMove4inTree), 0.25F }
            };

        var LowHP = new SelectorRandomArray(LowHPMoveset);
        var MiddleHP = new SelectorRandomArray(MiddleHPMoveset);
        var HighHP = new SelectorRandomArray(HighHPMoveset);

        var FirstTurnAtLowHP = new Selector(IfFirstTurnInHpState, new Leaf(EnemyMove4inTree), LowHP);
        var FirstTurnAtMiddleHP = new Selector(IfFirstTurnInHpState, new Leaf(EnemyMove3inTree), MiddleHP);

        var CheckHPIsLow = new Selector(IfLowHp, FirstTurnAtLowHP, new Leaf(DummyNode));
        var CheckHPIsMedium = new Selector(IfMiddleHP, FirstTurnAtMiddleHP, CheckHPIsLow);
        var CheckHPIsHigh = new Selector(IfHighHP, HighHP, CheckHPIsMedium);

        EnemyBehaviorTree TempTree = new EnemyBehaviorTree(CheckHPIsHigh, 1000); // 1000 is an arbitrary high number for the tree to cycle again

        /* Simple Tree Test
        var ExampleTree = new Selector(IfHighHP, new Leaf(EnemyMove1inTree), new Leaf(EnemyMove2inTree));

        EnemyBehaviorTree TempTree = new EnemyBehaviorTree(ExampleTree, 1000);
        */
        Debug.Log("Enemy Behavior Tree is built.");
        return TempTree;

    }
    
    void Start()
    {
        tree = BuildTree();
    }

    public void UpdateBars()
    {
        HPpercentage = (float)currentHP / baseHP;
        HPProgressBar.fillAmount = HPpercentage;
    }

}

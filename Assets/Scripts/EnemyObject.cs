using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class EnemyObject : MonoBehaviour
{
    public bool isDead;
    public bool Guard;
    public bool Evasion;

    public MatchTurnEnemy mte;
    public EnemyBehaviorTree tree;
    public int TurnCount { get; set; }
    public bool HighHPStatus = true;
    public bool MiddleHPStatus = false;
    public bool LowHpStatus = false;
    public bool FirstTurnStatus = true;
    public bool SkipStatus = false;
    public int StaminaCheck;

    [HideInInspector]
    public float baseHP = 200, currentHP, baseStamina = 100, currentStamina;

    public void Start()
    {
        currentHP = Mathf.Clamp(currentHP, 0, 200);
        currentStamina = Mathf.Clamp(currentStamina, 0, 100);
        currentHP = baseHP;
        currentStamina = baseStamina;
        tree = BuildTree();
    }

    public void Update()
    {
        
    }

    public Result EnemyMove1inTree(EnemyBehaviorTree tree)
    {
        mte.EnemyMove1();
        return new Result(true);
    }

    public Result EnemyMove2inTree(EnemyBehaviorTree tree)
    {
        mte.EnemyMove2();
        return new Result(true);
    }

    public Result EnemyMove3inTree(EnemyBehaviorTree tree)
    {
        mte.EnemyMove3();
        return new Result(true);
    }

    public Result EnemyMove4inTree(EnemyBehaviorTree tree)
    {
        mte.EnemyMove4();
        return new Result(true);
    }

    public Result EnemySkipInTree(EnemyBehaviorTree tree)
    {
        mte.EnemySkipTurn();
        return new Result(true);
    }

    public int HasEnoughStamina()
    {
        int check;
        if (currentStamina < 5) // check stamina for move2
            check = 1;
        else if (currentStamina < 15) // for move3 
            check = 2;
        else if (currentStamina < 20) // for move4
            check = 3;
        else
            check = 0;
        return check;
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

    public Result IfHasStamina(EnemyBehaviorTree tree) // checks stamina, assigns a number which determines the possible moveset
    {
        switch (StaminaCheck)
        {
            case 1:
                return new Result(1);
            case 2:
                return new Result(2);
            case 3:
                return new Result(3);
            case 0:
                return new Result(0);
            default:
                return new Result(0);
        }
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
        Dictionary<Node, float> OneTwoMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove1inTree), 0.5F },
                { new Leaf(EnemyMove2inTree), 0.5F }
            };

        Dictionary<Node, float> TwoThreeMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove2inTree), 0.5F },
                { new Leaf(EnemyMove3inTree), 0.5F },
            };

        Dictionary<Node, float> AllMoveset = new Dictionary<Node, float>
            {
                { new Leaf(EnemyMove1inTree), 0.25F },
                { new Leaf(EnemyMove2inTree), 0.25F },
                { new Leaf(EnemyMove3inTree), 0.25F },
                { new ChainLeaf(EnemySkipInTree, new Leaf(EnemyMove4inTree)), 0.25F }
            };

        var SelectorForOneTwo = new SelectorRandomArray(OneTwoMoveset.Shuffle());
        var SelectorForTwoThree = new SelectorRandomArray(TwoThreeMoveset.Shuffle());
        var SelectorForAllMoves = new SelectorRandomArray(AllMoveset.Shuffle());

        Node[] HighHPMovelist = { SelectorForOneTwo, new Leaf(EnemyMove1inTree) };
        Node[] BeginMidHPMovelist = { SelectorForOneTwo, new Leaf(EnemyMove1inTree) };
        Node[] MiddleHPMovelist = { SelectorForTwoThree, new Leaf(EnemyMove1inTree), SelectorForOneTwo };
        Node[] BeginLowHPMovelist = { SelectorForTwoThree, new Leaf(EnemyMove1inTree), SelectorForOneTwo };
        Node[] LowHPMovelist = { SelectorForAllMoves, new Leaf(EnemyMove1inTree), SelectorForOneTwo, SelectorForTwoThree };
        
        var CheckStaminaAtHighHP = new SelectorArray(IfHasStamina, HighHPMovelist);
        var CheckStaminaAtBeginMidHP = new SelectorArray(IfHasStamina, BeginMidHPMovelist);
        var CheckStaminaAtMiddleHP = new SelectorArray(IfHasStamina, MiddleHPMovelist);
        var CheckStaminaAtBeginLowHP = new SelectorArray(IfHasStamina, BeginLowHPMovelist);
        var CheckStaminaAtLowHP = new SelectorArray(IfHasStamina, LowHPMovelist);
        
        var FirstTurnAtLowHP = new Selector(IfFirstTurnInHpState, CheckStaminaAtBeginLowHP, CheckStaminaAtLowHP);
        var FirstTurnAtMiddleHP = new Selector(IfFirstTurnInHpState, CheckStaminaAtBeginMidHP, CheckStaminaAtMiddleHP);

        var CheckHPIsLow = new Selector(IfLowHp, FirstTurnAtLowHP, new Leaf(DummyNode));
        var CheckHPIsMedium = new Selector(IfMiddleHP, FirstTurnAtMiddleHP, CheckHPIsLow);
        var CheckHPIsHigh = new Selector(IfHighHP, CheckStaminaAtHighHP, CheckHPIsMedium);

        EnemyBehaviorTree TempTree = new EnemyBehaviorTree(CheckHPIsHigh, 1000); // 1000 is an arbitrary high number for the tree to cycle again

        Debug.Log("Enemy Behavior Tree is built.");
        return TempTree;
    }
}

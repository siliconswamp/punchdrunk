using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectorArray : Node
{
    private Func<EnemyBehaviorTree, Result> conditionFunction;
    private Node[] leafArray;

    public SelectorArray(Func<EnemyBehaviorTree, Result> conditionFunction, Node[] leafArray)
    {
        this.conditionFunction = conditionFunction;
        this.leafArray = leafArray;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        var state = tree.NodeAndState[this];

        if (state == EnemyBehaviorTree.NodeState.RUNNING)
            return new Result(true);

        int resultInt = conditionFunction(tree).IntegerResult;

        if (state == EnemyBehaviorTree.NodeState.RUNNING)
            return new Result(true);

        for (var i = 0; i < leafArray.Count(); i++)
        {
            if (i == resultInt)
                tree.NodeAndState[leafArray[i]] = EnemyBehaviorTree.NodeState.IN_QUEUE;
            else
                tree.NodeAndState[leafArray[i]] = EnemyBehaviorTree.NodeState.IGNORE;
        }

        return new Result(resultInt);
    }

    public bool IsConditional()
    {
        return true;
    }

    public List<Node> Children()
    {
        return leafArray.ToList();
    }
}



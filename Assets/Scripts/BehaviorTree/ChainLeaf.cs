using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLeaf : Node
{
    private readonly Func<EnemyBehaviorTree, Result> action;
    private Node linkedLeaf;

    public ChainLeaf(Func<EnemyBehaviorTree, Result> action, Node link)
    {
        this.action = action;
        this.linkedLeaf = link;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        return action(tree);
    }

    public bool IsConditional()
    {
        return false;
    }

    public List<Node> Children()
    {
        return new List<Node> { linkedLeaf };
    }
}


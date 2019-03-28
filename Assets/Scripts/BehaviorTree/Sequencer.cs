using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Sequencer : Node
{
    private Node[] leafArray;

    public Sequencer(Node[] leafArray)
    {
        this.leafArray = leafArray;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        tree.NodeAndState[this] = EnemyBehaviorTree.NodeState.WAITING;
        tree.NodeAndState[leafArray[0]] = EnemyBehaviorTree.NodeState.IN_QUEUE;
        return new Result(true);
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

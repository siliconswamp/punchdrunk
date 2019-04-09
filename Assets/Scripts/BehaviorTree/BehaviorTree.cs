using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://designagame.eu/2015/05/simple-behaviour-trees-for-your-game-in-javascript-and-c/
//https://hub.packtpub.com/building-your-own-basic-behavior-tree-tutorial/

public class EnemyBehaviorTree
{
    public enum NodeState
    {
        FAILURE,
        SUCCESS,
        RUNNING,
        IN_QUEUE,
        IGNORE,
        COMPUTING,
        WAITING
    };

    private Node root;
    private int numberOfLoops;
    private int numberOfRuns = 0;
    public bool Completed = false;

    public Dictionary<Node, NodeState> NodeAndState = new Dictionary<Node, NodeState>();

    private Node currentNode = null;

    public EnemyBehaviorTree(Node root, int numberOfLoops)
    {
        this.root = root;
        this.currentNode = root;
        this.numberOfLoops = numberOfLoops;
    }

    public Node FindCurrentNode(Node node)
    {
        if (!NodeAndState.ContainsKey(node))
        {
            NodeAndState[node] = NodeState.IN_QUEUE;
            return node;
        }

        var state = NodeAndState[node];

        if (state == NodeState.IGNORE)
            return null;

        if (state == NodeState.RUNNING ||
            state == NodeState.COMPUTING ||
            state == NodeState.IN_QUEUE)
            return node;

        var children = node.Children();
        if (children == null)
            return null;
        else
        {
            for (var i = 0; i < node.Children().Count; i++)
            {
                var childNode = FindCurrentNode(children[i]);
                if (childNode != null)
                    return childNode;
            }

            if (state == NodeState.WAITING)
            {
                NodeAndState[node] = NodeState.SUCCESS;
            }
        }

        return null;
    }

    public Result RunBehaviorTree()
    {
        Debug.Log("Begin tree run");
        // Reaching the end of the tree, and marking complete (for behavior trees run once)
        if (Completed)
        {
            Debug.Log("End " + currentNode);
            return new Result(true);
        }

        currentNode = FindCurrentNode(root);

        if (currentNode == null)
        {
            numberOfRuns++;
            if (numberOfLoops == 0 || numberOfRuns < numberOfLoops)
            {
                NodeAndState = new Dictionary<Node, NodeState>();
                currentNode = FindCurrentNode(root);
            }
            else
            {
                Completed = true;
                return new Result(true);
            }
        }

        // Processing nodes
        bool toBeStarted = false;
        if (NodeAndState.ContainsKey(currentNode))
            toBeStarted = NodeAndState[currentNode] == NodeState.IN_QUEUE;
        else
            toBeStarted = true;

        if (toBeStarted)
        {
            Result result = currentNode.Execute(this);
            Debug.Log("Current node executed " + currentNode);
            var afterState = NodeAndState[currentNode];

            if (afterState == NodeState.IN_QUEUE)
                NodeAndState[currentNode] = NodeState.SUCCESS;
            Debug.Log("End " + currentNode);
            
            if (currentNode.Children() != null)
            {
                if (currentNode.Children().Count == 1) // For EnemySkipTurn and charging moves
                    return result;
                else
                    RunBehaviorTree(); // recursively calls function when node has child to process
            }
            else
                return result;
        }

        NodeState state = NodeAndState[currentNode];

        if (state == NodeState.COMPUTING)
        {
            Result result = currentNode.Execute(this);
            NodeAndState[currentNode] = NodeState.SUCCESS;
            return result;
        }
        Debug.Log("End of tree.");
        return null;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    AStarScript grid;

    public Transform startObject;
    public Transform TargetObject;

    private void Awake()
    {
        grid = GetComponent<AStarScript>();
    }


    // Update is called once per frame
    void Update()
    {
        FindPath(startObject.position, TargetObject.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Anode startNode = grid.GetNodeFromworldPoint(startPos);
        Anode targetNode = grid.GetNodeFromworldPoint(targetPos);

        List<Anode> openList = new List<Anode>();
        HashSet<Anode> closeList = new HashSet<Anode>();
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Anode currentNode = openList[0];

            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }
        }
    }
}

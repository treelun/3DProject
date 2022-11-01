using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anode
{
    public bool isWalkable;
    public Vector3 worldPos;

    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Anode parentNode;

    public Anode(bool nWalkable, Vector3 nworldPos, int nGridX, int nGridY)
    {
        isWalkable = nWalkable;
        worldPos = nworldPos;
        gridX = nGridX;
        gridY = nGridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}

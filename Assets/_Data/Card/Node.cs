using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    public int x = 0;
    public int y = 0;
    public float posY = 0;
    public bool occupied = false;
    public int nodeId;
    public BlockCtrl blockCtrl;
}

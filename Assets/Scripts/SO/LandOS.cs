using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandOS : ScriptableObject
{
    public int X;
    public int Y;
    public int CellSize;

    public List<GameObject> TreeList = new List<GameObject>();
}

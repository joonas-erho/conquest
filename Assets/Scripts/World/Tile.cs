using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData tileData;

    public void Initialize(int column, int row)
    {
        tileData = new TileData(column, row);
    }

    public int GetColumnAndRow(int i)
    {
        if (i == 0) return tileData.GetColumn();
        else if (i == 1) return tileData.GetRow();
        else
        {
            Debug.Log("Illegal index!");
            return -1;
        }
    }
}

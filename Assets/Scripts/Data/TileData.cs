using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    private int column;
    private int row;

    public TileData(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public int GetColumn()
    {
        return column;
    }

    public int GetRow()
    {
        return row;
    }
}

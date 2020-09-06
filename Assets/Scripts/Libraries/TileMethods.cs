using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMethods
{
    public static Vector3 SetTilePosition(Tile tile)
    {
        Vector3 newPosition = new Vector3(0, 0, 0);

        newPosition.x += (float)tile.GetColumnAndRow(0) * Const.WIDTH + (float)tile.GetColumnAndRow(1) * Const.HALF_WIDTH;
        newPosition.y += (float)tile.GetColumnAndRow(1) * 0.75f;

        return newPosition;
    }
}

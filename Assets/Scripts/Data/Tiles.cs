using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles
{
    private int columns;
    private int rows;
    private Tile[,] tiles;

    public Tiles(int c, int r)
    {
        columns = c;
        rows = r;
        tiles = new Tile[c, r];
    }

    public void AddTile(Tile tile)
    {
        int c = tile.GetColumn();
        int r = tile.GetRow();
        tiles[c, r] = tile;
    }

    public Tile GetTile(int c, int r)
    {
        try {
            return tiles[c, r];
        }
        catch {
            Debug.Log("Illegal index!");
            return null;
        }
    }
}

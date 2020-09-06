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

    }
}

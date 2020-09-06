using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    //The prefab of a single tile
    public GameObject tilePrefab;

    /// <summary>
    /// Generate a new world from scratch.
    /// </summary>
    /// <param name="columns">Amount of columns (width of the map)</param>
    /// <param name="rows">Amount of rows (height of the map)</param>
    /// <param name="tiles">The tiles object that will contain a reference to all tiles</param>
    public void GenerateNewWorld(int columns, int rows, Tiles tiles)
    {
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                InitializeTile(c,r,tiles);
            }
        }
    }

    /// <summary>
    /// Initialize a single tile, and add it to the tiles object
    /// </summary>
    /// <param name="column">The column that this tile will be spawned in</param>
    /// <param name="row">The row that this tile will be spawned in</param>
    /// <param name="tiles">The tiles object that will contain this tile </param>
    private void InitializeTile(int column, int row, Tiles tiles)
    {
        //Initialize gameobject
        GameObject tileObject = (GameObject)Instantiate(tilePrefab);

        //Get tile, initialize tiledata within tile and add to tiles
        Tile tile = tileObject.GetComponent<Tile>();
        tile.Initialize(column, row);
        tiles.AddTile(tile);

        //Set parent of gameobject to this
        tileObject.transform.SetParent(this.transform);

        //Set position of tile
        tileObject.transform.position = TileMethods.SetTilePosition(tile);

        //Set name in Unity editor
        tileObject.name = "TILE " + column + "," + row;
    }
}

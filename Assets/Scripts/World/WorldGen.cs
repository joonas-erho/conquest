using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    //The prefab of a single tile
    public GameObject tilePrefab;

    //Colors for tiles before actual textures are applied
    public Color[] colors;

    //Biomes-class, which holds all biomes
    private Biomes biomes;

    /// <summary>
    /// Generate a new world from scratch.
    /// </summary>
    /// <param name="columns">Amount of columns (width of the map)</param>
    /// <param name="rows">Amount of rows (height of the map)</param>
    /// <param name="tiles">The tiles object that will contain a reference to all tiles</param>
    public void GenerateNewWorld(int columns, int rows, Tiles tiles, IMapType mapType)
    {
        //Create biomes data (preset)
        biomes = CreateBiomes(colors);

        //Initialize tiles
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                InitializeTile(c,r,tiles);
            }
        }

        //Actually generate the map (biomes and features)
        GenerateMap(mapType, columns, rows, tiles, biomes);
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

        tile.SetBiome(biomes.GetBiome("Ocean"));
    }

    private Biomes CreateBiomes(Color[] colors)
    {
        return new Biomes(colors);
    }

    private void GenerateMap(IMapType mapType, int columns, int rows, Tiles tiles, Biomes biomes)
    {
        mapType.GenerateMap(columns, rows, tiles, biomes);
    }
}

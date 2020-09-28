using System;
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

    //biomes
    public Biome[] biomes;

    public NaturalResource[] naturalResources;

    public Dictionary<string, Biome> biomesDict;
    public Dictionary<string, NaturalResource> naturalResourcesDict;

    /// <summary>
    /// Generate a new world from scratch.
    /// </summary>
    /// <param name="columns">Amount of columns (width of the map)</param>
    /// <param name="rows">Amount of rows (height of the map)</param>
    /// <param name="tiles">The tiles object that will contain a reference to all tiles</param>
    public void GenerateNewWorld(int columns, int rows, Tiles tiles, IMapType mapType)
    {
        //Create biomes data (preset)
        biomesDict = CreateBiomeDictionary(biomes);
        naturalResourcesDict = CreateNaturalResourcesDictionary(naturalResources);

        //Initialize tiles
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                InitializeTile(c,r,tiles);
            }
        }

        //Generate landmasses and biomes
        GenerateMap(mapType, columns, rows, tiles, biomesDict);

        //Generate Resources
        GenerateResources(columns, rows, tiles);
    }

    private Dictionary<string, Biome> CreateBiomeDictionary(Biome[] biomes)
    {
        Dictionary<string, Biome> dictionary = new Dictionary<string, Biome>();

        for (int i = 0; i < biomes.Length; i++)
        {
            dictionary.Add(biomes[i].name, biomes[i]);
        }

        return dictionary;
    }
    private Dictionary<string, NaturalResource> CreateNaturalResourcesDictionary(NaturalResource[] naturalResources)
    {
        Dictionary<string, NaturalResource> dictionary = new Dictionary<string, NaturalResource>();

        for (int i = 0; i < biomes.Length; i++)
        {
            dictionary.Add(biomes[i].name, naturalResources[i]);
        }

        return dictionary;
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

        tile.SetBiome(biomesDict["Ocean"]);
    }

    private void GenerateMap(IMapType mapType, int columns, int rows, Tiles tiles, Dictionary<string, Biome> biomes)
    {
        mapType.GenerateMap(columns, rows, tiles, biomes);
    }

    private void GenerateResources(int columns, int rows, Tiles tiles)
    {
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Tile tile = tiles.GetTile(c, r);
                NaturalResource[] resources = tile.GetBiome().resourcesSpawnableOnThisTile;
                foreach(NaturalResource resource in resources)
                {
                    float random = UnityEngine.Random.Range(0f, 1f);
                    if (random < resource.spawnChance)
                    {
                        tile.AddNaturalResource(resource);
                    }
                }
            }
        }
    }
}

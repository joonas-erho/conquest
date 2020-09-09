using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Singleton;
    private void Awake()
    {
        Singleton = this;
    }

    public int mapWidth;
    public int mapHeight;

    public WorldGen worldGen;

    private Tiles tiles;

    private MapTypes mapTypes;

    void Start()
    {
        tiles = new Tiles(mapWidth, mapHeight);
        mapTypes = new MapTypes();
        worldGen.GenerateNewWorld(mapWidth, mapHeight, tiles, mapTypes.GetMapType(0));
    }

    public Tile GetTile(int column, int row)
    {
        return tiles.GetTile(column, row);
    }
}

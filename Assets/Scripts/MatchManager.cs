using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    public WorldGen worldGen;

    void Start()
    {
        Tiles tiles = new Tiles(mapWidth, mapHeight);
        worldGen.GenerateNewWorld(mapWidth, mapHeight, tiles);
    }
}

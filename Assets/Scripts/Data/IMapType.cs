using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapType
{
    void GenerateMap(int columns, int rows, Tiles tiles, Dictionary<string, Biome> biomes);
}

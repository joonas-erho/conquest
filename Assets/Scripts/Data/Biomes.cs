using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that holds all Biomes and all methods that use Biomes.
/// </summary>
public class Biomes
{
    //Dictionary for biomes, with biome name as key.
    private Dictionary<string, Biome> biomes = new Dictionary<string, Biome>();

    public Biomes(Color[] colors)
    {
        CreateBiomes(colors);
    }

    private void CreateBiomes(Color[] colors)
    {
        CreateBiome(0, "Plains", colors[0]);
        CreateBiome(1, "Forest", colors[1]);
        CreateBiome(2, "Desert", colors[2]);
        CreateBiome(3, "Rocky Plains", colors[3]);
        CreateBiome(4, "Ocean", colors[4]);
    }

    //Create a new Biome through the Biome class.
    private void CreateBiome(int id, string name, Color color)
    {
        Biome biome = new Biome(id, name, color);
        biomes.Add(name, biome);
    }

    //Get a biome with a string key from the dictionary.
    public Biome GetBiome(string name)
    {
        return biomes[name];
    }
}

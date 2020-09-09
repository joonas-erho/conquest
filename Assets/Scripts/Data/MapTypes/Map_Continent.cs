using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Continent : IMapType
{
    public Map_Continent()
    {

    }

    public void GenerateMap(int columns, int rows, Tiles tiles, Biomes biomes)
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(columns, rows, Random.Range(0, 100000), 5f, 4, 0.5f, 1f, new Vector2(0, 0));

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                float height = noiseMap[c, r];
                Tile tile = tiles.GetTile(c, r);

                for (int i = 0; i < 7; i++)
                {
                    if (TileMethods.IsNearEdge(tile, i)) height -= Random.Range(0.05f,0.2f);
                }

                if (height > 0.25f) SetRandomBiomes(tile, biomes);
            }
        }
    }

    private void SetRandomBiomes(Tile tile, Biomes biomes)
    {
        float random = Random.Range(0f, 1f);

        if (random < 0.1f)
        {
            tile.SetBiome(biomes.GetBiome("Desert"));
            return;
        }
        if (random < 0.2f)
        {
            tile.SetBiome(biomes.GetBiome("Rocky Plains"));
            return;
        }
        if (random < 0.6f)
        {
            tile.SetBiome(biomes.GetBiome("Forest"));
            return;
        }

        tile.SetBiome(biomes.GetBiome("Plains"));
    }
}

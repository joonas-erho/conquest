using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMethods
{
    public static Vector3 SetTilePosition(Tile tile)
    {
        Vector3 newPosition = new Vector3(0, 0, 0);

        newPosition.x += (float)tile.GetColumn() * ConstantValues.WIDTH + (float)tile.GetRow() * ConstantValues.HALF_WIDTH;
        newPosition.y += (float)tile.GetRow() * 0.75f;

        return newPosition;
    }

    public static bool IsNearEdge(Tile tile, int vincinity)
    {
        int c = tile.GetColumn();
        int r = tile.GetRow();

        if (c < vincinity || r < vincinity || c > MatchManager.Singleton.mapWidth - vincinity || r > MatchManager.Singleton.mapHeight - vincinity) return true;
        return false;
    }

    public static void UpdatePosition(Tile tile, Camera camera)
    {
        float mapWidth = MatchManager.Singleton.mapHeight * ConstantValues.DOUBLE_WIDTH;

        Vector3 position = tile.transform.position;

        if (true) //Later on this should have a condition whether wrapping is allowed (actually move it to the cameracontroller)
        {
            float widthsFromCamera = (position.x - camera.transform.position.x) / mapWidth;

            if (widthsFromCamera > 0)
            {
                widthsFromCamera += 0.5f;
            }
            else
            {
                widthsFromCamera -= 0.5f;
            }

            int widthsToFix = (int)widthsFromCamera;

            position.x -= widthsToFix * mapWidth;
        }

        tile.transform.position = position;
    }

    /// <summary>
    /// Returns tile based on given position
    /// </summary>
    /// <param name="column">Position of tile vertically</param>
    /// <param name="row">Position of the horizontally</param>
    /// <returns>Tile based on the given position, error if given indexes are out of bounds</returns>
    public static Tile GetTile(int column, int row)
    {
        try
        {
            return MatchManager.Singleton.tiles.GetTile(column, row);
        }
        catch
        {
            Debug.Log("Illegal indexes for GetTile in TileMethods!");
            return null;
        }
    }

    /// <summary>
    /// Returns a random tile within the boundaries of the map
    /// </summary>
    /// <returns></returns>
    public static Tile GetRandomTile()
    {
        return MatchManager.Singleton.tiles.GetTile(Random.Range(0, MatchManager.Singleton.mapWidth), Random.Range(0, MatchManager.Singleton.mapHeight));
    }

    /// <summary>
    /// Returns a random land tile within the boundaries of the map, attempting up to ten thousand times
    /// </summary>
    /// <returns></returns>
    public static Tile GetRandomLandTile()
    {
        for (int i = 0; i < 10000; i++)
        {
            Tile randomTile = GetRandomTile();
            if (randomTile.GetBiome().isLand) return randomTile;
        }

        return null;
    }
}

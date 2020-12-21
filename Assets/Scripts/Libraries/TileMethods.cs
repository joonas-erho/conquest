using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMethods
{
    /// <summary>
    /// Sets the position of a tile. Only called during world generation
    /// </summary>
    /// <param name="tile">Tile</param>
    /// <returns>Position for the tile</returns>
    public static Vector3 SetTilePosition(Tile tile)
    {
        Vector3 newPosition = new Vector3(0, 0, 0);

        newPosition.x += (float)tile.GetColumn() * ConstantValues.WIDTH + (float)tile.GetRow() * ConstantValues.HALF_WIDTH;
        newPosition.y += (float)tile.GetRow() * 0.75f;

        return newPosition;
    }

    /// <summary>
    /// Checks if the tile is within the given vincinity of the edge of the map. The edge refers to the top and bottom ends of the map.
    /// </summary>
    /// <param name="tile">Tile</param>
    /// <param name="vincinity">Vincinity in which the tile should be</param>
    /// <returns>Boolean value, true is within the vincinity</returns>
    public static bool IsNearEdge(Tile tile, int vincinity)
    {
        int c = tile.GetColumn();
        int r = tile.GetRow();

        if (c < vincinity || r < vincinity || c > MatchManager.Singleton.mapWidth - vincinity || r > MatchManager.Singleton.mapHeight - vincinity) return true;
        return false;
    }

    /// <summary>
    /// Updates a tiles position relative to given camera
    /// </summary>
    /// <param name="tile">Tile</param>
    /// <param name="camera">Camera</param>
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
    /// <returns>Random tile</returns>
    public static Tile GetRandomTile()
    {
        return MatchManager.Singleton.tiles.GetTile(Random.Range(0, MatchManager.Singleton.mapWidth), Random.Range(0, MatchManager.Singleton.mapHeight));
    }

    /// <summary>
    /// Returns a random land tile within the boundaries of the map, attempting up to ten thousand times
    /// </summary>
    /// <returns>Random land tile</returns>
    public static Tile GetRandomLandTile()
    {
        for (int i = 0; i < 10000; i++)
        {
            Tile randomTile = GetRandomTile();
            if (randomTile.GetBiome().isLand) return randomTile;
        }

        return null;
    }

    /// <summary>
    /// Returns the distance between two tiles
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Distance(Tile a, Tile b)
    {
        int ax = a.GetColumn();
        int ay = a.GetRow();
        int bx = b.GetColumn();
        int by = b.GetRow();

        int columnalDistance = Mathf.Max(ax, bx) - Mathf.Min(ax, bx);

        if (columnalDistance > MatchManager.Singleton.mapWidth / 2)
        {
            if (Mathf.Min(ax, bx) == ax) ax += MatchManager.Singleton.mapWidth;
            else bx += MatchManager.Singleton.mapWidth;
        }

        int az = 0 - ax - ay;
        int bz = 0 - bx - by;

        return Mathf.Max(Mathf.Abs(ax - bx), Mathf.Abs(ay - by), Mathf.Abs(az - bz));
    }
}

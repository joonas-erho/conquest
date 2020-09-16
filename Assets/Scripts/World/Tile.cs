using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int column;
    private int row;
    private Biome biome;

    public void Initialize(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    #region Getters
    public int GetColumn()
    {
        return column;
    }

    public int GetRow()
    {
        return row;
    }

    public Biome GetBiome()
    {
        return biome;
    }
    #endregion

    #region Setters
    public void SetBiome(Biome biome)
    {
        this.biome = biome;
        UpdateBiome();
    }
    #endregion

    private void UpdateBiome()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = biome.color;
    }

    public void OnMouseDown()
    {
        UIController.Singleton.infoScreen.SelectTile(this);
    }
}

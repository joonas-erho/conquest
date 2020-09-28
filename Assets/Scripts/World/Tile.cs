using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private int column;
    private int row;
    private Biome biome;
    private List<NaturalResource> resources = new List<NaturalResource>();

    public SpriteRenderer outlineRenderer;

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

    public int GetNaturalResourcesAmount()
    {
        return resources.Count;
    }

    public NaturalResource GetNaturalResource(int index)
    {
        try
        {
            return resources[index];
        }
        catch
        {
            return null;
        }
    }
    #endregion

    #region Setters
    public void SetBiome(Biome biome)
    {
        this.biome = biome;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = biome.color;
    }
    #endregion

    public void AddNaturalResource(NaturalResource naturalResource)
    {
        resources.Add(naturalResource);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIController.Singleton.infoScreen.SelectTile(this);
    }

}

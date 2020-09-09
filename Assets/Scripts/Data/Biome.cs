﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome
{
    private int biomeId;
    private string biomeName;
    private Color biomeColor;

    public Biome(int id, string name, Color color)
    {
        biomeId = id;
        biomeName = name;
        biomeColor = color;
    }

    #region Getters
    public int GetId()
    {
        return biomeId;
    }

    public string GetName()
    {
        return biomeName;
    }

    public Color GetColor()
    {
        return biomeColor;
    }
    #endregion
}

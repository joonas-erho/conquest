using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTypes
{
    private IMapType[] mapTypes = new IMapType[10];

    public MapTypes()
    {
        Map_Continent mapContinent = new Map_Continent();
        mapTypes[0] = mapContinent;
    }

    public IMapType GetMapType(int index)
    {
        return mapTypes[index];
    }
}

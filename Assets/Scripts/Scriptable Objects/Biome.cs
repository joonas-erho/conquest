using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biome", menuName = "Biome")]
public class Biome : ScriptableObject
{
    public new string name;
    public Color color;

    public Sprite banner;

    public NaturalResource[] resourcesSpawnableOnThisTile;
}

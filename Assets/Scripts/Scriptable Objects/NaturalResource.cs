using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Natural Resource", menuName = "Natural Resource")]
public class NaturalResource : ScriptableObject
{
    public new string name;
    public Sprite icon;

    public float spawnChance;
}

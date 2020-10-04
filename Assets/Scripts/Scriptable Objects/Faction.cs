using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Faction", menuName = "Faction")]
public class Faction : ScriptableObject
{
    public string factionName;
    public Sprite factionBanner;
    public string factionDemonym;
}

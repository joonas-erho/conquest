using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Factions : MonoBehaviour
{
    List<Faction> factionList = new List<Faction>();

    /// <summary>
    /// This script fetches all factions from the factions folder. Later on make this a part of the menu scripts as the gamemanager of a match should only hold the factions in the game.
    /// </summary>
    public void Start()
    {
        string[] assetNames = AssetDatabase.FindAssets("", new[] { "Assets/Scripts/Scriptable Objects/Factions" });
        factionList.Clear();
        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var faction = AssetDatabase.LoadAssetAtPath<Faction>(SOpath);
            factionList.Add(faction);
        }

        //foreach (Faction faction in factionList) Debug.Log(faction.factionName);
    }
}

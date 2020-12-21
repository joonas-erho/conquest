using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FactionManager : MonoBehaviour
{
    public Faction faction;

    public List<Army> armies = new List<Army>();
    public List<Settlement> settlements = new List<Settlement>();

    public string[] defaultSettlementNames;

    public void Start()
    {
        //Set the random province names
        defaultSettlementNames = File.ReadAllLines("Assets\\Text Data\\" + faction.factionName + "\\settlements.txt");
    }

    public void AddArmy(Army army)
    {
        armies.Add(army);
    }

    public void AddSettlement(Settlement settlement)
    {
        settlements.Add(settlement);
    }

}

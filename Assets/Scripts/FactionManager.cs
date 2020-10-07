using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionManager : MonoBehaviour
{
    public Faction faction;

    public List<Army> armies = new List<Army>();


    public void AddArmy(Army army)
    {
        armies.Add(army);
    }

}

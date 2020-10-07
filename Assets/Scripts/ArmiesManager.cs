using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmiesManager : MonoBehaviour
{
    public GameObject specialArmyPrefab;
    public GameObject compositeArmyPrefab;

    public SpecialUnit initialSettler;

    public void SpawnInitialArmies(FactionManager factionManager)
    {
        Tile settlerSpawnTile = TileMethods.GetRandomTile();
        Debug.Log(settlerSpawnTile);
        SpawnSpecialUnit(factionManager, initialSettler, settlerSpawnTile);
    }

    public void SpawnSpecialUnit(FactionManager factionManager, SpecialUnit specialUnit, Tile tile)
    {
        GameObject spawnedUnit = (GameObject)Instantiate(specialArmyPrefab);
        SpecialArmy sa = spawnedUnit.GetComponent<SpecialArmy>();
        sa.unitType = specialUnit;
        sa.SetStats(specialUnit, factionManager.faction);
        spawnedUnit.transform.SetParent(tile.transform);
        spawnedUnit.transform.position = tile.transform.position;
        factionManager.AddArmy(sa);
    }
}

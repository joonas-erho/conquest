using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementsManager : MonoBehaviour
{
    public GameObject settlementPrefab;

    public void SpawnSettlement(FactionManager factionManager, SpecialArmy settler, Tile tile)
    {
        GameObject spawnedSettlement = (GameObject)Instantiate(settlementPrefab);
        Settlement settlement = spawnedSettlement.GetComponent<Settlement>();
        spawnedSettlement.transform.SetParent(tile.transform);
        spawnedSettlement.transform.position = tile.transform.position;
        settlement.Setup(factionManager);
        factionManager.AddSettlement(settlement);
    }
}

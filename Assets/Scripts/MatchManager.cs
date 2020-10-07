using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Singleton;
    private void Awake()
    {
        Singleton = this;
    }

    public int mapWidth;
    public int mapHeight;

    public WorldGen worldGen;

    public Tiles tiles;

    private MapTypes mapTypes;

    public Faction[] factions;
    public GameObject factionParent;
    public GameObject factionPrefab;

    public ArmiesManager armiesManager;

    public List<FactionManager> factionManagers = new List<FactionManager>();

    void Start()
    {
        tiles = new Tiles(mapWidth, mapHeight);
        mapTypes = new MapTypes();
        worldGen.GenerateNewWorld(mapWidth, mapHeight, tiles, mapTypes.GetMapType(0));
        foreach (Faction faction in factions)
        {
            InitializeFaction(faction);
        }

        foreach (FactionManager fm in factionManagers)
        {
            armiesManager.SpawnInitialArmies(fm);
        }
    }

    void InitializeFaction(Faction faction)
    {
        GameObject newFaction = (GameObject)Instantiate(factionPrefab);
        newFaction.transform.SetParent(factionParent.transform);
        newFaction.name = faction.factionName;
        FactionManager fm = newFaction.GetComponent<FactionManager>();
        factionManagers.Add(fm);
        fm.faction = faction;
    }
}

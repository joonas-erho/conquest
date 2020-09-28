using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTab : Tab
{
    public Text biomeText;
    public Text naturalResourcesText;
    public InfoScreen infoScreen;

    public override void SelectTile(Tile tile)
    {
        biomeText.text = "Biome: " + tile.GetBiome().name;
        if (tile.GetNaturalResourcesAmount() > 0)
        {
            string resourcesText = "";
            for (int i = 0; i < tile.GetNaturalResourcesAmount(); i++)
            {
                resourcesText += tile.GetNaturalResource(i).name;
                if (i + 1 != tile.GetNaturalResourcesAmount()) resourcesText += ", ";
            }
            naturalResourcesText.text = "Natural Resources: " + resourcesText;
        }
        else naturalResourcesText.text = "No Natural Resources.";

        tile.outlineRenderer.color = Color.yellow;
    }
}

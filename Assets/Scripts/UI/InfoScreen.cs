using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    public Button button;
    public Text biomeText;

    public void SelectTile(Tile tile)
    {
        this.gameObject.SetActive(true);
        biomeText.text = tile.GetBiome().name;
    }

    public void DeselectTile()
    {
        this.gameObject.SetActive(false);
    }
}

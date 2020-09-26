using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    public Button button;
    public Text biomeText;
    public Sprite[] headers;
    public GameObject infoTab;

    [SerializeField]
    private Tile currentlySelectedTile;
    [SerializeField]
    private GameObject currentlySelectedTab;

    public void ChangeTab(Tab tab)
    {
        GetComponent<Image>().sprite = headers[tab.index];
        GameObject oldTab = currentlySelectedTab;
        currentlySelectedTab.SetActive(false);
        currentlySelectedTab = tab.tabObject;
        currentlySelectedTab.SetActive(true);
    }

    public void SelectTile(Tile tile)
    {
        if(currentlySelectedTab == null)
        {
            currentlySelectedTab = infoTab;
            infoTab.SetActive(true);
        }
        try
        {
            currentlySelectedTile.outlineRenderer.color = new Color(0f, 0f, 0f, 0.2f);
        }
        catch { }

        currentlySelectedTile = tile;
        this.gameObject.SetActive(true);
        biomeText.text = tile.GetBiome().name;
        tile.outlineRenderer.color = Color.yellow;
    }

    public void DeselectTile()
    {
        this.gameObject.SetActive(false);
        currentlySelectedTile.outlineRenderer.color = new Color(0f,0f,0f,0.2f);
        currentlySelectedTile = null;
        currentlySelectedTab = null;
    }
}

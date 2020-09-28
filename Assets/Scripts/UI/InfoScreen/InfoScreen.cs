using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    public Text biomeText;
    public Text naturalResourcesText;

    public Sprite[] headers;
    public GameObject infoTab;

    public Tile currentlySelectedTile;
    public Tab currentlySelectedTab;

    public void ChangeTab(TabButton tabButton)
    {
        GetComponent<Image>().sprite = headers[tabButton.index];
        currentlySelectedTab.gameObject.SetActive(false);
        currentlySelectedTab = tabButton.tab;
        currentlySelectedTab.gameObject.SetActive(true);
    }

    public void SelectTile(Tile tile)
    {
        if (currentlySelectedTab == null)
        {
            currentlySelectedTab = infoTab.GetComponent<InfoTab>();
            GetComponent<Image>().sprite = headers[0];
            infoTab.SetActive(true);
        }
        try
        {
            currentlySelectedTile.outlineRenderer.color = new Color(0f, 0f, 0f, 0.2f);
        }
        catch { }

        currentlySelectedTile = tile;
        this.gameObject.SetActive(true);

        currentlySelectedTab.SelectTile(tile);
    }

    public void DeselectTile()
    {
        this.gameObject.SetActive(false);
        currentlySelectedTile.outlineRenderer.color = new Color(0f,0f,0f,0.2f);
        currentlySelectedTile = null;
        currentlySelectedTab.gameObject.SetActive(false);
        currentlySelectedTab = null;
    }
}

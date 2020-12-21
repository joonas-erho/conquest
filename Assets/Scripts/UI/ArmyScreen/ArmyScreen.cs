using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmyScreen : MonoBehaviour
{
    public TextMeshProUGUI armyNameText;
    public TextMeshProUGUI armyLeaderText;
    public Image armyBanner;

    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI supplyText;
    public TextMeshProUGUI moraleText;

    public Army currentlySelectedArmy;

    public void SelectArmy(Army army)
    {
        try
        {
            currentlySelectedArmy.outline.SetActive(false);
        }
        catch { }

        currentlySelectedArmy = army;
        currentlySelectedArmy.outline.SetActive(true);
        armyNameText.text = army.owner.faction.factionDemonym + " " + army.armyName;
        armyBanner.sprite = army.owner.faction.factionBanner;
        this.gameObject.SetActive(true);
    }

    public void DeselectArmy()
    {
        this.gameObject.SetActive(false);
        currentlySelectedArmy.outline.SetActive(false);
        currentlySelectedArmy = null;
    }
}

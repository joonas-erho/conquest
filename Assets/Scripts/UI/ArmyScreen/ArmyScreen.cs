using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyScreen : MonoBehaviour
{
    public Text armyNameText;

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
        armyNameText.text = 
            //army.owner.factionDemonym + " " + 
            army.armyName;
        this.gameObject.SetActive(true);
    }

    public void DeselectArmy()
    {
        this.gameObject.SetActive(false);
        currentlySelectedArmy.outline.SetActive(false);
        currentlySelectedArmy = null;
    }
}

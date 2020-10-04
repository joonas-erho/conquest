using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Army : MonoBehaviour, IPointerClickHandler
{
    public SpriteRenderer edge;
    public SpriteRenderer banner;
    public SpriteRenderer strengthBar;
    public SpriteRenderer supplyBar;
    public SpriteRenderer moraleBar;

    public string armyName;
    //public Faction owner;
    public Tile currentTile;

    public float strength;
    public float supply;
    public float morale;

    public float attack;
    public float rangedAttack;
    public float speed;
    public float toughness;

    public UnitAbility[] abilities;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Selected army!");
    }

    public void SetCurrentTile(Tile tile)
    {
        currentTile = tile;
        this.transform.position = tile.transform.position;
    }
}

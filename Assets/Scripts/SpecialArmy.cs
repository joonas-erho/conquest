using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialArmy : Army
{
    public SpriteRenderer icon;

    public SpecialUnit unitType;

    public void SetStats(SpecialUnit unitType)
    {
        icon.sprite = unitType.icon;
        attack = unitType.maxAttack;
        rangedAttack = unitType.maxRangedAttack;
        speed = unitType.speed;
        toughness = unitType.maxToughness;
        abilities = unitType.abilities;
    }
}

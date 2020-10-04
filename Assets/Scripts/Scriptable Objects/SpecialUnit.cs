using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Special Unit", menuName = "Special Unit")]
public class SpecialUnit : ScriptableObject
{
    public string unitName;
    public Sprite icon;

    public float maxAttack;
    public float maxRangedAttack;
    public float speed;
    public float maxToughness;

    public UnitAbility[] abilities;
}

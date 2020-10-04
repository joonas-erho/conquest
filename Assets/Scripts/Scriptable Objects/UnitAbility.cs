using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Ability", menuName = "Unit Ability")]
public class UnitAbility : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public string description;
}

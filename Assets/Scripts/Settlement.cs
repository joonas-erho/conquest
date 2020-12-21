using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour
{
    public FactionManager owner;

    public int settlementLevel = 1;
    public string settlementName;

    public void Setup(FactionManager faction)
    {
        owner = faction;
        settlementName = owner.defaultSettlementNames[Random.Range(0, owner.defaultSettlementNames.Length)];
    }
}

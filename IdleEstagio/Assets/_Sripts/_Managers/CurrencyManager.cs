using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [HideInInspector]public int gold, food, buildingMaterial, ore;
    public static CurrencyManager Instance;
    public void Awake()
    {
        Instance = this;
        ResourceNode.OnResourceGained += UpdateCounts;      
    }
    private void UpdateCounts(ResourcesTypes.Types types)
    {
        switch (types)
        {
            case ResourcesTypes.Types.gold:
            gold++;
            break;
            case ResourcesTypes.Types.food:
            food++;
            break;
            case ResourcesTypes.Types.buildingMaterial:
            buildingMaterial++;
            break;
            case ResourcesTypes.Types.ore:
            ore++;
            break;
        }
    }
}

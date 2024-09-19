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
        Instance = this;                                // Inicializa a instância estática da classe//
        ResourceNode.OnResourceGained += UpdateCounts;  //quando o evento OnResourceGained for disparado, o método UpdateCounts será chamado automaticamente//
    }
    private void UpdateCounts(ResourcesTypes.Types types)
    {
        switch (types)
        {
            case ResourcesTypes.Types.gold:
            gold++;                             // Incrementa o contador de ouro //
            break;
            case ResourcesTypes.Types.food:
            food++;                             // Incrementa o contador de Comida //
            break;
            case ResourcesTypes.Types.buildingMaterial:
            buildingMaterial++;                 // Incrementa o contador de Material construção //
            break;
            case ResourcesTypes.Types.ore:
            ore++;                              // Incrementa o contador de Minerio //
            break;
        }
    }
}

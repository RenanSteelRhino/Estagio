using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using UnityEditor.PackageManager;

public class CurrencyManager : MonoBehaviour
{
    [HideInInspector]public float gold, food, buildingMaterial, ore;
    public static CurrencyManager Instance;

    public void Awake()
    {
        Instance = this;                                // Inicializa a instância estática da classe//
        ResourceNode.OnResourceGained += UpdateCounts;  //quando o evento OnResourceGained for disparado, o método UpdateCounts será chamado automaticamente//
    }

    public bool DoesIHaveCurrencyToBuy(NodeSpecificType types, float quantity)
    {
        switch (types)
        {
            case NodeSpecificType.gold:
                if(gold >= quantity) return true;
                else return false;

            case NodeSpecificType.meat:
                if(food >= quantity) return true;
                else return false;

            case NodeSpecificType.wood:
                if(buildingMaterial >= quantity) return true;
                else return false;

            case NodeSpecificType.iron:
                if(ore >= quantity) return true;
                else return false;

            case NodeSpecificType.stone:
                if(buildingMaterial >= quantity) return true;
                else return false;
        }

        return false;
    }

    public bool SpendCurrency(NodeSpecificType types, float quantity)
    {
        if(DoesIHaveCurrencyToBuy(types, quantity))
        {
            switch (types)
            {
                case NodeSpecificType.gold:
                    gold -= quantity;
                    return true;

                case NodeSpecificType.meat:
                    food -= quantity;
                    return true;

                case NodeSpecificType.wood:
                    buildingMaterial -= quantity;
                    return true;

                case NodeSpecificType.iron:
                    ore -= quantity;
                    return true;

                case NodeSpecificType.stone:
                buildingMaterial -= quantity;
                    return true;
            }
        }

        return false;

    }

    private void UpdateCounts(NodeSpecificType types, Vector3 position)
    {
        float SpawnAmount = 1;
        switch (types)
        {
            case NodeSpecificType.gold:
            gold++;                             // Incrementa o contador de ouro //
            break;
            case NodeSpecificType.meat:
            food++;                             // Incrementa o contador de Comida //
            break;
            case NodeSpecificType.stone:
            SpawnAmount = 1 + ResourceStoreManager.instance.GetLevelFromType(types);
            buildingMaterial += SpawnAmount;
            break;
            case NodeSpecificType.wood:
            SpawnAmount = 1 + ResourceStoreManager.instance.GetLevelFromType(types);
            buildingMaterial += SpawnAmount;
            break;
            case NodeSpecificType.iron:
            ore++;                              // Incrementa o contador de Minerio //
            break;
        }

        FloatingTextManager.Instance.SpawnFloatingText(types, SpawnAmount, position);
        UIResources.instance.UpdateTextInfo();
    }
}

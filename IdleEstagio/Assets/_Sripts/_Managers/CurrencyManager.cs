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

    public bool DoesIHaveCurrencyToBuy(NodeGlobalTypes types, float quantity)
    {
        switch (types)
        {
            case NodeGlobalTypes.gold:
                if(gold >= quantity) return true;
                else return false;

            case NodeGlobalTypes.food:
                if(food >= quantity) return true;
                else return false;

            case NodeGlobalTypes.buildingMaterial:
                if(buildingMaterial >= quantity) return true;
                else return false;

            case NodeGlobalTypes.ore:
                if(ore >= quantity) return true;
                else return false;
        }

        return false;
    }

    public bool SpendCurrency(NodeGlobalTypes types, float quantity)
    {
        if(DoesIHaveCurrencyToBuy(types, quantity))
        {
            switch (types)
            {
                case NodeGlobalTypes.gold:
                    gold -= quantity;
                    return true;

                case NodeGlobalTypes.food:
                    food -= quantity;
                    return true;

                case NodeGlobalTypes.buildingMaterial:
                    buildingMaterial -= quantity;
                    return true;

                case NodeGlobalTypes.ore:
                    ore -= quantity;
                    return true;
            }
        }

        return false;

    }

    private void UpdateCounts(NodeGlobalTypes types)
    {
        float SpawnAmount = 1;
        switch (types)
        {
            case NodeGlobalTypes.gold:
            gold++;                             // Incrementa o contador de ouro //
            break;
            case NodeGlobalTypes.food:
            food++;                             // Incrementa o contador de Comida //
            break;
            case NodeGlobalTypes.buildingMaterial:
            SpawnAmount = 1 + ResourceStoreManager.instance.upgradesInStore.Where(item => item.newName == "Forestry").LastOrDefault().level;
            buildingMaterial += SpawnAmount;
            break;
            case NodeGlobalTypes.ore:
            ore++;                              // Incrementa o contador de Minerio //
            break;
        }
        FloatingTextManager.Instance.SpawnFloatingText(types, SpawnAmount);
        UIResources.instance.UpdateTextInfo();
    }
}

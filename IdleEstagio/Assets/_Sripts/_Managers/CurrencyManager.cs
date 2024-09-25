using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [HideInInspector]public float gold, food, buildingMaterial, ore;
    public static CurrencyManager Instance;

    public void Awake()
    {
        Instance = this;                                // Inicializa a instância estática da classe//
        ResourceNode.OnResourceGained += UpdateCounts;  //quando o evento OnResourceGained for disparado, o método UpdateCounts será chamado automaticamente//
    }

    public bool DoesIHaveCurrencyToBuy(ResourcesTypes.Types types, float quantity)
    {
        switch (types)
        {
            case ResourcesTypes.Types.gold:
                if(gold >= quantity) return true;
                else return false;

            case ResourcesTypes.Types.food:
                if(food >= quantity) return true;
                else return false;

            case ResourcesTypes.Types.buildingMaterial:
                if(buildingMaterial >= quantity) return true;
                else return false;

            case ResourcesTypes.Types.ore:
                if(ore >= quantity) return true;
                else return false;
        }

        return false;
    }

    public bool SpendCurrency(ResourcesTypes.Types types, float quantity)
    {
        if(DoesIHaveCurrencyToBuy(types, quantity))
        {
            switch (types)
            {
                case ResourcesTypes.Types.gold:
                    gold -= quantity;
                    return true;

                case ResourcesTypes.Types.food:
                    food -= quantity;
                    return true;

                case ResourcesTypes.Types.buildingMaterial:
                    buildingMaterial -= quantity;
                    return true;

                case ResourcesTypes.Types.ore:
                    ore -= quantity;
                    return true;
            }
        }

        return false;

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
            buildingMaterial++;
            // Qual o nivel do upgrade?
            // Building material += 1 + NivelDoUpgrade
            break;
            case ResourcesTypes.Types.ore:
            ore++;                              // Incrementa o contador de Minerio //
            break;
        }

        UIResources.instance.UpdateTextInfo();
    }
}

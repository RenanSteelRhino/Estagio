using System;
using System.Collections.Generic;
using Cainos.LucidEditor;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public ResourcesTypes.Types type;
    public static event Action<ResourcesTypes.Types> OnResourceGained;
    
    private void OnMouseDown()
    {
        //+1 recurso para o tipo selecionado
        switch (type)
        {
            case ResourcesTypes.Types.gold:
                OnResourceGained.Invoke(ResourcesTypes.Types.gold);
                break;
            
            case ResourcesTypes.Types.food:
                OnResourceGained.Invoke(ResourcesTypes.Types.food);
                break;
            
            case ResourcesTypes.Types.buildingMaterial:
                OnResourceGained.Invoke(ResourcesTypes.Types.buildingMaterial);

                ResourceNodeLevels.instance.currentForestryLevel++;
                ResourceNodeLevels.instance.currentQuaryLevel++;
                NodeVisualManager.instance.UpdateVisual(type);

                break;
            case ResourcesTypes.Types.ore:
                OnResourceGained.Invoke(ResourcesTypes.Types.ore);
                break;

            default:
                Debug.Log("Recurso não reconhecido");
                break;
        }
    }
}

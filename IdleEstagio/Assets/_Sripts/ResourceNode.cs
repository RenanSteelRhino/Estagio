using System;
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
            case ResourcesTypes.Types.agua:
                OnResourceGained.Invoke(ResourcesTypes.Types.agua);
                break;
            
            case ResourcesTypes.Types.carne:
                OnResourceGained.Invoke(ResourcesTypes.Types.carne);
                break;
            
            case ResourcesTypes.Types.madeira:
                Debug.Log("+1 madeira");
                break;

            case ResourcesTypes.Types.pedra:
                Debug.Log("+1 pedra");
                break;

            default:
                Debug.Log("Recurso não reconhecido");
                break;
        }
    }
}

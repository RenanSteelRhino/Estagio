using System;
using System.Collections.Generic;
using Cainos.LucidEditor;
using DG.Tweening;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public NodeGlobalTypes type;
    public static event Action<NodeGlobalTypes> OnResourceGained;  // Evento estático que será invocado quando um recurso for coletado
    public Vector3 nomalScale;  // Escala normal do objeto
    public Vector3 bigScale;    // Escala maior usada para efeito de clique

    private void OnMouseDown()   // Método chamado quando o objeto é clicado
    {

        transform.DOScale(bigScale, 0.05f).OnComplete( ()=>     // Animação para aumentar e depois retornar à escala normal
        {
            transform.DOScale(nomalScale, 0.05f);   // Retorna à escala original após o aumento
        });
        
        switch (type)
        {
            case NodeGlobalTypes.gold:
                OnResourceGained.Invoke(NodeGlobalTypes.gold); // Dispara o evento indicando que ouro foi coletado
                break;
            
            case NodeGlobalTypes.food:
                OnResourceGained.Invoke(NodeGlobalTypes.food); // Dispara o evento indicando que comida foi coletada
                break;
            
            case NodeGlobalTypes.buildingMaterial:
                OnResourceGained.Invoke(NodeGlobalTypes.buildingMaterial); // Dispara o evento indicando que material de construção foi coletado

                // ResourceNodeLevels.instance.currentForestryLevel++; // Incrementa o nível de "forestry" e "quary"
                // ResourceNodeLevels.instance.currentQuaryLevel++;
                // NodeVisualManager.instance.UpdateVisual(type);

                break;
            case NodeGlobalTypes.ore:
                OnResourceGained.Invoke(NodeGlobalTypes.ore);  // Dispara o evento indicando que minério foi coletado
                break;

            default:
                Debug.Log("Recurso não reconhecido");
                break;
        }
    }
}

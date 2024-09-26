using System;
using System.Collections.Generic;
using Cainos.LucidEditor;
using DG.Tweening;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public NodeSpecificType type;
    public static event Action<NodeSpecificType> OnResourceGained;  // Evento estático que será invocado quando um recurso for coletado
    public Vector3 nomalScale;  // Escala normal do objeto
    public Vector3 bigScale;    // Escala maior usada para efeito de clique

    public void Awake(){
        nomalScale = new Vector3(1, 1,  1);
        bigScale = new Vector3(1.5f, 1.5f, 1.5f);

    }

    private void OnMouseDown()   // Método chamado quando o objeto é clicado
    {

        transform.DOScale(bigScale, 0.05f).OnComplete( ()=>     // Animação para aumentar e depois retornar à escala normal
        {
            transform.DOScale(nomalScale, 0.05f);   // Retorna à escala original após o aumento
        });
        
        switch (type)
        {
            case NodeSpecificType.stone:
                OnResourceGained.Invoke(NodeSpecificType.stone); // Dispara o evento indicando que ouro foi coletado
                break;

             case NodeSpecificType.gold:
                OnResourceGained.Invoke(NodeSpecificType.gold); // Dispara o evento indicando que ouro foi coletado
                break;
            
            case NodeSpecificType.meat:
                OnResourceGained.Invoke(NodeSpecificType.meat); // Dispara o evento indicando que comida foi coletada
                break;

            case NodeSpecificType.farm:
                OnResourceGained.Invoke(NodeSpecificType.farm); // Dispara o evento indicando que comida foi coletada
                break;
            
            case NodeSpecificType.wood:
                OnResourceGained.Invoke(NodeSpecificType.wood); // Dispara o evento indicando que material de construção foi coletado

                break;
            case NodeSpecificType.iron:
                OnResourceGained.Invoke(NodeSpecificType.iron);  // Dispara o evento indicando que minério foi coletado
                break;

            default:
                Debug.Log("Recurso não reconhecido");
                break;
        }
    }
}

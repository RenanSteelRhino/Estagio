using System;
using System.Collections.Generic;
using Cainos.LucidEditor;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public ResourcesTypes.Types type;
    public static event Action<ResourcesTypes.Types> OnResourceGained;

    //ADICIONAR NIVEL DE NODE
    private int nodeLevel;
    //QUANTOS NIVEIS DEVE UPAR PARA TROCAR O VISUAL
    public const int milestoneLevel = 10;

    //ADICIONAR LISTA COM OS VISUAIS DO NODE
    public List<GameObject> visuaisDoNode = new List<GameObject>();

    //NIVEL DO VISUAL
    private int visualLevel = 0;

    private void UpgradeNodeVisual()
    {
        //TA NA HORA DE TROCAR DE VISUAL? QUAL MEU NIVEL ATUAL, DEVO TROCAR BASEADO NO MILESTONE LEVEL?
        //Desabilitar todos os visuais
        //Ativar o visual do nivel certo
        //Aumentar o nivel de visual a cada milestone level batido
    }

    private void OnMouseDown()
    {
        nodeLevel++;

        if(nodeLevel % milestoneLevel == 0)
        {
            visualLevel++;

            for (int i = 0; i < visuaisDoNode.Count; i++)
                visuaisDoNode[i].SetActive(false);

            visuaisDoNode[visualLevel].SetActive(true);
        }

        Debug.Log($"Node Level = {nodeLevel}");

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

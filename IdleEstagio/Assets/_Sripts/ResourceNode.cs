using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : MonoBehaviour
{
    public NodeSpecificType type;
    public static event Action<NodeSpecificType, Vector3> OnResourceGained;  // Evento estático que será invocado quando um recurso for coletado
    public Vector3 nomalScale;  // Escala normal do objeto
    public Vector3 bigScale;    // Escala maior usada para efeito de clique
    MyTimer nodeTimer;

    public void Awake()
    {
        nomalScale = new Vector3(1, 1,  1);
        bigScale = new Vector3(1.5f, 1.5f, 1.5f);
        nodeTimer = new MyTimer();

        //Linka o evento do timer à função de ganhar recurso
        nodeTimer.OnTimerEnd += GainResourceFromType;
    }

    private void Start() 
    {
        //Inicializa o timer com tempo e seta se ele esta em looping
        nodeTimer.InitializeTimer(1, true);
    }

    public void Update()
    {
        //Roda a contagem regressiva do timer
        nodeTimer.TickTimer(Time.deltaTime);
    }

    private void OnMouseDown()   // Método chamado quando o objeto é clicado
    {

        transform.DOScale(bigScale, 0.05f).OnComplete(() =>     // Animação para aumentar e depois retornar à escala normal
        {
            transform.DOScale(nomalScale, 0.05f);   // Retorna à escala original após o aumento
        });

        GainResourceFromType();
    }

    private void GainResourceFromType()
    {
        switch (type)
        {
            case NodeSpecificType.stone:
                OnResourceGained.Invoke(NodeSpecificType.stone, transform.position); // Dispara o evento indicando que ouro foi coletado
                break;

            case NodeSpecificType.gold:
                OnResourceGained.Invoke(NodeSpecificType.gold, transform.position); // Dispara o evento indicando que ouro foi coletado
                break;

            case NodeSpecificType.meat:
                OnResourceGained.Invoke(NodeSpecificType.meat, transform.position); // Dispara o evento indicando que comida foi coletada
                break;

            case NodeSpecificType.farm:
                OnResourceGained.Invoke(NodeSpecificType.farm, transform.position); // Dispara o evento indicando que comida foi coletada
                break;

            case NodeSpecificType.wood:
                OnResourceGained.Invoke(NodeSpecificType.wood, transform.position); // Dispara o evento indicando que material de construção foi coletado

                break;
            case NodeSpecificType.iron:
                OnResourceGained.Invoke(NodeSpecificType.iron, transform.position);  // Dispara o evento indicando que minério foi coletado
                break;

            default:
                Debug.Log("Recurso não reconhecido");
                break;
        }
    }
}

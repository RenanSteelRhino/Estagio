using System;
using System.Threading;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : MonoBehaviour
{
    public NodeSpecificType type;
    public static event Action<ResourceNode> OnResourceGained;  // Evento estático que será invocado quando um recurso for coletado
    [Space]
    [Header("Animations Options")]
    public Vector3 nomalScale;  // Escala normal do objeto
    public Vector3 bigScale;    // Escala maior usada para efeito de clique
    MyTimer nodeTimer;
    [HideInInspector] public bool hasClicked;
    [Space]
    [Header("Timer Options")]
    public float duration;
    [Space]
    [Header("Idle Options")]
    public float income;
    [Space]
    [Header("Other Options")]
    public bool createTextOnlyOnClick;
    

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
        nodeTimer.InitializeTimer(duration, true);
    }

    public void Update()
    {
        //Roda a contagem regressiva do timer
        nodeTimer.TickTimer(Time.deltaTime);
    }

    private void OnMouseDown()   // Método chamado quando o objeto é clicado
    {
        hasClicked = true;
        transform.DOScale(bigScale, 0.05f).OnComplete(() =>     // Animação para aumentar e depois retornar à escala normal
        {
            transform.DOScale(nomalScale, 0.05f);   // Retorna à escala original após o aumento
        });

        GainResourceFromType();
    }

    private void OnMouseUp() => hasClicked = false;

    private void GainResourceFromType()
    {
        OnResourceGained?.Invoke(this);
    }
}

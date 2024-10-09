using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance;

    //Prefab que vai ser usado
    public GameObject floatingPrefab;
    public Queue<GameObject> floatingQueue = new Queue<GameObject>();    // Fila que armazena os objetos de texto flutuante //

    private void Awake() 
    {
        Instance = this;
    }

    public void SpawnFloatingText(ResourceNode node, float amount)      // Método responsável por exibir o texto flutuante quando um recurso for coletado //
    {
        // Remove o primeiro objeto de texto flutuante da fila para reutilizá-lo //
        GameObject textObject;

        if(node.createTextOnlyOnClick && !node.hasClicked) return;

        if(floatingQueue.Count == 0)
            textObject = Instantiate(floatingPrefab);
        else
            textObject = floatingQueue.Dequeue();

        
        textObject.GetComponentInChildren<TextMeshProUGUI>().text = "+" + amount.ToString();
        textObject.SetActive(true);     // Ativa o objeto para ser exibido. //

        //Randomizadores de posição para o floating text
        float randomX = Random.Range(-1f,1f);
        float randomY = Random.Range(1f,2f);

        textObject.transform.position = new Vector3(node.transform.position.x + randomX, node.transform.position.y + randomY, 0);

        textObject.transform.DOMoveY(textObject.transform.position.y + randomY, 0.95f).OnComplete( ()=> 
        {
            textObject.SetActive(false);    // Desativa o texto após a animação terminar//
            
            floatingQueue.Enqueue(textObject);  // Devolve o objeto de volta à fila para ser reutilizado futuramente //
        });

        textObject.transform.DOPunchScale(new Vector3(1.35f, 1.35f, 1.35f), 0.25f);
        
    }
    public void SpawnFloatingText(Transform EnemyPosition)      // Método responsável por exibir o texto flutuante quando um recurso for coletado //
    {
        // Remove o primeiro objeto de texto flutuante da fila para reutilizá-lo //
        GameObject textObject;

        if(floatingQueue.Count == 0)
            textObject = Instantiate(floatingPrefab);
        else
            textObject = floatingQueue.Dequeue();

        
        textObject.GetComponentInChildren<TextMeshProUGUI>().text = "crit";
        textObject.SetActive(true);     // Ativa o objeto para ser exibido. //

        //Randomizadores de posição para o floating text
        float randomX = Random.Range(-1f,1f);
        float randomY = Random.Range(1f,2f);

        textObject.transform.position = new Vector3(EnemyPosition.transform.position.x + randomX, EnemyPosition.transform.position.y + randomY, 0);

        textObject.transform.DOMoveY(textObject.transform.position.y + randomY, 0.95f).OnComplete( ()=> 
        {
            textObject.SetActive(false);    // Desativa o texto após a animação terminar//
            
            floatingQueue.Enqueue(textObject);  // Devolve o objeto de volta à fila para ser reutilizado futuramente //
        });

        textObject.transform.DOPunchScale(new Vector3(1.35f, 1.35f, 1.35f), 0.25f);
        
    }
 
}

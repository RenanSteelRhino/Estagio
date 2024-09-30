using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;
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
       // ResourceNode.OnResourceGained += SpawnFloatingText;        //sempre que o evento OnResourceGained for disparado, o método SpawnFloatingText será chamado //

        
        // for (int i = 0; i < floatingPrefabs.Count; i++)     // Popula a fila de objetos de texto flutuante //
        // {
        //     GameObject obj = GameObject.Instantiate(floatingPrefabs[i]);    
        //     floatingQueue.Enqueue(obj);          // Cria uma instância do prefab e o armazena na fila para reutilização. //
        //     obj.SetActive(false);
        // }
    }

    public void SpawnFloatingText(NodeSpecificType types, float amount, Vector3 position)      // Método responsável por exibir o texto flutuante quando um recurso for coletado //
    {

        // Remove o primeiro objeto de texto flutuante da fila para reutilizá-lo //
        GameObject textObject;

        if(floatingQueue.Count == 0)
            textObject = Instantiate(floatingPrefab);
        else
            textObject = floatingQueue.Dequeue();

        
        textObject.GetComponentInChildren<TextMeshProUGUI>().text = "+" + amount.ToString();
        textObject.SetActive(true);     // Ativa o objeto para ser exibido. //

        //Pego a posição do click
        Vector2 mousePos = Input.mousePosition;

        //Randomizadores de posição para o floating text
        float randomX = Random.Range(-1f,1f);
        float randomY = Random.Range(1f,2f);
        textObject.transform.position = new Vector3(position.x + randomX, position.y + randomY, 0);

        textObject.transform.DOMoveY(textObject.transform.position.y + randomY, 1).OnComplete( ()=> 
        {
            textObject.SetActive(false);    // Desativa o texto após a animação terminar//
            
            floatingQueue.Enqueue(textObject);  // Devolve o objeto de volta à fila para ser reutilizado futuramente //
        });

        textObject.transform.DOPunchScale(new Vector3(1.35f, 1.35f, 1.35f), 0.25f);
        
    }
}

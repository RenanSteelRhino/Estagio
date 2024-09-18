using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingTextManager : MonoBehaviour
{
    public List<GameObject> floatingPrefabs = new List<GameObject>();
    public Queue<GameObject> floatingQueue = new Queue<GameObject>();

    private void Awake() 
    {
        ResourceNode.OnResourceGained += SpawnFloatingText;

        //Popula a fila / pool
        for (int i = 0; i < floatingPrefabs.Count; i++)
        {
            GameObject obj = GameObject.Instantiate(floatingPrefabs[i]);
            floatingQueue.Enqueue(obj);
        }
    }

    private void SpawnFloatingText(ResourcesTypes.Types types)
    {

        //Tira o texto da fila
        GameObject textObject = floatingQueue.Dequeue();
        textObject.SetActive(true);

        //Pego a posição do click
        Vector2 mousePos = Input.mousePosition;

        //Converto a posição para world point
        textObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

        //Zero o Z do obj para n bugar com a camera
        textObject.transform.position = new Vector3(textObject.transform.position.x, textObject.transform.position.y, 0);

        textObject.transform.DOMoveY(textObject.transform.position.y + 1, 1).OnComplete( ()=> 
        {
            textObject.SetActive(false);
            //Devolve o texto na fila
            floatingQueue.Enqueue(textObject);
        });
        
    }
}

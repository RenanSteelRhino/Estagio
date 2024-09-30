using Unity.VisualScripting;
using UnityEngine;

public class AnimalNpc : MonoBehaviour
{
public float velocidade = 1f;
private Vector3 movimento;
    private void Start()
    {
        movimento= Vector2.right;
    }
    private void Update()
    {
        transform.Translate(movimento * velocidade * Time.deltaTime);

        if (transform.position.x >= 17f)
        {
            movimento = Vector2.left;
        }
        else if (transform.position.x <= 7.5f)
        {
            movimento = Vector2.right;
        }
    }


}
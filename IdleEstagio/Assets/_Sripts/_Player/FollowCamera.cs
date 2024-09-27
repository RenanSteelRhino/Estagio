using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public LayerMask tileLayer;
    private Vector2 destination;
    public Vector2 distance;
    public Vector2 variableDistance;

    private void Update() 
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, -Camera.main.transform.up, 15, tileLayer);
        
        if(hit)
        {
            destination = hit.point;

            distance = destination - (Vector2)transform.position;
            variableDistance = new Vector2(distance.x, distance.y + 0.43f) / 500;

            transform.position += (Vector3)variableDistance;
        }

    }
}

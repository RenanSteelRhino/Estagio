using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float speed = 0;
    public bool isMoving = false;

    public void SetIsMoving(bool value)
    {
        isMoving = value;
    }
}

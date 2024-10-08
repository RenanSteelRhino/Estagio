using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float speed = 0;
    protected bool isMoving = false;

    public void SetIsMoving(bool value)
    {
        isMoving = value;
    }
}

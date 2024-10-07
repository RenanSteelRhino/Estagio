using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Awake() 
    {
        anim = gameObject.GetComponent<Animator>();
    }
}

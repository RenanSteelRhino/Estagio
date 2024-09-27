using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play("Walk-Right");
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.Play("Walk-Left");
        }
    }
}

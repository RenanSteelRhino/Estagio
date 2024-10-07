using UnityEngine;
using UnityEngine.UIElements;

public class PlayerJump : MonoBehaviour
{
    public float jump = 6f;
    public float initialY;
    public float maxY;
    public bool isJumping = false;
    public bool isUp = false;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetMouseButtonDown(0) && !isJumping)
        {
            isUp = true;
            isJumping=true;
            maxY = initialY + jump;
        }

        if(isJumping)
        {
            if (isUp == true)
            {
                transform.Translate(Vector2.up * jump * Time.deltaTime);
            }
            if(transform.position.y >= maxY)
            {
                isUp = false;
            }
            if (isUp == false)
            {
                transform.Translate(Vector2.down * jump * Time.deltaTime);
                if (transform.position.y <= initialY)
                {
                        isJumping = false;
                }
            }
        }

    }
    

    private void OnMouseDown() 
    {

    }
}

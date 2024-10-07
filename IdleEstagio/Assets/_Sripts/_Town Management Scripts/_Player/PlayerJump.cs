using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jump = 6f;
    public float initialY;
    public float maxY;
    public bool isJumping = false;
    public bool isUp = false;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {  
        //                                   origem da linha       direção    distancia     layer do chão
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);

        if(hit)
        {
            // To no chão
            Debug.DrawRay(transform.position, Vector2.down*1, Color.green);
        }
        else
        {
            // n to no chão
            Debug.DrawRay(transform.position, Vector2.down*1, Color.red);
        }


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

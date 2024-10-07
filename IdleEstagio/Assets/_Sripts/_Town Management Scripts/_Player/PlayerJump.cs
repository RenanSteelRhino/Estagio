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
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0,0.85f,0), Vector2.down, 0.1f, groundLayer);

        if(hit)
        { 
            isJumping=false;
            initialY = transform.position.y;
            Debug.DrawRay(transform.position - new Vector3(0,0.85f,0), Vector2.down*0.1f, Color.green);
        }
        else
        {
            isJumping=true;
            Debug.DrawRay(transform.position - new Vector3(0,0.85f,0), Vector2.down*0.1f, Color.red);
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

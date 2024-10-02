using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 5f;
    public List<Renderer> renderes = new List<Renderer>();
    private Camera _cam;
    private float spriteSize;
    public float offset = 0;

    private void Awake() 
    {
        _cam = Camera.main;
    }
    
    private void Start() 
    {
        if(renderes.Count <= 0) return;

        for (int i = 0; i < renderes.Count; i++)
        {
            spriteSize = renderes[i].bounds.extents.x * 2;
            var xPos = spriteSize * i+1;
            renderes[i].transform.position = new Vector3(xPos, renderes[i].transform.position.y, renderes[i].transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < renderes.Count; i++)
        {
            renderes[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
            ResetPositionX(renderes[i]);
        }
            
    }
    void ResetPositionX(Renderer render)
    {
        var cameraBoundsX = _cam.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        var distanceToReset = -(spriteSize/2) - cameraBoundsX - offset;

        if(render.transform.position.x <= distanceToReset)
        {
            render.transform.position = new Vector3(render.transform.position.x + spriteSize * 3, transform.position.y, transform.position.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 5f;
    public float leftBound = -10f;
    public float initialPositionX = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= leftBound)
        {
            ResetPositionX();
        }
    }
    void ResetPositionX()
    {
        transform.position = new Vector3(initialPositionX, transform.position.y, transform.position.z);
    }
}

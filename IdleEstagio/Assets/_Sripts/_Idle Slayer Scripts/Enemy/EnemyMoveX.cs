using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveX : MoveBase
{
    void Update()
    {
        if(!isMoving) return;
        transform.position += new Vector3(speed,0,0) * Time.deltaTime;
    }
}

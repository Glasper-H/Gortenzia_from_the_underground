using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWallDown : MonoBehaviour
{
    float maxY;
    float minY;
    public Transform maxObjY;
    public Transform minObjY;
    public float Upspeed = 4;
    public float Downspeed = 8;
    bool moveingRight = false;
    void Update()
    {
        maxY = maxObjY.position.y;
        minY = minObjY.position.y;
        if (transform.position.y > maxY)
        {
            moveingRight = false;
        }
        else if (transform.position.y < minY)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Upspeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Downspeed * Time.deltaTime);
        }
    }
}

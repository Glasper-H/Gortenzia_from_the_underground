using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateL : MonoBehaviour
{
    float maxX;
    float minX;
    public Transform maxObjX;
    public Transform minObjX;
    public float speed = 3f;
    bool moveingRight = true;
    void Update()
    {
        maxX = maxObjX.position.x;
        minX = minObjX.position.x;
        if (transform.position.x > maxX)
        {
            moveingRight = false;
        }
        else if (transform.position.x < minX)
        {
            moveingRight= true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}

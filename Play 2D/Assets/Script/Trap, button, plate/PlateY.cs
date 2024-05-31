using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateY : MonoBehaviour
{
    float maxY;
    float minY;
    public Transform maxObjY;
    public Transform minObjY;
    public float speed = 3f;
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
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}

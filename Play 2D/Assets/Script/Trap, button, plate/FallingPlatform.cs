using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float DestroyObj = 2, FallPlat = 0.75f, speedBack = 20;
    Vector2 currentPosition;
    bool movingBack;
    BoxCollider2D col;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
        col = rb.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && movingBack == false)
        {
            Invoke("FallPlatform", FallPlat);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", 5f);
        Invoke("TriggerTrue", 0.75f);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        movingBack = true;
        col.isTrigger = false;
    }

    void TriggerTrue()
    {
        col.isTrigger = true;
    }

    private void Update()
    {
        if (movingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, speedBack * Time.deltaTime);
        }

        if(transform.position.y == currentPosition.y)
        {
            movingBack = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenDoor : MonoBehaviour
{
    float maxY;
    float minY;
    public Transform maxObjY;
    public Transform minObjY;
    public float speed = 6f;
    bool moveingRight = false;
    public bool OnPlayer = false;
    private bool doMove = false;
    private Rigidbody2D _rb;
    private int i = 10;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayer = true;
        }
        else OnPlayer = false;
    }
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

        if (Player_Controller._useOrNot == true && OnPlayer == true)
        {
            doMove = true;
            Invoke("StopMove", 0.95f);
        }
        if (doMove == true && moveingRight == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (doMove == true && moveingRight == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        /*if (moveingRight == true && OnPlayer == true && Player_Controller._useOrNot == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (moveingRight == false && OnPlayer == true && Player_Controller._useOrNot == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (moveingRight == false && OnPlayer == true )
        {
            if (collision.gameObject.tag == "Player")
            {
                Player_Controller.HP = 0;
            }
        }
    }
    private void StopMove()
    {
        doMove = false;
    }
}

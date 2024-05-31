using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableVase : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject effect;
    public GameObject MoneyGold;
    public GameObject MoneySilver;
    int a;
    int b;
    int i = 0;
    bool A = false;
    bool B = false;
    PolygonCollider2D coll;
    public Animator animator;
    bool On = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        a = Random.Range(-5, 2);
        b = Random.Range(-2, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MagBall")
        {
            animator.SetBool("OnDestroy", On == true);
            Invoke("Stadia1", 0.25f);
            Invoke("DestroyObj", 0.8f);
        }
    }
    void Update()
    {
        /*if ((rb.velocity.x > 3 || rb.velocity.y > 3) && Col == true) 
        {
            Invoke("DestroyObj", 0f);
        }   */
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slash")
        {
            animator.SetBool("OnDestroy", On == true);
            Invoke("Stadia1", 0.25f);
            Invoke("DestroyObj", 0.8f);
        }
    }
    void Stadia1()
    {
        Instantiate(effect, transform.position, transform.rotation);
        coll.isTrigger = true;
        if (i <= a && B == false)
        {
            i++;
            Instantiate(MoneyGold, transform.position, transform.rotation);
        }
        else if (i > a || a <= 0)
        {
            B = true;
        }

        if (i <= b && A == false)
        {
            i++;
            Instantiate(MoneySilver, transform.position, transform.rotation);
        }
        else if (i > b || b <= 0)
        {
            A = true;
        }
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}

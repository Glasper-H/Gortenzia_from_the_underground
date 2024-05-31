using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Drawing;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed;
    public int positionOffPatrol;
    public Transform point;
    bool MovingRight = false;
    public GameObject eys;

    public Transform player;
    public float stoppingDistance;
    Vector2 DopVec;
    Vector2 DopVec2;
    bool chill = false;
    bool angry = false;
    bool goBack = false;

    public SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D Coll;

    int EnemyHp = 3;
    bool Dead = false;
    bool Attack = false;
    int Dop = 1;

    public bool GoPlayer = true;
    public float rayDistance = 1f;
    Rigidbody2D rb;
    public GameObject money;
    int A;
    int i = 0;
    bool B = false;
    public static bool DoDamageSlime1 = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        A = Random.Range(0, 2);
    }

    void Update()
    {
        DopVec = new Vector2(player.position.x, transform.position.y);
        DopVec2 = new Vector2(point.position.x, transform.position.y);

        anim.SetBool("OnDead", Dead == true);
        anim.SetBool("OnAttack", Attack == true);

        if (transform.position.x > point.position.x + positionOffPatrol)
        {
            MovingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOffPatrol)
        {
            MovingRight = true;
        }

        if (Vector2.Distance(transform.position, point.position) < positionOffPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        Debug.DrawRay(rb.position, Vector2.down, color: UnityEngine.Color.green);
        if (hit.collider != null)
        {
            GoPlayer = true;
        }
        else GoPlayer = false;

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true && GoPlayer == true)
        {
            Angry();
        }
        else if (goBack == true) 
        {
            GoBack();
        }

        if (EnemyHp <= 0)
        {
            eys.SetActive(false);
            Invoke("Death", 0.8f);
            Dead = true;
            Invoke("MonDeath", 0f);
            Dop = 0;
            Coll.isTrigger = true;
        }
    }
    void Chill()
    {
        if (MovingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Dop * Time.deltaTime, transform.position.y);
            spriteRenderer.flipX = true;
            eys.gameObject.transform.localPosition = new Vector2 (0.41f, -0.343f);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Dop * Time.deltaTime, transform.position.y);
            spriteRenderer.flipX = false;
            eys.gameObject.transform.localPosition = new Vector2(-0.41f, -0.343f);
        }
        speed = 3;
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, DopVec, speed * Dop * Time.deltaTime);
        speed = 6;
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            spriteRenderer.flipX = false;
            eys.gameObject.transform.localPosition = new Vector2(-0.41f, -0.343f);
        }
        else if (gameObject.transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = true;
            eys.gameObject.transform.localPosition = new Vector2(0.41f, -0.343f);
        }
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, DopVec2, speed * Dop* Time.deltaTime);
        speed = 4;
        if (gameObject.transform.position.x > point.transform.position.x)
        {
            spriteRenderer.flipX = false;
            eys.gameObject.transform.localPosition = new Vector2(-0.41f, -0.343f);
        }
        else if (gameObject.transform.position.x < point.transform.position.x)
        {
            spriteRenderer.flipX = true;
            eys.gameObject.transform.localPosition = new Vector2(0.41f, -0.343f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slash")
        {
            EnemyHp = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("ReAnimAttack", 0.2f);
            Attack = true;
            DoDamageSlime1 = true;
        }
        if (collision.gameObject.tag == "MagBall")
        {
            EnemyHp = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallDam")
        {
            EnemyHp = 0;
            Player_Controller.Stam = 0;
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void ReAnimAttack()
    {
        Attack = false;
    }

    void MonDeath()
    {
        if (i <= A && B == false)
        {
            i++;
            Instantiate(money, transform.position, transform.rotation);
        }
        else if (i > A)
        {
            B = true;
        }
    }
}

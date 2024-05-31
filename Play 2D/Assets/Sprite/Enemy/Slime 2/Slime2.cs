using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Slime2 : MonoBehaviour
{
    public float speed;
    public int positionOffPatrol;
    public Transform point;
    bool MovingRight = false;

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

    public int EnemyHp = 6;
    bool Dead = false;
    bool Attack = false;
    bool Hurt = false;
    int Dop = 1;
    bool atc = true;

    public bool GoPlayer = true;
    public float rayDistance = 1f;
    Rigidbody2D rb;
    public GameObject money;
    int A;
    int i = 0;
    bool B = false;

    /*[SerializeField]
    AudioSource GetDef;
    [SerializeField]
    AudioSource GetHurt;
    [SerializeField]
    AudioSource GetDeath;*/
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        A = Random.Range(1, 3);
        //GetDef.Play();
    }

    void Update()
    {
        DopVec = new Vector2(player.position.x, transform.position.y);
        DopVec2 = new Vector2(point.position.x, transform.position.y);

        anim.SetBool("OnDead", Dead == true);
        anim.SetBool("OnAttack", Attack == true);
        anim.SetBool("OnHurt", Hurt == true);

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
            //GetDef.Stop();
            Invoke("Death", 0.8f);
            Invoke("MonDeath", 0f);
            Dead = true;
            Dop = 0;
            Coll.isTrigger = true;
            //GetDeath.Play();
        }
    }
    void Chill()
    {
        if (MovingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Dop * Time.deltaTime, transform.position.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Dop * Time.deltaTime, transform.position.y);
            spriteRenderer.flipX = false;
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
        }
        else if (gameObject.transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, DopVec2, speed * Dop * Time.deltaTime);
        speed = 4;
        if (gameObject.transform.position.x > point.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (gameObject.transform.position.x < point.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slash" && atc == true)
        {
            //GetHurt.Play();
            atc = false;
            Invoke("ReAtc", 1.1f);
            Hurt = true;
            Invoke("StopHurt", 0.2f);
            //GetDef.Stop();
            Dop = 0;
            Invoke("ReDop", 1f);
            if (Player_Controller.SpeedX == 0)
            {
                EnemyHp -= 5 ;
            }
            else if (Player_Controller.SpeedX != 0)
            {
                EnemyHp -= 3;
            } 
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("ReAnimAttack", 0.2f);
            Attack = true;
        }
        if (collision.gameObject.tag == "MagBall")
        {
            EnemyHp -= 6;
            return;
        }
        if (collision.gameObject.tag == "DeadLava")
        {
            EnemyHp = 0;
            return;
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
    void ReAtc()
    {
        atc = true;
    }
    void StopHurt()
    {
        Hurt = false;
    }
    void ReDop()
    {
        Dop = 1;
        //GetDef.Play();
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

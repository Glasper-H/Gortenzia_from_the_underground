using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlood : MonoBehaviour
{
    bool lr = false;
    public bool Crystal_Blood = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (lr == false)
        {
            right();
            Invoke("A", 0.7f);
        }
        if (lr == true)
        {
            left();
            Invoke("B", 0.7f);
        }
        if (Crystal_Blood == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Player_Controller.useOrNot == true && collision.gameObject.tag == "Player")
        {
            Crystal_Blood = true;
            Save.CryBlood = 1;
            achievement.AC = true;
            Save.Savel();
        }
        else return;
    }
    void right()
    {
        rb.velocity = new Vector2(0, 0.35f);
    }
    void left()
    {
        rb.velocity = new Vector2(0, -0.35f);
    }
    void A()
    {
        lr = true;
    }
    void B()
    {
        lr = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MoneySp : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 3;
    public GameObject player;
    float stoppingDistance = 2f;
    bool angry = false;
    void Start()
    {
        int A = Random.Range(4, 7);
        int B = Random.Range(-3, 3);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * A, ForceMode2D.Impulse);
        rb.AddForce(transform.right * B, ForceMode2D.Impulse);
        Invoke("Stop", 1f);
        player = GameObject.FindWithTag("Player");

    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance)
        {
            angry = true;
        }
        else angry = false;
        if (angry == true)
        {
            Angry();
        }
        else if (angry == false) 
        {
            Chill();
        }
    }
    void Stop()
    {
        rb.velocity = new Vector2(0,0);
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void Chill()
    {
        rb.velocity = new Vector2(0,0);
    }
}

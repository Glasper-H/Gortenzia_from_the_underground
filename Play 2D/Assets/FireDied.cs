using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDied : MonoBehaviour
{
    public float FRspeed;
    public Animation animfire;
    void Start()
    {
        //animfire.Play();
    }
    void Update()
    {
        Invoke("Delete", 2);
        transform.Translate(new Vector2(-2,0) * FRspeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player_Controller.HP = 0;
            Destroy(gameObject);
        }
    }
    private void Delete()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtZalp : MonoBehaviour
{
    private float speed = 22;
    public Animator anim;
    int LifeTime = 5;
    void Start()
    {

    }
    void Update()
    {
        InvokeRepeating("LifeMinus", 4, 4);
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void LifeMinus()
    {
        LifeTime -= 1;
    }
}

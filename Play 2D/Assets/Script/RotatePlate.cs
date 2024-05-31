using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotatePlate : MonoBehaviour
{
    public GameObject plate;
    public float speedrotation = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        plate.transform.Rotate(0,0,speedrotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour
{
    public GameObject FireObj;
    public Transform sp;

    void Start()
    {
        InvokeRepeating("Fire", 2, 1.5f);
    }
    void Update()
    {
         
    }
    private void Fire()
    {
         Instantiate(FireObj, sp.position, sp.rotation);
    }
}

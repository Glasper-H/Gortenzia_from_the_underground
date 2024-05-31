using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public float offset;
    public GameObject MagicBallLight;
    public Transform player;
    public float _speedRotate = 1;
    public bool sh = false;
    public bool shootOrNo = true;
    public Animator anim;
    bool animT = false;
    [SerializeField]
    AudioSource FaerBall;

    void Update()
    {
        Vector3 difference = player.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(rotZ + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _speedRotate);

        float a = Random.Range(1f, 3.6f);
        float b = a - (a / 1.05f);

        if (sh == true && shootOrNo == true)
        {
            Invoke("CheckShoot", a);
            Invoke("StopAnim", b);
            Shoot();
            shootOrNo = false;
            animT = true;
        }
        InvokeRepeating("ShFalse", 0.5f, 0.5f); 
        anim.SetBool("ZalpOn", animT == true);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sh = true;
        }
        return;
    }
    void Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        FaerBall.Play();
    }
    void CheckShoot()
    {
        shootOrNo = true;
    }
    void ShFalse()
    {
        sh = false;
    }
    void StopAnim()
    {
        animT = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowE : MonoBehaviour
{
    public Animator anim;
    public GameObject hit;
    bool animOn = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animOn = true;      
        }
        else
        {
            animOn = false;
        }
        anim.SetBool("TipOn", animOn == true);
    }
}

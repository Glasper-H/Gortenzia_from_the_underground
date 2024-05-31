using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStableSword : MonoBehaviour
{
    /*public Animator animTip;
    public Animator animTipSword;*/
   /* bool animOn = false;
    bool TipOn = true;
    bool TipSOn = false;*/
    public GameObject PromtSword; 
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Player_Controller.useOrNot == true)
        {
            /*Invoke("B", 0.1f);
            Invoke("A", 0.1f);*/
            Invoke("StopAnimB", 8f);
            PromtSword.SetActive(true);
            Player_Controller.learnedMagicSword = true;
            Save.LearnMagicSword = 1;
            //TipOn = false;
        }
        /*if (collision.gameObject.tag == "Player" && TipOn == true)
        {
            animOn = true;
        }
        else animOn = false;
        animTip.SetBool("TipOn", animOn == true);
        animTipSword.SetBool("TipSwordOn", TipSOn == true);*/
    }
    /*void A()
    {
        Invoke("StopAnimB", 8f);
    }*/
    void StopAnimB()
    {
        //TipSOn = false;
        PromtSword.SetActive(false);
    }
    /*void B()
    {
        TipSOn = true;
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToLVL2 : MonoBehaviour
{
    public GameObject Player;
    public static bool doorOpen = true;

    private bool PlayerDetect;
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;

    void Start()
    {

    }

    void Update()
    {
        PlayerDetect = Physics2D.OverlapBox(transform.position, new Vector2(width, height), 0, WhatIsPlayer);

        if (PlayerDetect == true)
        {
            if (Player_Controller._useOrNot == true && Player_Controller.KeyToLVL2 == true && doorOpen == true)
            {
                doorOpen = false;
                StartCoroutine(DoorOpen());
            }
            else if (Player_Controller._useOrNot == true && Player_Controller.KeyToLVL2 == false)
            {
                TipsOrDialoge.i8 = true;
            }
        }
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(0);
        Invoke("Tp", 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
    private void Tp()
    {
        GameManager.NumberLvl = 2;
        Save.Savel();
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player_Controller.StopAction == false)
        {
            if (Player_Controller._useOrNot == true)
            {
                if (Player_Controller.KeyToLVL2 == true)
                {
                    GameManager.NumberLvl = 2;
                    Save.Savel();
                }
                else if (Player_Controller.KeyToLVL2 == false)
                {
                    TipsOrDialoge.i8 = true;
                }
            }
        }
    }*/
}

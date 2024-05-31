using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) { Player_Controller.wallIn = true;}
        else { Player_Controller.wallIn = false; }
    }
}

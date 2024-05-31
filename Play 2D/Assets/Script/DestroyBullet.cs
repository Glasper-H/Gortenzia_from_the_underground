using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MagBall")
        {
            MagBallBullet.Destr = true;
        }
        else MagBallBullet.Destr = false;
    }
}

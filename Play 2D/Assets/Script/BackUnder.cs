using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUnder : MonoBehaviour
{
    public GameObject BadEndTip;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BadEndTip.SetActive(true);
        }
        else if (collision.gameObject.tag != "Player")
        {
            BadEndTip.SetActive(false);
        }
        return;
    }
}

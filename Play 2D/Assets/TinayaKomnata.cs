using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinayaKomnata : MonoBehaviour
{
    public GameObject BlackBox;
    public bool OnPlayer = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayer = true;
        }
        else OnPlayer = false;
    }
    private void Update()
    {
        if (OnPlayer == true)
        {
            BlackBox.SetActive(false);
        }
        else if (OnPlayer == false)
        {
            BlackBox.SetActive(true);
        }
    }
}

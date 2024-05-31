using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpCol : AUDIO
{
    [SerializeField]
    private GameObject Player;
    Vector3 lastPos;
    Vector3 currentPos;
    [SerializeField] 
    private bool g = false;
    private bool h = true;
    private void FixedUpdate()
    {
        currentPos = Player.transform.position;
        if (lastPos.y < currentPos.y)
        {
            g = true;
        }
        else g = false;
        lastPos = currentPos;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground") && g == true)
        {
            if (h == true)
            {
                Invoke("UpColl", 0.001f);
            }
        }
    }
    void UpColl()
    {
        h = false;
        Invoke("UpColl_play", 0f);
        Invoke("H", 0.25f);
    }
    void H()
    {
        h = true;
    }
    void UpColl_play()
    {
        PlaySounnd(sounds[0], p1: 0.95f, p2: 1f);
    }
}
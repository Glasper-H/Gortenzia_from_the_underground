using System.Collections;
using UnityEngine;

public class KeyToDoor1LVL1 : MonoBehaviour
{
    public GameObject Door;
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
            if (Player_Controller._useOrNot == true && Player_Controller.Key1 == true && doorOpen == true)
            {
                doorOpen = false;
                StartCoroutine(DoorOpen());
            }
            else if (Player_Controller._useOrNot == true && Player_Controller.Key1 == false)
            {
                TipsOrDialoge.i3 = true;
            }
        }
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(0);
        Invoke("Tp", 0.2f);
        Invoke("ReDoorOpen", 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
    private void Tp()
    {
        Player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y);
    }
    private void ReDoorOpen()
    {
        doorOpen = true;
    }
}

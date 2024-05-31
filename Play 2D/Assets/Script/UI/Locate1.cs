using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locate1 : MonoBehaviour
{
    public Animator LocateAnim;
    bool locate = false;
    void Update()
    {
        Invoke("StopLocateAnim", 5f);
        LocateAnim.SetBool("Stop", locate == true);
    }
    void StopLocateAnim()
    {
        locate = true;
    }
}

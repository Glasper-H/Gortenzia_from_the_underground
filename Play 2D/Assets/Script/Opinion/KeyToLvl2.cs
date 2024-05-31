using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyToLvl2 : MonoBehaviour
{
    Rigidbody2D rb;
    bool lr = false;
    public string sceneName;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (lr == false)
        {
            right();
            Invoke("A", 0.7f);
        }
        if (lr == true)
        {
            left();
            Invoke("B", 0.7f);
        }
        if (Player_Controller.KeyToLVL2 == true)
        {
            gameObject.SetActive(false);
        }
    }
    void right()
    {
        rb.velocity = new Vector2(0, 0.35f);
    }
    void left()
    {
        rb.velocity = new Vector2(0, -0.35f);
    }
    void A()
    {
        lr = true;
    }
    void B()
    {
        lr = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Player_Controller.useOrNot == true)
        {
            Player_Controller.KeyToLVL2 = true;
            gameObject.SetActive(false);
        }
        else return;
    }
}

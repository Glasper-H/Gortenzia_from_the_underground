using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLvl1 : MonoBehaviour
{
    [SerializeField]
    private AudioSource music1;
    private bool i = true;
    private void Start()
    {
        Invoke("Music", 0.1f);
    }
    private void Update()
    {
        if (Player_Controller.OnPause == false)
        {
            Invoke("PauseMusic", 0.1f);
        }
        else if (Player_Controller.OnPause == true)
        {
            Invoke("Music", 0.1f);
        }
    }
    private void Music()
    {
        music1.Play();
    }
    private void PauseMusic()
    {
        music1.Pause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class End1Music : MonoBehaviour
{
    public AudioSource musicback;
    void Start()
    {
        musicback.Play();
        achievement.Achbadend = true;
    }
    void Update()
    {
        
    }
}

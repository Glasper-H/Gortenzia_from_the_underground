using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class achievement : MonoBehaviour
{
    [SerializeField]
    public static bool Achbadend = false;
    [SerializeField]
    public static bool AchCryBlo = false;
    public static bool AC  = false;
    public GameObject Ach1back;
    public ParticleSystem Ach1part;
    public ParticleSystem Ach2part;
    public string sceneName;
    public GameObject PA1;
    public GameObject PA2;
    public GameObject CrystalBlood;
    public GameObject AchBadOn;

    void Start()
    {

    }
    void Update()
    {

        if (Input.GetKey(KeyCode.J))
        {
            Ach1();
        }
       
        if (Save.CryBlood == 1)
        {
            AC = true;
        }
        if (AC == true)
        {
            Save.CryBlood = 1;
        }

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (AC == true && sceneName == "MainMenu")
        {
            Ach1();
        }
        if (Achbadend == true || Save.BadEnd == 1)
        {
            Save.BadEnd = 1;
            AchBadOn.SetActive(true);
            
        }
        if (Save.CryBlood == 1)
        {
            Save.CryBlood = 1;
            CrystalBlood.SetActive(true);
        }
    }
    void Ach1()
    {
        PA1.SetActive(true);
        PA2.SetActive(true);
        Ach1back.SetActive(true);
        Ach1part.Play();
        Ach2part.Play();
        Invoke("Ach1Stop", 8f);
        
    }
    void Ach1Stop()
    {
        PA1.SetActive(false);
        PA2.SetActive(false);
        Ach1back.SetActive(false);
        Ach1part.Stop();
        Ach2part.Stop();
        AC = false;
    }
    
}

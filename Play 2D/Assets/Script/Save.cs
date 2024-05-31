using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static int Key1L1 = 0;
    public static int Keylvl2 = 0;

    public static int LearnMagicSword = 0;

    public static int BadEnd = 0;
    public static int CryBlood = 0;
  
    void Awake()
    {
        Key1L1 = PlayerPrefs.GetInt("KeyToLvl1Door1");
        Keylvl2 = PlayerPrefs.GetInt("LeyToLvl2");
        LearnMagicSword = PlayerPrefs.GetInt("LearnMagicSw");
        GameManager.NumberLvl = PlayerPrefs.GetInt("ThatLvl");
        BadEnd = PlayerPrefs.GetInt("AchBadEnd");
        CryBlood = PlayerPrefs.GetInt("AchCrystalBlood");

        Player_Controller.EasyPosX = PlayerPrefs.GetFloat("EasyPosX");
        Player_Controller.EasyPosY = PlayerPrefs.GetFloat("EasyPosY");
        /*Player_Controller.PosX = PlayerPrefs.GetFloat("PosX");
        Player_Controller.PosY = PlayerPrefs.GetFloat("PosY");*/


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Всё удалено");
        }
    }
    public static void Savel()
    {
        PlayerPrefs.SetInt("ThatLvl", GameManager.NumberLvl);
        PlayerPrefs.SetInt("AchBadEnd", BadEnd);
        PlayerPrefs.SetInt("AchCrystalBlood", CryBlood);
        PlayerPrefs.SetInt("KeyToLvl1Door1", Key1L1);
        PlayerPrefs.SetInt("LeyToLvl2", Keylvl2);
        PlayerPrefs.SetInt("LearnMagicSw", LearnMagicSword);

        PlayerPrefs.SetFloat("EasyPosX", Player_Controller.EasyPosX);
        PlayerPrefs.SetFloat("EasyPosY", Player_Controller.EasyPosY);
        PlayerPrefs.SetFloat("PosX", Player_Controller.PosX);
        PlayerPrefs.SetFloat("PosY", Player_Controller.PosY);



        Debug.Log("Сохранка прошла");
    }
}

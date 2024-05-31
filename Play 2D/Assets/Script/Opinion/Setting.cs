using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Toggle EasyMode;
    public static int SaveEasyModeOP;
    public GameObject HelpEasyMode;
    public GameObject HelpWindowsMode;
    public static bool HelpEasyModeEnabled = false;
    public static bool HelpWindowsModeEnabled = false;
    public static int WindowsModeSave;
    private void Start()
    {
        SaveEasyModeOP = PlayerPrefs.GetInt("SaveEasyMode");
        WindowsModeSave = PlayerPrefs.GetInt("SaveWindowsMode");
        if (SaveEasyModeOP == 0)
        {
            EasyMode.isOn = false;
            Debug.Log("Load");
        }
        else if (SaveEasyModeOP == 1)
        {
            EasyMode.isOn = true;
            Debug.Log("Load");
        }
        else
        {
            EasyMode.isOn = false;
            Debug.Log("Error");
        }
        if (WindowsModeSave == 0)
        {
            toggle.isOn = false;
        }
        else if (WindowsModeSave == 1)
        {
            toggle.isOn = true;
        }
        else
        {   toggle.isOn = false;
            Debug.Log("Error");
        }
    }
    public void Update()
    {
        if (HelpEasyModeEnabled == true)
        {
            HelpEasyMode.SetActive(true);
        }
        else if (HelpEasyModeEnabled == false)
        {
            HelpEasyMode.SetActive(false);
        }
        if (HelpWindowsModeEnabled == true)
        {
            HelpWindowsMode.SetActive(true);
        }
        else if (HelpWindowsModeEnabled == false)
        {
            HelpWindowsMode.SetActive(false);
        }

        if (EasyMode.isOn == true)
        {
            SaveEasyModeOP = 1;
        }
        else if (EasyMode.isOn == false)
        {
            SaveEasyModeOP = 0;
        }
        if (toggle.isOn == true)
        {
            WindowsModeSave = 1;
        }
        else if (toggle.isOn == false)
        {
            WindowsModeSave = 0;
        }
        Screen.fullScreen = !toggle.isOn;
    }
    public void FullScreen()
    {
        toggle.isOn = !toggle.isOn;
    }
    public void ChangeMode()
    {
        EasyMode.isOn = !EasyMode.isOn;
    }
    public void AltMainMenu()
    {
        PlayerPrefs.SetInt("SaveWindowsMode", WindowsModeSave);
        PlayerPrefs.SetInt("SaveEasyMode", SaveEasyModeOP);
        Debug.Log("Save");
        SceneManager.LoadScene(0);
    }
}

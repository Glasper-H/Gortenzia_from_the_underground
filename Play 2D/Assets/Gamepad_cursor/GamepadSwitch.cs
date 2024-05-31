using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GamepadSwitch : MonoBehaviour
{
    public static bool GamepadControl;
    public static bool GamepadOn;
    private string _sceneName;
    private void Awake()
    {

    }
    private void Start()
    {
        if (_sceneName == "LVL1")
        {
            Cursor.visible = false;
        }
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        _sceneName = currentScene.name;
        var gamepad = Gamepad.current;

        if (gamepad != null)
        {
            GamepadOn = true;
        }
        else if (gamepad == null)
        {
            GamepadOn = false;
        }

        if (GamepadOn == true)
        {
            Invoke("On", 0f);
        }
        else if (GamepadOn == false)
        {
            Invoke("Off", 0f);
        }

        if (_sceneName == "MainMenu" && GamepadOn == true)
        {
            Invoke("On", 0f);
        }
        else if (_sceneName == "MainMenu" && GamepadOn == false)
        {
            Invoke("Off", 0f);
        }
        else if (_sceneName == "Previuv")
        {
            Invoke("On", 0f);
        }
        else if (_sceneName == "Achivesment" && GamepadOn == true)
        {
            Invoke("On", 0f);
        }
        else if (_sceneName == "Achivesment" && GamepadOn == false)
        {
            Invoke("Off", 0f);
        }
        else if (_sceneName == "LVL1" && GamepadOn == true)
        {
            Invoke("On", 0f);
            Player_Controller.IsVisCur1 = false;
        }
        else if (_sceneName == "LVL1" && GamepadOn == false)
        {
            Invoke("Off", 0f);
            Player_Controller.IsVisCur1 = true;
        }
    }
    public void On()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Off()
    {
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
    }
}

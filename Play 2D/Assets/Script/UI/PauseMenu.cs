using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool OnPause = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(OpinionKey.Pause) && Player_Controller.pauseOk == true)
        {
            OnPause = true;
            pauseCanvas.SetActive(true);
        }
        if (OnPause == true) 
        {
            Invoke("CurLockFalse", 0f);
            //Cursor.visible = true;
            Invoke("PauseTime", 0.1f);
        }
        else if (OnPause == false)
        {
            Time.timeScale = 1f;
        }
    }
    public void PauseOff()
    {
        OnPause = false;
        pauseCanvas.SetActive(false);
    }
    private void CurLockFalse()
    {
       // Cursor.lockState = CursorLockMode.None;
    }
    private void PauseTime()
    {
        Time.timeScale = 0f;
    }
}

using System.Collections;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject Pause;
    public Slider LoadBar;
    public GameObject TextNext;
    public GameObject ImageNext;
    public GameObject LoadText;
    
    public GameObject LoadScreen;
    public static int NumberLvl = 0;
    public string sceneName;
    private bool _loadLVL = false;
    private Player _player;
    private bool _conCor = false;
    private bool _isCor = false;

    private void Awake()
    {
        _player = new Player();
        _player.Move.AnyButton.performed += context =>
        {
            if (_conCor == true)
            {
                _isCor = true;
            }
        };
    }
    void Start()
    {
        Screen.fullScreen = true;
    }
    private void OnEnable()
    {
        _player.Enable();
    }
    private void OnDisable()
    {
        _player.Disable();
    }
    void Update()
    {     
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        if (sceneName == "MainMenu" && _conCor == false)
        {
            Time.timeScale = 1.0f;
            //Cursor.visible = true;
        }
        else if (sceneName == "MainMenu" && _conCor == true)
        {
            Time.timeScale = 0f;
        }
        if (sceneName == "End1")
        {
            Time.timeScale = 1.0f;
           // Cursor.visible = true;
        }
        if (sceneName == "COMING_SOON")
        {
            Time.timeScale = 1.0f;
           // Cursor.visible = true;
        }
        if (sceneName == "Previuv")
        {
            Time.timeScale = 1.0f;
            // Cursor.visible = true;
        }

        if (Setting.WindowsModeSave == 1)
        {
            Screen.fullScreen = !true;
        }
        else if (Setting.WindowsModeSave == 0)
        {
            Screen.fullScreen = !false;
        }

        if (Input.GetKeyDown(OpinionKey.ShowSave))
        {
            Debug.Log("НомерУровня" + NumberLvl);
            Debug.Log("Достижение Кровавый кристалл" + Save.CryBlood);
            Debug.Log("Достижение Плохая концовка" + Save.BadEnd);
            Debug.Log("Ключ от 1 двери 1 уровень " + Save.Key1L1);
            Debug.Log("Ключ для перехода на 2 лвл" + Save.Keylvl2);
            Debug.Log("Изучен меч или нет" + Save.LearnMagicSword);
        }

        if (Input.GetKeyDown(OpinionKey.DelSave))
        {
            PlayerPrefs.DeleteAll();
            Save.Key1L1 = 0;
            Save.Keylvl2 = 0;
            Save.LearnMagicSword = 0;
            Save.BadEnd = 0;
            Save.CryBlood = 0;
            NumberLvl = 0;
            Save.Savel();
            Debug.Log("НомерУровня" + NumberLvl);
            Debug.Log("Достижение Кровавый кристалл" + Save.CryBlood);
            Debug.Log("Достижение Плохая концовка" + Save.BadEnd);
            Debug.Log("Ключ от 1 двери 1 уровень " + Save.Key1L1);
            Debug.Log("Ключ для перехода на 2 лвл" + Save.Keylvl2);
            Debug.Log("Изучен меч или нет" + Save.LearnMagicSword);
            Debug.Log("Сохранения успешно удалены");
        }

        if (NumberLvl == 2 && sceneName == "LVL1")
        {
            Invoke("ComSoon", 0.25f);
        }
    }
    public void Ach()
    {
        SceneManager.LoadScene(4);
    }

    public void AltMainMenu()
    {
        Save.Savel();
        Debug.Log("Успешно сохранено!");
        SceneManager.LoadScene(0);
    }
    
    public void Previuw()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("НомерУровня" + NumberLvl);
        Debug.Log("Достижение Кровавый кристалл" + Save.CryBlood);
        Debug.Log("Достижение Плохая концовка" + Save.BadEnd);
        Debug.Log("Ключ от 1 двери 1 уровень " + Save.Key1L1);
        Debug.Log("Ключ для перехода на 2 лвл" + Save.Keylvl2);
        Debug.Log("Изучен меч или нет" + Save.LearnMagicSword);
        Debug.Log("Сохранения успешно удалены");
        SceneManager.LoadScene(3);
    }

    public void ContinionGame()
    {
        if (NumberLvl == 0)
        {
            SceneManager.LoadScene(3);
        }
        else if (NumberLvl == 1 && sceneName == "MainMenu" && _loadLVL == false)
        {
            _loadLVL = true;
            LoadScreen.SetActive(true);
            StartCoroutine(Continion1());
        }
        else if (NumberLvl == 1 && sceneName == "LVL1" && _loadLVL == false)
        {
            _loadLVL = true;
            SceneManager.LoadScene(1);
        }
    }

    public void MainMenu()
    {
        Save.Savel();
        Debug.Log("Успешно сохранено!");
        Debug.Log(Save.BadEnd);
        Debug.Log(Save.CryBlood);
        Debug.Log(Save.LearnMagicSword);
        Debug.Log(GameManager.NumberLvl);

        Time.timeScale = 1.0f;
        LoadScreen.SetActive(true);
        StartCoroutine(mainMenu());
    }

    public void ExitGame()
    {
        Save.Savel();
        Debug.Log("Успешно сохранено!");
        Debug.Log(Save.BadEnd);
        Debug.Log(Save.CryBlood);
        Debug.Log(Save.LearnMagicSword);
        Debug.Log(NumberLvl);

        Application.Quit();
        Debug.Log("выхожу из игры");
    }

    public void Opinion()
    {
        Save.Savel();

        SceneManager.LoadScene(6);
    }
    public void ComSoon()
    {
        Player_Controller.StopAction = true;
        SceneManager.LoadScene(5);
        //LoadScreen.SetActive(true);
        //StartCoroutine(ComingSoon());
    }

    IEnumerator mainMenu()
    {
        Time.timeScale = 1.0f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            LoadBar.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                Time.timeScale = 1.0f;
                TextNext.SetActive(true);
                ImageNext.SetActive(true);
                LoadText.SetActive(false);
                if (Player_Controller.useOrNot == true)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    IEnumerator ComingSoon()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(5);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            LoadBar.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                TextNext.SetActive(true);
                ImageNext.SetActive(true);
                LoadText.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    IEnumerator Continion1()
    {
         Time.timeScale = 1.0f;
         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
         asyncLoad.allowSceneActivation = false;
         while (!asyncLoad.isDone)
         {
             LoadBar.value = asyncLoad.progress;
             if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
             {
                 TextNext.SetActive(true);
                 ImageNext.SetActive(true);
                 LoadText.SetActive(false);
                _conCor = true;
                 if (_isCor == true)
                 {
                     asyncLoad.allowSceneActivation = true;
                 }
             }
             yield return null;
         }
    }
    public void OffPause()
    {
        Player_Controller.OnPause = false;
    }
}

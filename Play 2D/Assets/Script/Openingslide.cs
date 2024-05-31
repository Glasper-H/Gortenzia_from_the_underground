using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Openingslide : MonoBehaviour
{
    public AudioSource back;
    public string sceneName;

    public GameObject LoadScreen;
    public Slider LoadBar;
    public GameObject TextNext;
    public GameObject ImageNext;
    public GameObject LoadText;
    private Player _player;

    int Change = 0;
    private bool _skipCor = false;
    private bool _onCor = false;

    [SerializeField]
    GameObject Slide1;
    [SerializeField]
    GameObject Slide2;
    [SerializeField]
    GameObject Slide3;
    [SerializeField]
    GameObject Slide4;
    [SerializeField]
    GameObject Slide5;
    [SerializeField]
    GameObject Slide6;
    private void Awake()
    {
        _player = new Player();
        _player.Move.AnyButton.performed += context =>
        {
            SkipSlide();
            if (_onCor == true)
            {
                _skipCor = true;
            }
        };
    }
    private void OnEnable()
    {
        _player.Enable();
    }
    private void OnDisable()
    {
        _player.Disable();
    }
    void Start()
    {
        back.Play();
        Slide1.SetActive(true); 
        Slide2.SetActive(false);
        Slide3.SetActive(false);
        Slide4.SetActive(false);
        Slide5.SetActive(false);
        Slide6.SetActive(false);
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    void SkipSlide()
    {
        if (Change == 0)
        {
            Invoke("LoadSlide", 0.01f);
            Slide1.SetActive(false);
            Slide2.SetActive(true);
            Slide3.SetActive(false);
            Slide4.SetActive(false);
            Slide5.SetActive(false);
            Slide6.SetActive(false);
        }
        if (Change == 1)
        {
            Invoke("LoadSlide", 0.01f);
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Slide3.SetActive(true);
            Slide4.SetActive(false);
            Slide5.SetActive(false);
            Slide6.SetActive(false);
        }
        if (Change == 2)
        {
            Invoke("LoadSlide", 0.01f);
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Slide3.SetActive(false);
            Slide4.SetActive(true);
            Slide5.SetActive(false);
            Slide6.SetActive(false);
        }
        if (Change == 3)
        {
            Invoke("LoadSlide", 0.01f);
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Slide3.SetActive(false);
            Slide4.SetActive(false);
            Slide5.SetActive(true);
            Slide6.SetActive(false);
        }
        if (Change == 4)
        {
            Invoke("LoadSlide", 0.01f);
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Slide3.SetActive(false);
            Slide4.SetActive(false);
            Slide5.SetActive(false);
            Slide6.SetActive(true);
        }
        if (Change == 5)
        {
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Slide3.SetActive(false);
            Slide4.SetActive(false);
            Slide5.SetActive(false);
            Slide6.SetActive(false);
            back.Stop();
            GameManager.NumberLvl = 1;
            LoadScreen.SetActive(true);
            StartCoroutine(LoadAsync());
        }
    }
    private void LoadSlide()
    {
        Change++;
    }
    IEnumerator LoadAsync()
    {
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
                _onCor = true;
                if (_skipCor == true)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}

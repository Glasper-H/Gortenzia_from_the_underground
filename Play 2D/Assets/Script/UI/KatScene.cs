using UnityEngine;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;

public class KatScene : MonoBehaviour
{
    [SerializeField] 
    CinemachineVirtualCamera _camera2_1k;
    [SerializeField]
    private GameObject _c2_1k;
    [SerializeField]
    private GameObject _1kTarget;
    [SerializeField]
    private GameObject Hud;
    [SerializeField]
    private GameObject Cursor;

    private bool go = true;
    [SerializeField]
    private GameObject Player;

    private void Update()
    {
        if (Player.transform.position.x >= 26 && go == true)
        {
            _1kTarget.SetActive(true);
            _c2_1k.SetActive(true);
            _camera2_1k.m_Priority = 20;
            Hud.SetActive(false);
            Cursor.SetActive(false);
            go = false;
            Invoke("Re", 7f);  
        }
    }
    private void Re()
    {
        _camera2_1k.m_Priority = 0;
        Hud.SetActive(true);
        Cursor.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TipsOrDialoge : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private bool i1 = true;
    private bool i2 = true;
    public static bool i3 = false;
    [SerializeField]
    private bool i4 = true;
    private bool i5 = true;
    private bool i6 = true;
    private bool i7 = true;
    public static bool i8 = false;
    private string TipsText;
    [SerializeField]
    private GameObject TipsPanel;
    [SerializeField]
    private TextMeshProUGUI TextTips; 
    private void Start()
    {
        TipsText = "";
    }
    private void Update()
    {
        TextTips.text = TipsText;
        if (Slime.DoDamageSlime1 == true && i1 == true && Player_Controller.learnedMagicSword == false)
        {
            i1 = false;
            TipsText = "���� �� ������� ����� ����� ������ ������...";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (i3 == true)
        {
            i3 = false;
            TipsText = "�������. ����� ����. �������, �� �� ��� � ����������...";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (i8 == true)
        {
            i8 = false;
            TipsText = "�����? �������. �� �� ����� ���� ��� ������, ����� ����.";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "E" && i2 == true)
        {
            i2 = false;
            TipsText = "���, ������!.. ���������, ����� ����� �� �������";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (collision.gameObject.tag == "E2" && i7 == true)
        {
            i7 = false;
            TipsText = "��� ����! �������...";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (collision.gameObject.tag == "LavaAbyssEnter" && i4 == true)
        {
            i4 = false;
            TipsText = "�������... ��� ����� ����� � ��...";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (collision.gameObject.tag == "CollDestroyObjTips" && i5 == true && Player_Controller.learnedMagicSword == false)
        {
            i5 = false;
            TipsText = "�����... � �� ����� �� ����������, ���� �� � ���� ���� ����� �� ������";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
        if (collision.gameObject.tag == "SecretRoomTip" && i6 == true)
        {
            i6 = false;
            TipsText = "��� �������...";
            TipsPanel.SetActive(true);
            Invoke("ReTipsTextAndPanel", 4f);
        }
    }
    private void ReTipsTextAndPanel()
    {
        TipsPanel.SetActive(false);  
        TipsText = "";
    }
}
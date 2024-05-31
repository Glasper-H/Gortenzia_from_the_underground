using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverableMouse2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Setting.HelpWindowsModeEnabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Setting.HelpWindowsModeEnabled = false;
    }
}

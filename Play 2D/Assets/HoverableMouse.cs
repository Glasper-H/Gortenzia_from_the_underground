using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverableMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Setting.HelpEasyModeEnabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Setting.HelpEasyModeEnabled = false;
    }
}

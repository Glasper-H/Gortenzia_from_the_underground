using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class VirtualMouseUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform CanvasRectTransform;
    private VirtualMouseInput virtualMouseInput;
    private void Awake()
    {
        virtualMouseInput = GetComponent<VirtualMouseInput>();
    }
    private void Update()
    {
        transform.localScale = Vector3.one * (1f - CanvasRectTransform.localScale.x);
        transform.SetAsLastSibling();
    }
    private void LateUpdate()
    {
        Vector2 virtualMousePosition = virtualMouseInput.virtualMouse.position.ReadValue();
        virtualMousePosition.x = Mathf.Clamp(virtualMousePosition.x, 15f, Screen.width);
        virtualMousePosition.y = Mathf.Clamp(virtualMousePosition.y, 15f, Screen.height);
        InputState.Change(virtualMouseInput.virtualMouse.position, virtualMousePosition);
    }
}

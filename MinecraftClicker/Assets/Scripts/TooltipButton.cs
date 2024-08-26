using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TooltipButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TooltipHandler.tooltip.ShowTooltip(message);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TooltipHandler.tooltip.HideTooltip();
    }
}

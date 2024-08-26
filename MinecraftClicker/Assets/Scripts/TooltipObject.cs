using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipObject : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipHandler.tooltip.ShowTooltip(message);
    }

    private void OnMouseExit()
    {
        TooltipHandler.tooltip.HideTooltip();
    }
}

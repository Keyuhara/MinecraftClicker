using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour
{
    public static TooltipHandler tooltip;

    public TextMeshProUGUI textComponent;

    private void Awake()
    {
        // Singleton
        if(tooltip != null && tooltip != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            tooltip = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}

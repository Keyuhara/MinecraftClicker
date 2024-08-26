using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public TMP_Text victoryText;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.text = "You Survived " + Data.endDay.ToString() + " days";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

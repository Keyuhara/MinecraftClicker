using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "Game Over\nYou Survived " + Data.day.ToString() + " days";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockTime : MonoBehaviour
{
    public TMP_Text overheadText;
    
    public TMP_Text dayText;
    public TMP_Text clockText;

    public SupplyHandler supply;

    public void Start()
    {
        // DisplayTime(0);
        dayText.text = "DAY " + Data.day + " / " + Data.endDay;
    }

    public void Update()
    {
        checkDeath();
        Data.clock += Time.deltaTime * Data.speed;
        DisplayTime(Data.clock);
    }

    public void DisplayTime(float time)
    {
        if(time >= 1440)
        {
            // MapHandler.zombies += 25;
            UpdateDay();
            CheckVictory();
            supply.ConsumeSupply();
        }
        float hours = Mathf.FloorToInt(time / 60);
        float minutes = Mathf.FloorToInt(time % 60);
        clockText.text = string.Format("{0:00} : {1:00}", hours, minutes);

        // Horde Mode Begins
        if(Data.day % 3 == 0)
        {
            Data.hordeMode = 1;
        }

        // Horde Mode Over
        if(Data.day % 3 != 0 && Data.hordeMode == 1)
        {
            Data.hordeMode = 0;
        }
    }

    public void UpdateDay()
    {
        Data.clock = 0;
        Data.day += 1;
        dayText.text = "DAY " + Data.day + " / " + Data.endDay;
    }

    public void CheckVictory()
    {
        if(Data.day > Data.endDay && Data.victory == 0)
        {
            Data.victory = 1;
            SceneManager.LoadScene("Victory");
        }
    }
    
    public void checkDeath()
    {
        if(Data.HP < 0)
        {
            Debug.Log("YOU DIED! GAME OVER!");
            SceneManager.LoadScene("GameOver");
            // SceneManager.LoadScene("GameOver");
        }
    }

    public void PauseTime()
    {
        Data.speed = 0;
    }

    public void UpdateSpeed1x()
    {
        Data.speed = 1;
    }

    public void UpdateSpeed10x()
    {
        Data.speed = 10;
    }

    public void UpdateSpeed50x()
    {
        Data.speed = 50;
    }
}
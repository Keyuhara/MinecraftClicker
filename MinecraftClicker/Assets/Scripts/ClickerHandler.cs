using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickerHandler : MonoBehaviour
{
    public TMP_Text overheadText;

    public TMP_Text defenseText;
    public TMP_Text attackText;
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text populationText;
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text scrapsText;

    public TMP_Text exploreText;
    public TMP_Text scavengeText;
    public TMP_Text farmsText;
    public TMP_Text pumpsText;

    public LootHandler loot;

    private int pauseFlag;

    public void Start()
    {
        Data.scene = 3;
        
        overheadText.text = "JOB TASKS";

        defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
        attackText.text = "ATK: " + Data.ATK.ToString();
        healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();

        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;

        foodText.text = "Food: " + Data.food.ToString();
        waterText.text = "Water: " + Data.water.ToString();
        scrapsText.text = "Scraps: " + Data.scraps.ToString();
        
        exploreText.text = Data.explored.ToString() + " / " + Data.notExplored.ToString();
        scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
        farmsText.text = Data.farms.ToString() + " Farms";
        pumpsText.text = Data.pumps.ToString() + " Pumps";
    }

    public void Update()
    {
        if(Data.day % 3 == 2 && pauseFlag != 1)
        {
            overheadText.text = "HORDE IS COMING TOMORROW";
        }
        else if(pauseFlag != 1)
        {    
            overheadText.text = "JOB TASKS";
        }
    }

    // Explore clicker
    public void Explore()
    {
        if(Data.explored < Data.notExplored && Data.speed != 0)
        {
            // gains depend on speed
            Data.exploredDouble += 1 * Data.speed;
        
            if(Data.exploredDouble >= 1.0f)
            {
                if(Data.explored + (int)System.Math.Floor(Data.exploredDouble) > Data.notExplored)
                {
                    Data.notScavenged += 10 * (Data.notExplored - Data.explored);
                    Data.explored = Data.notExplored;
                }
                else
                {
                    Data.notScavenged += 10 * (int)System.Math.Floor(Data.exploredDouble);
                    Data.explored += (int)System.Math.Floor(Data.exploredDouble);
                }
                
                Data.exploredDouble -= (int)System.Math.Floor(Data.exploredDouble);
            }
        }
        else if(Data.speed == 0 && pauseFlag == 0)
        {
            pauseFlag = 1;
            StartCoroutine(PauseWarning());
            pauseFlag = 0;
        }

        exploreText.text = Data.explored.ToString() + " / " + Data.notExplored.ToString();
        scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
    }

    public void Scavenge()
    {
        if(Data.scavenged < Data.notScavenged && Data.speed != 0)
        {
            // gains depend on speed
            Data.scavengedDouble += 1 * Data.speed * Data.scavengingLevel; // DIFFICULTY
            
            if(Data.scavengedDouble >= 1.0f)
            {
                if(Data.scavenged + (int)System.Math.Floor(Data.scavengedDouble) > Data.notScavenged)
                {
                    for(int i = 0; i < (Data.notScavenged - Data.scavenged); i++)
                    {
                        loot.Loot();
                    }
                    Data.scavenged = Data.notScavenged;
                }
                else
                {
                    for(int i = 0; i < (int)System.Math.Floor(Data.scavengedDouble); i++)
                    {
                        loot.Loot();
                    }
                    Data.scavenged += (int)System.Math.Floor(Data.scavengedDouble);
                }
                Data.scavengedDouble -= (int)System.Math.Floor(Data.scavengedDouble);
            }
        }
        else if(Data.speed == 0 && pauseFlag == 0)
        {
            pauseFlag = 1;
            StartCoroutine(PauseWarning());
            pauseFlag = 0;
        }

        scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
    }

    public void BuildFarm()
    {
        if(Data.food >= 100 && Data.water >= 100)
        {
            Data.food -= 100;
            foodText.text = "Food: " + Data.food.ToString();
            Data.water -= 100;
            waterText.text = "Water: " + Data.water.ToString();

            Data.farms += 1;
            farmsText.text = Data.farms.ToString() + " Farms";
        }
    }

    public void BuildPump()
    {
        if(Data.scraps >= 100)
        {
            Data.scraps -= 100;
            scrapsText.text = "Scraps: " + Data.scraps.ToString();

            Data.pumps += 1;
            pumpsText.text = Data.pumps.ToString() + " Pumps";
        }
    }

    IEnumerator PauseWarning()
    {
        overheadText.text = "YOU MUST UNPAUSE FIRST";
        yield return new WaitForSeconds(3);
        overheadText.text = "JOB TASKS";
    }
}
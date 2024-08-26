using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JobHandler : MonoBehaviour
{
    public TMP_Text populationText;
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text scrapsText;

    public TMP_Text exploreText;
    public TMP_Text scavengeText;
    public TMP_Text farmsText;
    public TMP_Text pumpsText;
    
    public TMP_Text explorerText;
    public TMP_Text scavengerText;
    public TMP_Text farmerText;
    public TMP_Text pumperText;
    public TMP_Text defenderText;

    public LootHandler loot;

    public void Start()
    {
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        
        if(Data.scene == 1) // MAP
        {
            defenderText.text = Data.defenders + " defending";
        }
        else if(Data.scene == 3) // JOB
        {
            exploreText.text = Data.explored.ToString() + " / " + Data.notExplored.ToString();
            scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
            farmsText.text = Data.farms.ToString() + " Farms";
            pumpsText.text = Data.pumps.ToString() + " Pumps";

            explorerText.text = Data.explorers + " exploring";
            scavengerText.text = Data.scavengers + " scavenging";
            farmerText.text = Data.farmers + " farming";
            pumperText.text = Data.pumpers + " pumping";
        }
    }

    public void Update()
    {
        // automatically explore
        if(Data.explorers > 0 && Data.explored < Data.notExplored && Data.speed != 0)
        {
            Data.exploredDouble += Data.explorers * Time.deltaTime * Data.speed / Data.day; // DIFFICULTY
            
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

            exploreText.text = Data.explored.ToString() + " / " + Data.notExplored.ToString();
            scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
        }

        // automatically scavenge
        if(Data.scavengers > 0 && Data.scavenged < Data.notScavenged && Data.speed != 0)
        {
            Data.scavengedDouble += Data.scavengers * Time.deltaTime * Data.speed / Data.day * Data.scavengingLevel; // DIFFICULTY
            
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
            
            scavengeText.text = Data.scavenged.ToString() + " / " + Data.notScavenged.ToString();
        }

        // automatically farm food
        if(Data.farmers > 0 && Data.speed != 0)
        {
            Data.foodDouble += Data.farmers * Time.deltaTime * Data.speed / Data.day; // DIFFICULTY
            
            if(Data.foodDouble >= 1.0f)
            {
                Data.food += (int)System.Math.Floor(Data.foodDouble);
                Data.foodDouble -= (int)System.Math.Floor(Data.foodDouble);
            }

            foodText.text = "Food: " + Data.food.ToString();
        }

        // automatically pump water
        if(Data.pumpers > 0 && Data.speed != 0)
        {
            Data.waterDouble += Data.pumpers * Time.deltaTime * Data.speed / Data.day; // DIFFICULTY

            if(Data.waterDouble >= 1.0f)
            {
                Data.water += (int)System.Math.Floor(Data.waterDouble);
                Data.waterDouble -= (int)System.Math.Floor(Data.waterDouble);
            }
            
            waterText.text = "Water: " + Data.water.ToString();
        }
    }

    public void AddExplorer()
    {
        if(Data.idle > 0)
        {
            Data.idle -= 1;
            Data.explorers += 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        explorerText.text = Data.explorers + " exploring";
    }

    public void SubtractExplorer()
    {
        if(Data.explorers > 0)
        {
            Data.idle += 1;
            Data.explorers -= 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        explorerText.text = Data.explorers + " exploring";
    }

    public void AddScavenger()
    {
        if(Data.idle > 0)
        {
            Data.idle -= 1;
            Data.scavengers += 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        scavengerText.text = Data.scavengers + " scavenging";
    }

    public void SubtractScavenger()
    {
        if(Data.scavengers > 0)
        {
            Data.idle += 1;
            Data.scavengers -= 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        scavengerText.text = Data.scavengers + " scavenging";
    }

    public void AddFarmer()
    {
        if(Data.idle > 0 && Data.farmers < Data.farms)
        {
            Data.idle -= 1;
            Data.farmers += 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        farmerText.text = Data.farmers + " farming";
    }

    public void SubtractFarmer()
    {
        if(Data.farmers > 0)
        {
            Data.idle += 1;
            Data.farmers -= 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        farmerText.text = Data.farmers + " farming";
    }

    public void AddPumper()
    {
        if(Data.idle > 0 && Data.pumpers < Data.pumps)
        {
            Data.idle -= 1;
            Data.pumpers += 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        pumperText.text = Data.pumpers + " pumping";
    }

    public void SubtractPumper()
    {
        if(Data.pumpers > 0)
        {
            Data.idle += 1;
            Data.pumpers -= 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        pumperText.text = Data.pumpers + " pumping";
    }

    public void AddDefender()
    {
        if(Data.idle > 0)
        {
            Data.idle -= 1;
            Data.defenders += 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }

    public void Add10Defender()
    {
        if(Data.idle >= 10)
        {
            Data.idle -= 10;
            Data.defenders += 10;
        }
        else
        {
            Data.defenders += Data.idle;
            Data.idle = 0;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }

    public void AddMaxDefender()
    {
        if(Data.idle > 0)
        {
            Data.defenders += Data.idle;
            Data.idle = 0;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }

    public void SubtractDefender()
    {
        if(Data.defenders > 0)
        {
            Data.idle += 1;
            Data.defenders -= 1;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }

    public void Subtract10Defender()
    {
        if(Data.defenders >= 10)
        {
            Data.idle += 10;
            Data.defenders -= 10;
            
        }
        else
        {
            Data.idle += Data.defenders;
            Data.defenders = 0;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }

    public void SubtractMinDefender()
    {
        if(Data.defenders > 0)
        {
            Data.idle += Data.defenders;
            Data.defenders = 0;
        }
        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        defenderText.text = Data.defenders + " defending";
    }
}
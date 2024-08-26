using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SupplyHandler : MonoBehaviour
{
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
    
    public TMP_Text explorerText;
    public TMP_Text scavengerText;
    public TMP_Text farmerText;
    public TMP_Text pumperText;
    public TMP_Text defenderText;

    private int kill;

    public ButtonHandler button;

    public void ConsumeSupply()
    {
        // supply consumption
        Data.food -= Data.survivors;
        Data.water -= Data.survivors;
        foodText.text = "Food: " + Data.food.ToString();
        waterText.text = "Water: " + Data.water.ToString();
        
        // your people starves
        if(Data.food < 0)
        {
            while(Data.idle > 0)
            {
                Data.idle -= 1;
                Data.survivors -= 1;
                Data.food += 1;
            }
            while(Data.food < 0)
            {
                kill = Random.Range(1, 11); // DIFFICULTY
                switch(kill)
                {
                    case int i when i == 1: // DIFFICULTY
                        Data.food += 1;
                        if(Data.explorers > 0)
                        {
                            Data.explorers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 2: // DIFFICULTY
                        Data.food += 1;
                        if(Data.scavengers > 0)
                        {
                            Data.scavengers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 3: // DIFFICULTY
                        Data.food += 1;
                        if(Data.farmers > 0)
                        {
                            Data.farmers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 4: // DIFFICULTY
                        Data.food += 1;
                        if(Data.pumpers > 0)
                        {
                            Data.pumpers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 5: // DIFFICULTY
                        Data.food += 1;
                        if(Data.defenders > 0)
                        {
                            Data.defenders -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    default:
                        Data.food += 1;
                        break;
                }
            }
            populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;

            foodText.text = "Food: " + Data.food.ToString();
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

        // your people thirst
        if(Data.water < 0)
        {
            while(Data.idle > 0)
            {
                Data.idle -= 1;
                Data.survivors -= 1;
                Data.water += 1;
            }
            while(Data.water < 0)
            {
                kill = Random.Range(1, 11); // DIFFICULTY
                switch(kill)
                {
                    case int i when i == 1: // DIFFICULTY
                        Data.water += 1;
                        if(Data.explorers > 0)
                        {
                            Data.explorers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 2: // DIFFICULTY
                        Data.water += 1;
                        if(Data.scavengers > 0)
                        {
                            Data.scavengers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 3: // DIFFICULTY
                        Data.water += 1;
                        if(Data.farmers > 0)
                        {
                            Data.farmers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 4: // DIFFICULTY
                        Data.water += 1;
                        if(Data.pumpers > 0)
                        {
                            Data.pumpers -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    case int i when i == 5: // DIFFICULTY
                        Data.water += 1;
                        if(Data.defenders > 0)
                        {
                            Data.defenders -= 1;
                            Data.survivors -= 1;
                        }
                        break;
                    default:
                        Data.water += 1;
                        break;
                }
            }
            populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;

            waterText.text = "Water: " + Data.water.ToString();
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

        // you starve
        if(Data.food > 0)
        {
            if( Data.HP <= Data.maxHP - 10 )
            {
                button.EatFood();
            }
            
        }
        else
        {
            Data.HP -= 10;
            if(Data.HP <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        // you thirst
        if(Data.water > 0)
        {
            if(Data.SP <= Data.maxSP - 10)
            {
                button.DrinkWater();
            }
        }
        else
        {
            Data.SP -= 10;
        }
        
        foodText.text = "Food: " + Data.food.ToString();
        waterText.text = "Water: " + Data.water.ToString();
        healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();
    }
}

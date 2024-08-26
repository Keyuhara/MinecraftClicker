using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public TMP_Text defenseText;
    public TMP_Text attackText;
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text populationText;
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text scrapsText;

    public void EatFood()
    {
        if(Data.food > 0 && Data.HP < Data.maxHP)
        {
            Data.food -= 1;
            foodText.text = "Food: " + Data.food.ToString();

            Data.HP += 10;

            if(Data.HP > Data.maxHP)
            {
                Data.HP = Data.maxHP;
            }

            healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        }
    }

    public void DrinkWater()
    {
        if(Data.water > 0 && Data.SP < Data.maxSP)
        {
            Data.water -= 1;
            waterText.text = "Water: " + Data.water.ToString();

            Data.SP += 10;

            if(Data.SP > Data.maxSP)
            {
                Data.SP = Data.maxSP;
            }

            staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();
        }
    }

    public void RecruitPeople()
    {
        if(Data.food >= 10 && Data.water >= 10 && Data.difficulty != 3)
        {
            Data.food -= 10;
            foodText.text = "Food: " + Data.food.ToString();
            Data.water -= 10;
            waterText.text = "Water: " + Data.water.ToString();

            // DIFFICULTY ADJUSTMENT
            Data.idle += 1;
            Data.survivors += 1;
            populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;
        }
    }

    public void RepairDefense()
    {
        if(Data.scraps >= 100 && Data.DEF < Data.maxDEF)
        {
            Data.scraps -= 100;
            scrapsText.text = "Scraps: " + Data.scraps.ToString();

            if(Data.maxDEF - Data.DEF < 100)
            {
                Data.DEF = Data.maxDEF;
            }
            else
            {
                Data.DEF += 100;
            }
            defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
        }
    }
}

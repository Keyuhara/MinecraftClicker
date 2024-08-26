using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
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

    public TMP_Text attackLevelText;
    public TMP_Text defenseLevelText;
    public TMP_Text healthLevelText;
    public TMP_Text staminaLevelText;
    public TMP_Text explorationLevelText;
    public TMP_Text scavengingLevelText;

    public void Start()
    {
        Data.scene = 2;

        defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
        attackText.text = "ATK: " + Data.ATK.ToString();
        healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();

        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;

        foodText.text = "Food: " + Data.food.ToString();
        waterText.text = "Water: " + Data.water.ToString();
        scrapsText.text = "Scraps: " + Data.scraps.ToString();
        
        attackLevelText.text = "Level " + Data.attackLevel;
        defenseLevelText.text = "Level " + Data.defenseLevel;
        healthLevelText.text = "Level " + Data.healthLevel;
        staminaLevelText.text = "Level " + Data.staminaLevel;
        explorationLevelText.text = "Level " + Data.explorationLevel;
        scavengingLevelText.text = "Level " + Data.scavengingLevel;
    }

    public void Update()
    {
        if(Data.day % 3 == 2)
        {
            overheadText.text = "HORDE IS COMING TOMORROW";
        }
        else
        {    
            overheadText.text = "UPGRADES";
        }
    }

    public void BoostAttack()
    {
        if(Data.food >= 100 && Data.water >= 100)
        {
            Data.food -= 100;
            foodText.text = "Food: " + Data.food.ToString();
            Data.water -= 100;
            waterText.text = "Water: " + Data.water.ToString();

            Data.attackLevel += 1;
            attackLevelText.text = "Level " + Data.attackLevel;

            Data.ATK += 1;
            attackText.text = "ATK: " + Data.ATK.ToString();
        }
    }

    public void BoostDefense()
    {
        if(Data.scraps >= 1000)
        {
            Data.scraps -= 1000;
            scrapsText.text = "Scraps: " + Data.scraps.ToString();

            Data.defenseLevel += 1;
            defenseLevelText.text = "Level " + Data.defenseLevel;
            
            Data.maxDEF += 100;
            defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
        }
    }

    public void BoostHealth()
    {
        if(Data.food >= 1000)
        {
            Data.food -= 1000;
            foodText.text = "Food: " + Data.food.ToString();

            Data.healthLevel += 1;
            healthLevelText.text = "Level " + Data.healthLevel;

            Data.maxHP += 10;
            healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        }
    }

    public void BoostStamina()
    {
        if(Data.water >= 1000)
        {
            Data.water -= 1000;
            waterText.text = "Water: " + Data.water.ToString();

            Data.staminaLevel += 1;
            staminaLevelText.text = "Level " + Data.staminaLevel;

            Data.maxSP += 10;
            staminaLevelText.text = "Level " + Data.staminaLevel;
        }
    }

    public void BoostExploration()
    {
        if(Data.food >= 100 && Data.scraps >= 100)
        {
            Data.food -= 100;
            foodText.text = "Food: " + Data.food.ToString();
            Data.scraps -= 100;
            scrapsText.text = "Scraps: " + Data.scraps.ToString();

            Data.explorationLevel += 1;
            Data.notExplored += 100 * Data.explorationLevel;
            explorationLevelText.text = "Level " + Data.explorationLevel;
        }
    }

    public void BoostScavenging()
    {
        if(Data.water >= 100 && Data.scraps >= 100)
        {
            Data.water -= 100;
            waterText.text = "Food: " + Data.water.ToString();
            Data.scraps -= 100;
            scrapsText.text = "Scraps: " + Data.scraps.ToString();

            // better looting returns
            Data.scavengingLevel += 1;
            scavengingLevelText.text = "Level " + Data.scavengingLevel;
        }
    }
}

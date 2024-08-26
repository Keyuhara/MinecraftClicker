using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapHandler : MonoBehaviour
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

    public TMP_Text defenderText;

    public void Start()
    {
        Data.scene = 1;
        
        defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
        attackText.text = "ATK: " + Data.ATK.ToString();
        healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
        staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();

        populationText.text = "Pop: " + Data.idle + " / " + Data.survivors;

        foodText.text = "Food: " + Data.food.ToString();
        waterText.text = "Water: " + Data.water.ToString();
        scrapsText.text = "Scraps: " + Data.scraps.ToString();

        defenderText.text = Data.defenders + " defending";
    }

    public void Update()
    {
        if(Data.speed == 0)
        {
            overheadText.text = "YOU MUST UNPAUSE FIRST";
        }
        if(Data.SP == 0)
        {
            overheadText.text = "OUT OF STAMINA! DRINK UP!";
        }
        else if(Data.day % 3 == 2)
        {
            overheadText.text = "HORDE IS COMING TOMORROW";
        }
        else if(Data.day % 3 == 0)
        {
            overheadText.text = "HORDE MODE";
        }
        else
        {    
            overheadText.text = "MAP";
        }
    }
}

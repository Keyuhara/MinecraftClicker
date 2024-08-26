using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LootHandler : MonoBehaviour
{
    
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text scrapsText;

    private float rand;

    public void Loot()
    {
        rand = Random.Range(0, 100);
        switch(rand)
        {
            case float i when i > 95: // DIFFICULTY
                Data.food += 1 + Data.scavengingLevel;
                foodText.text = "Food: " + Data.food.ToString();
                break;
            case float i when i > 90: // DIFFICULTY
                Data.water += 1 + Data.scavengingLevel;
                waterText.text = "Water: " + Data.water.ToString();
                break;
            default:
                Data.scraps += 1 * Data.scavengingLevel;
                scrapsText.text = "Scraps: " + Data.scraps.ToString();
                break;
        }
    }
}

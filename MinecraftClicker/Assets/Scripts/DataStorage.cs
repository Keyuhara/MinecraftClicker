using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public void SaveData()
    {
        // can't save during horde mode
        if(Data.hordeMode == 0)
        {
            PlayerPrefs.SetInt("difficulty", Data.difficulty);
            PlayerPrefs.SetInt("victory", Data.victory);
            PlayerPrefs.SetInt("hordeMode", Data.hordeMode);
            PlayerPrefs.SetInt("scene", Data.scene);

            PlayerPrefs.SetInt("explored", Data.explored);
            PlayerPrefs.SetString("exploredDouble", Data.exploredDouble.ToString());
            PlayerPrefs.SetInt("notExplored", Data.notExplored);
            PlayerPrefs.SetInt("scavenged", Data.scavenged);
            PlayerPrefs.SetString("scavengedDouble", Data.scavengedDouble.ToString());
            PlayerPrefs.SetInt("notScavenged", Data.notScavenged);

            PlayerPrefs.SetInt("DEF", Data.DEF);
            PlayerPrefs.SetInt("maxDEF", Data.maxDEF);
            PlayerPrefs.SetInt("ATK", Data.ATK);

            PlayerPrefs.SetInt("HP", Data.HP);
            PlayerPrefs.SetInt("maxHP", Data.maxHP);
            PlayerPrefs.SetInt("SP", Data.SP);
            PlayerPrefs.SetInt("maxSP", Data.maxSP);
            
            PlayerPrefs.SetInt("food", Data.food);
            PlayerPrefs.SetString("foodDouble", Data.foodDouble.ToString());
            PlayerPrefs.SetInt("water", Data.water);
            PlayerPrefs.SetString("waterDouble", Data.waterDouble.ToString());
            PlayerPrefs.SetInt("scraps", Data.scraps);
            PlayerPrefs.SetString("scrapsDouble", Data.scrapsDouble.ToString());

            PlayerPrefs.SetInt("farms", Data.farms);
            PlayerPrefs.SetInt("pumps", Data.pumps);
            
            PlayerPrefs.SetFloat("clock", Data.clock);
            PlayerPrefs.SetFloat("hour", Data.hour);
            PlayerPrefs.SetInt("day", Data.day);
            PlayerPrefs.SetInt("endDay", Data.endDay);

            PlayerPrefs.SetInt("idle", Data.idle);
            PlayerPrefs.SetInt("survivors", Data.survivors);
            
            PlayerPrefs.SetInt("explorers", Data.explorers);
            PlayerPrefs.SetInt("scavengers", Data.scavengers);
            PlayerPrefs.SetInt("farmers", Data.farmers);
            PlayerPrefs.SetInt("pumpers", Data.pumpers);
            PlayerPrefs.SetInt("defenders", Data.defenders);

            PlayerPrefs.SetInt("attackLevel", Data.attackLevel);
            PlayerPrefs.SetInt("defenseLevel", Data.defenseLevel);
            PlayerPrefs.SetInt("healthLevel", Data.healthLevel);
            PlayerPrefs.SetInt("staminaLevel", Data.staminaLevel);
            PlayerPrefs.SetInt("explorationLevel", Data.explorationLevel);
            PlayerPrefs.SetInt("scavengingLevel", Data.scavengingLevel);
            
            PlayerPrefs.SetFloat("zombieTime", Data.zombieTime);
            PlayerPrefs.SetFloat("skeletonTime", Data.skeletonTime);
            PlayerPrefs.SetFloat("endermanTime", Data.endermanTime);
            
            PlayerPrefs.SetFloat("zombieInterval", Data.zombieInterval);
            PlayerPrefs.SetFloat("skeletonInterval", Data.skeletonInterval);
            PlayerPrefs.SetFloat("endermanInterval", Data.endermanInterval);

            PlayerPrefs.SetInt("kills", Data.kills);
        }
    }

    public void LoadData()
    {
        Data.difficulty = PlayerPrefs.GetInt("difficulty");
        Data.victory = PlayerPrefs.GetInt("victory");
        Data.hordeMode = PlayerPrefs.GetInt("hordeMode");
        Data.scene = PlayerPrefs.GetInt("scene");

        Data.explored = PlayerPrefs.GetInt("explored");
        Data.exploredDouble = double.Parse(PlayerPrefs.GetString("exploredDouble"));
        Data.notExplored = PlayerPrefs.GetInt("notExplored");
        Data.scavenged = PlayerPrefs.GetInt("scavenged");
        Data.scavengedDouble = double.Parse(PlayerPrefs.GetString("scavengedDouble"));
        Data.notScavenged = PlayerPrefs.GetInt("notScavenged");

        Data.DEF = PlayerPrefs.GetInt("DEF");
        Data.maxDEF = PlayerPrefs.GetInt("maxDEF");
        Data.ATK = PlayerPrefs.GetInt("ATK");

        Data.HP = PlayerPrefs.GetInt("HP");
        Data.maxHP = PlayerPrefs.GetInt("maxHP");
        Data.SP = PlayerPrefs.GetInt("SP");
        Data.maxSP = PlayerPrefs.GetInt("maxSP");
        
        Data.food = PlayerPrefs.GetInt("food");
        Data.foodDouble = double.Parse(PlayerPrefs.GetString("foodDouble"));
        Data.water = PlayerPrefs.GetInt("water");
        Data.waterDouble = double.Parse(PlayerPrefs.GetString("waterDouble"));
        Data.scraps = PlayerPrefs.GetInt("scraps");
        Data.scrapsDouble = double.Parse(PlayerPrefs.GetString("scrapsDouble"));

        Data.farms = PlayerPrefs.GetInt("farms");
        Data.pumps = PlayerPrefs.GetInt("pumps");
        
        Data.clock = PlayerPrefs.GetFloat("clock");
        Data.hour = PlayerPrefs.GetFloat("hour");
        Data.day = PlayerPrefs.GetInt("day");
        Data.endDay = PlayerPrefs.GetInt("endDay");

        Data.idle = PlayerPrefs.GetInt("idle");
        Data.survivors = PlayerPrefs.GetInt("survivors");
        
        Data.explorers = PlayerPrefs.GetInt("explorers");
        Data.scavengers = PlayerPrefs.GetInt("scavengers");
        Data.farmers = PlayerPrefs.GetInt("farmers");
        Data.pumpers = PlayerPrefs.GetInt("pumpers");
        Data.defenders = PlayerPrefs.GetInt("defenders");

        Data.attackLevel = PlayerPrefs.GetInt("attackLevel");
        Data.defenseLevel = PlayerPrefs.GetInt("defenseLevel");
        Data.healthLevel = PlayerPrefs.GetInt("healthLevel");
        Data.staminaLevel = PlayerPrefs.GetInt("staminaLevel");
        Data.explorationLevel = PlayerPrefs.GetInt("explorationLevel");
        Data.scavengingLevel = PlayerPrefs.GetInt("scavengingLevel");
        
        Data.zombieTime = PlayerPrefs.GetFloat("zombieTime");
        Data.skeletonTime = PlayerPrefs.GetFloat("skeletonTime");
        Data.endermanTime = PlayerPrefs.GetFloat("endermanTime");
        
        Data.zombieInterval = PlayerPrefs.GetFloat("zombieInterval");
        Data.skeletonInterval = PlayerPrefs.GetFloat("skeletonInterval");
        Data.endermanInterval = PlayerPrefs.GetFloat("endermanInterval");

        Data.kills = PlayerPrefs.GetInt("kills");
        
        Data.scene = 1;
        Data.speed = 0;
        SceneManager.LoadScene("Map");
    }
}

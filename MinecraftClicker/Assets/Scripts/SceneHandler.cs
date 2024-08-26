using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame!");
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ShortCampaign()
    {
        Data.difficulty = 1; // 1 to 3 (solo)
        Data.victory = 0;
        Data.hordeMode = 0;
        Data.scene = 1; // scene tracker

        // clicker
        Data.explored = 0;
        Data.exploredDouble = 0f;
        Data.notExplored = 100;
        Data.scavenged = 0;
        Data.scavengedDouble = 0f;
        Data.notScavenged = 1000;

        Data.DEF = 1000;
        Data.maxDEF = 1000;
        Data.ATK = 1;
        
        Data.HP = 100;
        Data.maxHP = 100;
        Data.SP = 100;
        Data.maxSP = 100;

        Data.food = 100;
        Data.foodDouble = 0f;
        Data.water = 100;
        Data.waterDouble = 0f;
        Data.scraps = 100;
        Data.scrapsDouble = 0f;

        Data.farms = 0;
        Data.pumps = 0;

        // clock
        Data.clock = 0f;
        Data.hour = 0f;
        Data.day = 1;
        Data.endDay = 15;
        Data.speed = 0f;

        // job population
        Data.idle = 10;
        Data.survivors = 10;

        Data.explorers = 0;
        Data.scavengers = 0;
        Data.farmers = 0;
        Data.pumpers = 0;
        Data.defenders = 0;

        // upgrade
        Data.attackLevel = 1;
        Data.defenseLevel = 1;
        Data.healthLevel = 1;
        Data.staminaLevel = 1;
        Data.explorationLevel = 1;
        Data.scavengingLevel = 1;

        // mob behavior
        Data.zombieTime = 0f;
        Data.skeletonTime = 0f;
        Data.endermanTime = 0f;
        
        Data.zombieInterval = 30f;
        Data.skeletonInterval = 60f;
        Data.endermanInterval = 120f;

        // map
        Data.kills = 0;

        SceneManager.LoadScene("Map");
    }

    public void LongCampaign()
    {
        Data.difficulty = 2; // 1 to 3 (solo)
        Data.victory = 0;
        Data.hordeMode = 0;
        Data.scene = 1; // scene tracker

        // clicker
        Data.explored = 0;
        Data.exploredDouble = 0f;
        Data.notExplored = 100;
        Data.scavenged = 0;
        Data.scavengedDouble = 0f;
        Data.notScavenged = 1000;

        Data.DEF = 500;
        Data.maxDEF = 500;
        Data.ATK = 5;
        
        Data.HP = 100;
        Data.maxHP = 100;
        Data.SP = 100;
        Data.maxSP = 100;

        Data.food = 10;
        Data.foodDouble = 0f;
        Data.water = 10;
        Data.waterDouble = 0f;
        Data.scraps = 10;
        Data.scrapsDouble = 0f;

        Data.farms = 1;
        Data.pumps = 1;

        // clock
        Data.clock = 0f;
        Data.hour = 0f;
        Data.day = 1;
        Data.endDay = 30;
        Data.speed = 0f;

        // job population
        Data.idle = 0;
        Data.survivors = 0;

        Data.explorers = 0;
        Data.scavengers = 0;
        Data.farmers = 0;
        Data.pumpers = 0;
        Data.defenders = 0;

        // upgrade
        Data.attackLevel = 1;
        Data.defenseLevel = 1;
        Data.healthLevel = 1;
        Data.staminaLevel = 1;
        Data.explorationLevel = 1;
        Data.scavengingLevel = 1;

        // mob behavior
        Data.zombieTime = 0f;
        Data.skeletonTime = 0f;
        Data.endermanTime = 0f;
        
        Data.zombieInterval = 20f;
        Data.skeletonInterval = 40f;
        Data.endermanInterval = 60f;

        // map
        Data.kills = 0;
        SceneManager.LoadScene("Map");
    }

    public void EndlessCampaign()
    {
        Data.difficulty = 3; // 1 to 3 (solo)
        Data.victory = 0;
        Data.hordeMode = 0;
        Data.scene = 1; // scene tracker

        // clicker
        Data.explored = 0;
        Data.exploredDouble = 0f;
        Data.notExplored = 100;
        Data.scavenged = 0;
        Data.scavengedDouble = 0f;
        Data.notScavenged = 1000;

        Data.DEF = 1000;
        Data.maxDEF = 1000;
        Data.ATK = 10;
        
        Data.HP = 100;
        Data.maxHP = 100;
        Data.SP = 100;
        Data.maxSP = 100;

        Data.food = 100;
        Data.foodDouble = 0f;
        Data.water = 100;
        Data.waterDouble = 0f;
        Data.scraps = 100;
        Data.scrapsDouble = 0f;

        Data.farms = 0;
        Data.pumps = 0;

        // clock
        Data.clock = 0f;
        Data.hour = 0f;
        Data.day = 1;
        Data.endDay = 50;
        Data.speed = 0f;

        // job population
        Data.idle = 0;
        Data.survivors = 0;

        Data.explorers = 0;
        Data.scavengers = 0;
        Data.farmers = 0;
        Data.pumpers = 0;
        Data.defenders = 0;

        // upgrade
        Data.attackLevel = 1;
        Data.defenseLevel = 1;
        Data.healthLevel = 1;
        Data.staminaLevel = 1;
        Data.explorationLevel = 1;
        Data.scavengingLevel = 1;

        // mob behavior
        Data.zombieTime = 0f;
        Data.skeletonTime = 0f;
        Data.endermanTime = 0f;
        
        Data.zombieInterval = 10f;
        Data.skeletonInterval = 20f;
        Data.endermanInterval = 30f;

        // map
        Data.kills = 0;
        SceneManager.LoadScene("Map");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenMap()
    {
        Data.scene = 1;
        SceneManager.LoadScene("Map");
    }

    public void OpenUpgrade()
    {
        Data.scene = 2;
        SceneManager.LoadScene("Upgrade");
    }

    public void OpenJob()
    {
        Data.scene = 3;
        SceneManager.LoadScene("JOb");
    }

    public void ContinueGame()
    {
        Data.speed = 0;
        SceneManager.LoadScene("Map");
    }
}

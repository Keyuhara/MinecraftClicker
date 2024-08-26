using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    // important flags
    public static int difficulty = 1; // 1 to 3 (solo)
    public static int victory = 0;
    public static int hordeMode = 0;
    public static int scene = 1; // scene tracker

    // clicker
    public static int explored = 0;
    public static double exploredDouble = 0f;
    public static int notExplored = 100;
    public static int scavenged = 0;
    public static double scavengedDouble = 0f;
    public static int notScavenged = 1000;

    public static int DEF = 1000;
    public static int maxDEF = 1000;
    public static int ATK = 1;
    
    public static int HP = 100;
    public static int maxHP = 100;
    public static int SP = 100;
    public static int maxSP = 100;

    public static int food = 0;
    public static double foodDouble = 0f;
    public static int water = 0;
    public static double waterDouble = 0f;
    public static int scraps = 0;
    public static double scrapsDouble = 0f;

    public static int farms = 0;
    public static int pumps = 0;

    // clock
    public static float clock = 0f;
    public static float hour = 0f;
    public static int day = 1;
    public static int endDay = 10;
    public static float speed = 0f;

    // job population
    public static int idle = 10;
    public static int survivors = 10;

    public static int explorers = 0;
    public static int scavengers = 0;
    public static int farmers = 0;
    public static int pumpers = 0;
    public static int defenders = 0;

    // upgrade
    public static int attackLevel = 1;
    public static int defenseLevel = 1;
    public static int healthLevel = 1;
    public static int staminaLevel = 1;
    public static int explorationLevel = 1;
    public static int scavengingLevel = 1;

    // mob behavior
    public static float zombieTime = 0f;
    public static float skeletonTime = 0f;
    public static float endermanTime = 0f;
    
    public static float zombieInterval = 120f;
    public static float skeletonInterval = 480f;
    public static float endermanInterval = 720f;

    // map
    public static int kills = 0;
    public static Color green = new Color32(0, 128, 0, 255);
    public static Color blue = new Color32(0, 0, 255, 255);
    public static Color white = new Color32(255, 255, 255, 255);

}

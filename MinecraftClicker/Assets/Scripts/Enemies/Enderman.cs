using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enderman : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text defenseText;
    public TMP_Text defendingText;
    public GameObject player;
    public Texture2D map;

    public int health = 50 + (Data.day * 10);
    public int damage = 10 + Data.day;
    public float speed;
    public Vector3 location; // gameObject.transform.position

    private float distance;

    public float cooldown = 0f; // teleport
    float x;
    float y;
    
    public LootHandler loot;
    
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Data.kills++;
            loot.Loot();
            if (gameObject != null)
            {    
                Destroy(this.gameObject);
            }
        }

        location = gameObject.transform.position;

        distance = Vector2.Distance(transform.position, player.transform.position);
        
        // movement is affected by environment
        if(Data.blue.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {
            health -= 1; // takes water damage

            //TELEPORT
            while( !(Data.green.Equals(map.GetPixel(Mathf.RoundToInt(x), Mathf.RoundToInt(y)))) )
            {
                speed = 0.5f * (Mathf.Log(Data.day+1, 5) * Data.speed * Data.hordeMode);
                // get another x, y coordinates
                x = Random.Range(gameObject.transform.position.x, player.transform.position.x);
                y = Random.Range(gameObject.transform.position.y, player.transform.position.y);
            }
        }
        else if(Data.green.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {
            speed = 1.5f * (Mathf.Log(Data.day+1, 5) * Data.speed * Data.hordeMode);
        }
        else if(Data.white.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {
            speed = 0.1f;
        }
        else
        {
            speed = 0;
        }
        
        if(distance > 75 && Data.speed != 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if(distance > 3 && Data.speed != 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if(distance <= 3)
        {
            if(Data.DEF > 0)
            {
                Data.DEF -= damage;
                defenseText.text = "DEF: " + Data.DEF.ToString() + " / " + Data.maxDEF.ToString();
            }
            else
            {
                Data.HP -= damage;
                healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();
            }

            if (gameObject != null)
            {    
                Destroy(this.gameObject);
            }
        }
    }

    public void OnMouseDown() 
    {
        if(Data.speed != 0)
        {   
            health -= (int)Data.speed  * (Data.ATK + Data.defenders);
            Data.SP -= 1;
        }

        if(Data.SP < 0)
        {
            Data.SP = 0;
        }
        staminaText.text = "SP: " + Data.SP.ToString() + " / " + Data.maxSP.ToString();
    }
}

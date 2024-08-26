using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public GameObject player;
    public TMP_Text healthText;
    private float distance;
    public Texture2D map;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        // prevent loss of prefab
        if(Data.blue.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {
            speed = 1.0f;
        }
        else if(Data.green.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {    
            speed = 1.0f;
        }
        else if(Data.white.Equals(map.GetPixel(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y))))
        {
            speed = 1.0f;
        }
        else
        {    
            speed = 0;
        }

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Data.speed * Time.deltaTime * Data.day ); //DIFFICULTY

        if(distance <= 3)
        {
            Data.HP -= 1;
            healthText.text = "HP: " + Data.HP.ToString() + " / " + Data.maxHP.ToString();

            if (gameObject != null)
            {    
                Destroy(this.gameObject);
            }
        }
    }
}

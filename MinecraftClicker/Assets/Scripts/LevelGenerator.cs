using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ASSETS
// Convert Pixel Image to Tilemap: https://www.youtube.com/watch?v=B_Xp9pt8nRY

public class LevelGenerator : MonoBehaviour
{
    // public Texture2D map;
    // public ColorToPrefab[] colorMappings;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     GenerateLevel();
    // }

    // void GenerateLevel()
    // {
    //     // for(int x = 0; x < map.width; x++)
    //     // {
    //     //     for(int y = 0; y < map.height; y++)
    //     //     {
    //     //         GenerateTile(x, y);
    //     //     }
    //     // }
    // }

    // void GenerateTile(int x, int y)
    // {
    //     Color pixelColor = map.GetPixel(x, y);

    //     if(pixelColor.a == 0)
    //     {
    //         // The pixel is transparent. Ignore it.
    //         return;
    //     }

    //     foreach (ColorToPrefab colorMapping in colorMappings)
    //     {
    //         if(colorMapping.color.Equals(pixelColor))
    //         {
    //             Vector2 position = new Vector2(x, y);
    //             var spawnedTile = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
    //             spawnedTile.name = $"Tile {x} {y}";
    //         }
    //     }
    // }
}

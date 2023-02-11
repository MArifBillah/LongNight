using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassGenerator : MonoBehaviour
{
 public GameObject grassPrefab; // The prefab of the grass you want to use
    public float grassSpacing = 1f; // The distance between each grass instance
    public float grassHeight = 0.5f; // The height of the grass from the terrain surface

    public Terrain terrain;
    private TerrainData terrainData;

    void Start()
    {
        // Get the terrain component attached to the same GameObject
        terrain = terrain.GetComponent<Terrain>();
        terrainData = terrain.terrainData;

        // Calculate the size of the terrain
        float terrainWidth = terrainData.size.x;
        float terrainLength = terrainData.size.z;

        print("terrain widht and length"+ terrainWidth +"x"+terrainLength);

        // Create a 2D array to store the heights of the terrain
        float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);

        // Loop through the terrain and place grass at random locations
        for (int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                // Check if the current position is eligible for grass placement
                if (x % grassSpacing == 0 && y % grassSpacing == 0)
                {
                    // Get the world position of the current terrain sample
                    float worldX = x / (float)terrainData.heightmapResolution * terrainWidth;
                    float worldZ = y / (float)terrainData.heightmapResolution * terrainLength;

                    // Calculate the height of the terrain at the current sample
                    float height = heights[x, y];

                    // Place a grass instance at the current position
                    Vector3 grassPosition = new Vector3(worldX, height * terrainData.size.y + grassHeight, worldZ);
                    Instantiate(grassPrefab, grassPosition, Quaternion.identity, transform);
                }
            }
        }
    }
}

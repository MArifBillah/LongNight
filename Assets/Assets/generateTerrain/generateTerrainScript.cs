using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTerrainScript : MonoBehaviour
{

    public Terrain terrain;
    public Texture2D heightmapTexture;
    public float heightScale = 1f;

    void Start()
    {
        LoadTerrain(heightmapTexture, terrain.terrainData, heightScale);
    }

    void LoadTerrain(Texture2D heightmap, TerrainData terrainData, float heightScale)
    {
        int heightmapWidth = heightmap.width;
        int heightmapHeight = heightmap.height;
        float[,] heights = new float[heightmapHeight, heightmapWidth];

        // Get the color data from the texture and set the terrain heights
        Color[] colorMap = heightmap.GetPixels();
        for (int y = 0; y < heightmapHeight; y++)
        {
            for (int x = 0; x < heightmapWidth; x++)
            {
                float heightValue = colorMap[y * heightmapWidth + x].grayscale;
                heightValue *= heightScale;
                heights[y, x] = heightValue;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}

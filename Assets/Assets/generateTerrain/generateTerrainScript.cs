using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;
using System.Linq;

public class generateTerrainScript : MonoBehaviour
{
    // this one is for the GAN
    public int imageSize;
    IWorker m_Worker;
    System.Random rand = new System.Random();
    public NNModel modelAsset;
    private Model m_RuntimeModel;

    public Terrain terrain;
    // public Texture2D heightmapTexture;
    public float heightScale = 1f;

    void Start()
    {
        m_RuntimeModel = ModelLoader.Load(modelAsset);
        m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, m_RuntimeModel);
        LoadTerrain(terrain.terrainData, heightScale);
    }
    int counter = 0;
    void LoadTerrain(TerrainData terrainData, float heightScale)
    {
        Tensor input = new Tensor(1, 1, 1, 128); 
        // m_Worker.Execute(input);
        // input.Dispose();

        var mean = 0f;
        var stdDev = 1f;
        for (int i = 0; i < input.length; i++)
        {
            
            double u1 = 1.0-rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0-rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                   Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            input[i] = (float)randNormal*Random.Range(-1f,1f)*(-1f);
            
        }
        
        m_Worker.Execute(input);
        Tensor O = m_Worker.PeekOutput("modelOutput");
        input.Dispose();
        

        int heightmapWidth = imageSize;
        int heightmapHeight = imageSize;
        float[,] heights = new float[heightmapHeight, heightmapWidth];

        // Get the color data from the texture and set the terrain heights
        // Color[] colorMap = heightmap.GetPixels();
        for (int y = 0; y < heightmapHeight; y++)
        {
            for (int x = 0; x < heightmapWidth; x++)
            {
                float heightValue = O[counter];
                counter++;
                heightValue *= heightScale;
                heightValue += 1;
                heights[y, x] = heightValue;
                // print("this is the height value ="+heightValue);
            }
        }

        terrainData.SetHeights(0, 0, heights);
        O.Dispose();
    }
    
}

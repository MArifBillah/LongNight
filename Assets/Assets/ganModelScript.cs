using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;
using System.Linq;
public class ganModelScript : MonoBehaviour
{
    
    // public Texture2D portrait;
    // public RawImage destination;
    public int imageSize;
    IWorker m_Worker;
    System.Random rand = new System.Random();
    public NNModel modelAsset;
    private Model m_RuntimeModel;

        void Start()
        {   
            m_RuntimeModel = ModelLoader.Load(modelAsset);
            m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, m_RuntimeModel);
            Tensor input = new Tensor(1, 1, 1, 128); 
            m_Worker.Execute(input);
            // Tensor O = m_Worker.PeekOutput("modelOutput");
            input.Dispose();

            
        


//         m_RuntimeModel = ModelLoader.Load(modelAsset);
//         m_Worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Compute, m_RuntimeModel);
//         // Classify(image);
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
            input[i] = (float)randNormal;
        }
        m_Worker.Execute(input);
        Tensor O = m_Worker.PeekOutput("modelOutput");
        input.Dispose();
        // var rTexture = new RenderTexture(imageSize, imageSize, 24, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        // O.ToRenderTexture(rTexture);
        // portrait = toTexture2D(rTexture);
        // destination.texture = portrait;
        // for (int y = 0; y < portrait.height; y++)
        // {
        //     for (int x = 0; x < portrait.width; x++)
        //     {
        //         float heightValue = colorMap[y * heightmapWidth + x].grayscale;
        //         // heightValue *= heightScale;
        //         // heights[y, x] = heightValue;
        //     }
        // }
        O.Dispose();
        // rTexture.DiscardContents();
        // print("this is the output = "+O);
        //     print("this is the length of the output = "+O.length);
         }

   void OnDestroy()
    {
        m_Worker.Dispose();
    }
 
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        var pixels = tex.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            // pixels[i] =LinearToGamma(pixels[i]);
        }
        tex.SetPixels(pixels);      
        tex.Apply();
        return tex;
    }
 
    Color LinearToGamma(Color c)
    {
        return new Color(Mathf.LinearToGammaSpace(c.r), Mathf.LinearToGammaSpace(c.g), Mathf.LinearToGammaSpace(c.b),
            c.a);
    }
}

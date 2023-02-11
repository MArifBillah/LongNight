using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public int point;
    public int goalSpawned;

    void Update()
    {
        print("current score is "+point);
         print("Goal spawned is "+goalSpawned);
    }
}

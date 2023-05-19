using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalMarker : MonoBehaviour
{
    public Sprite icon;
    public Image image;
    public GameObject compasScript;
    public goalMarker theMarker;
    public GameObject markerObject;
    GameObject destroyIcon;
    public bool destroyed;
    public GameObject compass;
    public static int countTheGoal;

    public Vector2 position{
        get {return new Vector2 (transform.position.x, transform.position.z);}
    }
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        // compasScript = 
        destroyed = false;
        countTheGoal++;
        counter = countTheGoal;
        print("Jumlah goal yang muncul="+countTheGoal);
        
            if(markerObject.name != "goal"){
                destroyIcon = compasScript.GetComponent<compasScript>().AddGoalMarker(theMarker);
                print("testing destroyicon");
            }

    }

    // Update is called once per frame
    void Update()
    {
        // print(destroyed);
        if(destroyed)
        {
            print("testing destroyed = "+markerObject.name+" nomor ke="+counter);
            
            destroyIcon.SetActive(false);
            
            // print("this is in the list =");
            compass.GetComponent<compasScript>().reduceMarker(theMarker);
            destroyThisObject();
            // print("target been destroyed");
        }
    }

    void destroyThisObject() 
    {
        Destroy(gameObject);
    }
}

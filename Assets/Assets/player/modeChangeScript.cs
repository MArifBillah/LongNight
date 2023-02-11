using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChangeScript : MonoBehaviour
{
    public GameObject playerMode;
    public GameObject bikeMode;
    public GameObject bikePosition;
    public GameObject playerPosition;
    
    // Update is called once per frame
    void Start()
    {
        bikeMode.SetActive(false);
        playerMode.SetActive(true);
    }
    void Update()
    {
        //Player mode
        if(Input.GetKey(KeyCode.Alpha1) && playerMode.activeSelf == false)
        {  
            playerPosition.transform.position = bikePosition.transform.position;
            bikeMode.SetActive(false);
            playerMode.SetActive(true);
        }

        //Bike mode
        if(Input.GetKey(KeyCode.Alpha2) && bikeMode.activeSelf == false)
        {
            bikePosition.transform.position = playerPosition.transform.position;
            bikeMode.SetActive(true);
            playerMode.SetActive(false);
        }
    }
}

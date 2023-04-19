using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChangeScript : MonoBehaviour
{
    public GameObject playerMode;
    public GameObject bikeMode;
    public GameObject boatMode;
    public GameObject bikePosition;
    public GameObject playerPosition;
    public GameObject boatPosition;
    
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
            if(boatMode.activeSelf)
            {
                boatPosition.transform.position = boatPosition.transform.position;
            }

            if(bikeMode.activeSelf)
            {
                boatPosition.transform.position = bikePosition.transform.position;
            }            
            // playerPosition.transform.position = transform.position;
            boatMode.SetActive(false);
            bikeMode.SetActive(false);
            playerMode.SetActive(true);
        }

        //Bike mode
        if(Input.GetKey(KeyCode.Alpha2) && bikeMode.activeSelf == false)
        {

            if(playerMode.activeSelf)
            {
                boatPosition.transform.position = playerPosition.transform.position;
            }

            if(boatMode.activeSelf)
            {
                boatPosition.transform.position = boatPosition.transform.position;
            }
            
            // bikePosition.transform.position = transform.position;
            boatMode.SetActive(false);
            playerMode.SetActive(false);
            bikeMode.SetActive(true);
        }

        //Boat mode
        if(Input.GetKey(KeyCode.Alpha3) && boatMode.activeSelf == false)
        {
            if(playerMode.activeSelf)
            {
                boatPosition.transform.position = playerPosition.transform.position;
                boatPosition.transform.rotation = Quaternion.identity;
            }

            if(bikeMode.activeSelf)
            {
                boatPosition.transform.position = bikePosition.transform.position;
                boatPosition.transform.rotation = Quaternion.identity;
            }
            
            bikeMode.SetActive(false);
            playerMode.SetActive(false);
            boatMode.SetActive(true);
        }
    }
}

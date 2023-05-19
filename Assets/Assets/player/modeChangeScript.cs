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
    public GameObject fixRotation;
    
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
                playerPosition.transform.position = boatPosition.transform.position;
            }

            if(bikeMode.activeSelf)
            {
                playerPosition.transform.position = bikePosition.transform.position;
            }            
            // playerPosition.transform.position = transform.position;
            boatMode.SetActive(false);
            bikeMode.SetActive(false);
            playerMode.SetActive(true);
        }

        //Bike mode
        if(Input.GetKey(KeyCode.Alpha2) && bikeMode.activeSelf == false)
        {
            enemyScript.canBeDamaged = true;
            if(playerMode.activeSelf)
            {
                bikePosition.transform.position = playerPosition.transform.position;
                bikePosition.transform.rotation = fixRotation.transform.rotation;
            }

            if(boatMode.activeSelf)
            {
                bikePosition.transform.position = boatPosition.transform.position;
                
            }
            
            // bikePosition.transform.position = transform.position;
            boatMode.SetActive(false);
            playerMode.SetActive(false);
            bikeMode.SetActive(true);
        }

        //Boat mode
        if(Input.GetKey(KeyCode.Alpha3) && boatMode.activeSelf == false)
        {
            enemyScript.canBeDamaged = true;
            if(playerMode.activeSelf)
            {
                boatPosition.transform.position = playerPosition.transform.position;
                boatPosition.transform.rotation = Quaternion.identity;
                boatPosition.transform.rotation = fixRotation.transform.rotation;
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

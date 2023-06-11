using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChangeScript : MonoBehaviour
{
    //for changing player mode
    public GameObject playerMode;
    public GameObject bikeMode;
    public GameObject boatMode;
    public GameObject bikePosition;
    public GameObject playerPosition;
    public GameObject boatPosition;
    public GameObject fixRotation;
    
    //for changing torched
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    // Update is called once per frame
    void Start()
    {
        int torchEquipped = PlayerPrefs.GetInt("torch");
        switch(torchEquipped)
        {
            case 1:
                torch2.SetActive(false);
                torch3.SetActive(false);
                torch1.SetActive(true);
                break;
            case 2:
                torch2.SetActive(true);
                torch3.SetActive(false);
                torch1.SetActive(false);
                break;
            case 3:
                torch2.SetActive(false);
                torch3.SetActive(true);
                torch1.SetActive(false);
                break;
            default:
                torch2.SetActive(false);
                torch3.SetActive(false);
                torch1.SetActive(true);
                break;

        }
        bikeMode.SetActive(false);
        playerMode.SetActive(true);
    }
    void Update()
    {
        //Player mode
        if(Input.GetKey(KeyCode.Alpha1) && playerMode.activeSelf == false)
        {  
            playerModeChange();
        }

        //Bike mode
        if(Input.GetKey(KeyCode.Alpha2) && bikeMode.activeSelf == false)
        {
            bikeModeChange();
        }

        //Boat mode
        if(Input.GetKey(KeyCode.Alpha3) && boatMode.activeSelf == false)
        {
            boatModeChange();
        }
    }

    public void playerModeChange()
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

    public void bikeModeChange()
    {
        enemyScript.canBeDamaged = true;
        if(playerMode.activeSelf && playerMovement.grounded)
        {
            bikePosition.transform.position = playerPosition.transform.position;
            bikePosition.transform.rotation = fixRotation.transform.rotation;
            // bikePosition.transform.position = transform.position;
            boatMode.SetActive(false);
            playerMode.SetActive(false);
            bikeMode.SetActive(true);
        }

        if(boatMode.activeSelf)
        {
            bikePosition.transform.position = boatPosition.transform.position;
            // bikePosition.transform.position = transform.position;
            boatMode.SetActive(false);
            playerMode.SetActive(false);
            bikeMode.SetActive(true);
                
        }
    }

    public void boatModeChange()
    {
            enemyScript.canBeDamaged = true;
            if(playerMode.activeSelf && !playerMovement.grounded)
            {
                boatPosition.transform.position = playerPosition.transform.position;
                boatPosition.transform.rotation = Quaternion.identity;
                boatPosition.transform.rotation = fixRotation.transform.rotation;
                bikeMode.SetActive(false);
                playerMode.SetActive(false);
                boatMode.SetActive(true);
            }
            else{
                print("Can't turn into boat!");
            }

            if(bikeMode.activeSelf)
            {
                boatPosition.transform.position = bikePosition.transform.position;
                boatPosition.transform.rotation = Quaternion.identity;
                bikeMode.SetActive(false);
                playerMode.SetActive(false);
                boatMode.SetActive(true);
            }
    }
}

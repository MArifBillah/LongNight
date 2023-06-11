using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scoreAndStore : MonoBehaviour
{
     public TMP_Text highScoreText;
     public TMP_Text currencyText;
     public bool storeIsOpen;
     int currency;
    
    //displayed items
    public RawImage itemDisplay;
    public Texture item1;
    public Texture item2;
    public Texture item3;

    public GameObject priceTag1;
    public GameObject priceTag2;
    void Start()
    {
        storeIsOpen = false;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = savedScore.ToString();
        int savedTorch = PlayerPrefs.GetInt("torch");
        switch(savedTorch)
        {
            case 1:
                itemDisplay.GetComponent<RawImage>().texture = item1; 
                break;
            case 2:
                itemDisplay.GetComponent<RawImage>().texture = item2; 
                break;
            case 3:
                itemDisplay.GetComponent<RawImage>().texture = item3; 
                break;

            default:
                itemDisplay.GetComponent<RawImage>().texture = item1; 
                break;
        }

        //delete the price tag if already unlocked
        int unlockedTorch1 = PlayerPrefs.GetInt("unlockItem1");
        if(unlockedTorch1 == 1)
        {
            priceTag1.SetActive(false);
        }

        int unlockedTorch2 = PlayerPrefs.GetInt("unlockItem2");
        if(unlockedTorch2 == 1)
        {
            priceTag2.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(storeIsOpen)
        {
            currency = PlayerPrefs.GetInt("currency");
            currencyText.text = currency.ToString();
        }
    }

    public void openingStore()
    {
        storeIsOpen = true;
    }

    public void closingStore()
    {
        storeIsOpen = false;
    }

    public void chooseItem1()
    {
        PlayerPrefs.SetInt("torch", 1);
        itemDisplay.GetComponent<RawImage>().texture = item1; 

    }

    public void chooseItem2()
    {
        if(PlayerPrefs.GetInt("unlockItem1")==1)
        {
             itemDisplay.GetComponent<RawImage>().texture = item2; 
             PlayerPrefs.SetInt("torch",2);
        }else
        {
            if(currency>=100)
            {
                currency-=100;
                PlayerPrefs.SetInt("currency", currency);
                PlayerPrefs.SetInt("torch",2);
                itemDisplay.GetComponent<RawImage>().texture = item2; 
                PlayerPrefs.SetInt("unlockItem1",1);
                priceTag1.SetActive(false);
            }else{
                print("Not Enough currency");
            }
        }
    }

    public void chooseItem3()
    {
        if(PlayerPrefs.GetInt("unlockItem2")==1)
        {
             itemDisplay.GetComponent<RawImage>().texture = item2;
             PlayerPrefs.SetInt("torch",3); 
        }else
        {
            if(currency>=1000)
            {
                currency-=1000;
                PlayerPrefs.SetInt("currency", currency);
                PlayerPrefs.SetInt("torch",3);
                itemDisplay.GetComponent<RawImage>().texture = item3; 
                PlayerPrefs.SetInt("unlockItem2",1);
                priceTag1.SetActive(false);
            }else{
                print("Not Enough currency");
            }
        }
    }
}

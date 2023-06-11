using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class settingNR : MonoBehaviour
{
    public AudioSource mySound;
    public Slider sliderVolume;
    float volumeLevel;
    bool isInSetting;
    // Start is called before the first frame update
    void Start()
    {

        isInSetting = false;
        if(PlayerPrefs.HasKey("volume"))
        {
            volumeLevel = PlayerPrefs.GetFloat("volume");
            mySound.GetComponent<AudioSource>().volume = volumeLevel;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInSetting)
        {
            volumeLevel = sliderVolume.value;
            mySound.GetComponent<AudioSource>().volume = volumeLevel;
        }
        
    }

    public void applySetting()
    {
        
        PlayerPrefs.SetFloat("volume",volumeLevel);
        mySound.GetComponent<AudioSource>().volume = volumeLevel;
    }

    public void resetAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void settingOpen()
    {
        isInSetting = true;
    }

    public void settingClose()
    {
        isInSetting=false;
    }

}

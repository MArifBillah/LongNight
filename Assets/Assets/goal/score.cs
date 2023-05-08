using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int point;
    public int goalSpawned;
    public GameObject winState;
    public GameObject playerUI;
    public int playerHealth;
    public Slider healthSlider;

    // final score for winning
    public int finalScore;
    void Start()
    {
        playerHealth=100;
    }
    void Update()
    {
        healthSlider.value = playerHealth;
        print("current score is "+point);
         print("Goal spawned is "+goalSpawned);
         if(point == 3)
         {
            playerWin();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
         }
    }

    void playerWin()
    {
        playerUI.SetActive(false);
        winState.SetActive(true);
        float time = gameObject.GetComponent<timerScript>().timeCount;
        int timeInt = Mathf.RoundToInt(time);
        if(time<600)
        {
            finalScore = playerHealth-10;
        }
        //lanjutkan nanti
    }

    void playerLose()
    {
        if(playerHealth<1)
        {
            //playerlose UI here
        }
    }
}

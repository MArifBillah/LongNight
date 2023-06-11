using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public int point;
    public int goalSpawned;
    public GameObject winState;
    public GameObject loseState;
    public GameObject playerUI;
    public int playerHealth;
    public Slider healthSlider;

    // final score for winning
    public float finalScore;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    bool winning;
    void Start()
    {
        winning = false;
        playerHealth=100;
    }
    void Update()
    {
        healthSlider.value = playerHealth;
         if(point == 3 && !winning)
         {
            Time.timeScale = 0;
            playerWin();
            winning = true;
         }

         if(playerHealth<1)
         {
            playerLose();
         }
    }

    void playerWin()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playerUI.SetActive(false);
        winState.SetActive(true);
        float time = gameObject.GetComponent<timerScript>().timeCount;
        
        
        //win score
        finalScore = playerHealth/(time/100);
        int displayScore = Mathf.RoundToInt(finalScore);
        scoreText.text = displayScore.ToString();
        timerText.text = time.ToString();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            int savedScore = PlayerPrefs.GetInt("HighScore");
            if(displayScore>savedScore)
            {
                PlayerPrefs.SetInt("HighScore", displayScore);
                PlayerPrefs.SetFloat("BestTime",time);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", displayScore);
            PlayerPrefs.SetFloat("BestTime",time);
        }

        if(PlayerPrefs.HasKey("currency"))
        {
            int currency = PlayerPrefs.GetInt("currency");
            currency += displayScore;
            PlayerPrefs.SetInt("currency", currency);
        }
        else
        {
            PlayerPrefs.SetInt("currency", displayScore);
        }

        
        
        // print("Highest Score now : "+PlayerPrefs.GetInt("HighScore"));
        
    }

    void playerLose()
    {
        if(playerHealth<1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //playerlose UI here
            Time.timeScale = 0;
            loseState.SetActive(true);
        }
    }
}

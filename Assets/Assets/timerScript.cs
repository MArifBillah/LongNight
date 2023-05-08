using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerScript : MonoBehaviour
{
    
    public TMP_Text timeText;
    public float timeCount;
    private void Start()
    {
        timeCount = 0f;
    }
    void Update()
    {
        timeCount += Time.deltaTime;
        DisplayTime(timeCount);
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

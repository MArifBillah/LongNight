using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backstory;
    bool readyToStartGame;
    void Start()
    {
        readyToStartGame = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("return") && readyToStartGame)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        backstory.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        readyToStartGame = false;
    }

    public void Ready()
    {
        readyToStartGame = true;
    }
}

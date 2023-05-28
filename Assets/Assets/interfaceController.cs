using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interfaceController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerUI;
    public GameObject pauseUI;
    bool isPaused;
    void Start()
    {
        isPaused = false;
        // Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        }
    }

    void PauseGame ()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1;
    }
}

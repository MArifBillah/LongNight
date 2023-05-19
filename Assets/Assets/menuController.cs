using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Application.Quit();
    }

    public void startGame()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

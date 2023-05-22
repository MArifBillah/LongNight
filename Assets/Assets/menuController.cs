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

    public void restartGame()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void startGame()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("procedural");
    }

    public void swampyStart()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("Swampy");
    }

    public void riverStart()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("river");
    }

    public void lakeStart()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("lake");
    }

    public void forestStart()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("forest");
    }

    public void floodStart()
    {
        goalMarker.countTheGoal=0;
        compasScript.goalMarkers.Clear();
        SceneManager.LoadScene("flooded");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

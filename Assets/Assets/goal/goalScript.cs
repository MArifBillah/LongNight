using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject parent;
    
    void Start()
    {
        gameManager.GetComponent<score>().goalSpawned+=1;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameManager.GetComponent<score>().point += 1;
            gameManager.GetComponent<score>().goalSpawned -= 1;
            Destroy(parent);
        }
    }
}

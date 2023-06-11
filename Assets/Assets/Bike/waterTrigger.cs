using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "water")
        {
            gameManager.GetComponent<modeChangeScript>().boatModeChange();
        }
    }
}

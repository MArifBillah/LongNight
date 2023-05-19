using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemyMesh")
        {
            enemyScript.canBeDamaged = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "enemyMesh")
        {
            enemyScript.canBeDamaged = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

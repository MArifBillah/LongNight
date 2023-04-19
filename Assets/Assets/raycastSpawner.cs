using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastSpawner : MonoBehaviour
{
     public GameObject itemsToSpread;
    //  public GameObject water;
     public float raycastDistance = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        raySpanner();
    }

    // Update is called once per frame
    void raySpanner()
    {
        RaycastHit hit;
        bool check = Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance);
        // print(hit.collider.gameObject.name);
        // print(water.transform.position.y);
        if(check && (hit.collider.gameObject.name != "floor"))
        {
            GameObject clone = Instantiate(itemsToSpread, hit.point, Quaternion.identity);
        }
        else if (itemsToSpread.name == "goal")
        {
            print("Di spawn tapi kena air");
             GameObject clone = Instantiate(itemsToSpread, hit.point, Quaternion.identity);
        }
    }
}

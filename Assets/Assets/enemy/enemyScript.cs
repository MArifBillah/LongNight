using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    private bool isInDanger = false;
    private bool isDamaging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            isInDanger = true;
            isDamaging = true;
        }
            
            
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            // print("Player inside enemy range");
            isInDanger = false;
            isDamaging = false;
        }
            
    }
    private IEnumerator coroutine;
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(isInDanger && isDamaging)
        {
            coroutine = WaitAndPrint(2.0f);
            StartCoroutine(coroutine);
            
        }
            
    }

    // every 2 seconds perform 
    private IEnumerator WaitAndPrint(float waitTime)
    {
            isInDanger =false;
            // Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(waitTime);
            // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            if(player.GetComponent<playerMovement>().isTorching == true)
            {
                gameManager.GetComponent<score>().playerHealth-=5;
            }
            else
            {
                gameManager.GetComponent<score>().playerHealth-=10;
            } 
            
            isInDanger=true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamableScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    private bool isInDanger = false;
    private bool isDamaging = false;
    private bool isBurning = false;
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
            if(player.GetComponent<playerMovement>().isTorching == true)
            {
                isBurning = true;
            }   

            if(isBurning)
            {
                coroutine = WaitAndPrint(2.0f);
                StartCoroutine(coroutine);
            }
        }
            
    }

    // every 2 seconds perform 
    private IEnumerator WaitAndPrint(float waitTime)
    {
            isInDanger =false;
            // Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(waitTime);
            // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            gameManager.GetComponent<score>().playerHealth -=10;
            isInDanger=true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    private bool isInDanger = false;
    private bool isDamaging = false;
    public GameObject enemyAnimation;
    public AudioSource jscareSound;
    public static bool canBeDamaged;
    Transform playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        canBeDamaged = true;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            playerLocation = other.transform;
            isInDanger = true;
            isDamaging = true;
            enemyAnimation.SetActive(true);
            // transform.LookAt(playerLocation);
            jscareSound.Play();
        }
            
            
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            // print("Player inside enemy range");
            isInDanger = false;
            isDamaging = false;
            enemyAnimation.SetActive(false);
            // if(gameManager.GetComponent<score>().playerHealth<100)
            // {
            //     gameManager.GetComponent<score>().playerHealth+=3;
            // }
            
        }
            
    }
    private IEnumerator coroutine;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerLocation);
        
        if(isInDanger && isDamaging && canBeDamaged)
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
            if(player.GetComponent<playerMovement>().isTorching == true && isDamaging)
            {
                gameManager.GetComponent<score>().playerHealth-=5;
            }
            else if(player.GetComponent<playerMovement>().isTorching == false && isDamaging)
            {
                gameManager.GetComponent<score>().playerHealth-=10;
            } 
            
            isInDanger=true;
    }
}

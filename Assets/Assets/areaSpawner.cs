using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaSpawner : MonoBehaviour
{
    public GameObject itemsToSpread;
    public int numItemsToSpread = 10;
    public float itemxSpread = 10;
    public float itemySpread = 0;
    public float itemzSpread = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<numItemsToSpread;i++)
        {
        spreadStuffs();
        }

    }

    void spreadStuffs()
    {
        
        Vector3 randPosition = new Vector3 (Random.Range(-itemxSpread, itemxSpread), Random.Range(-itemySpread, itemySpread), Random.Range(-itemzSpread, itemzSpread))+transform.position;
         GameObject clone = Instantiate(itemsToSpread, randPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

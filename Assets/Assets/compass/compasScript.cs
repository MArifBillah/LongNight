using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class compasScript : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;

    public GameObject iconPrefab;
    public static List<goalMarker> goalMarkers = new List<goalMarker>();

    float compassUnit;

    public int itemDestroyed;
    // contoh
    // public goalMarker one;

    // public float maxDistance = 5000f;
    // Start is called before the first frame update
    void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width/360f;
        // AddGoalMarker(one);
    }

    // Update is called once per frame
    void Update()
    {
        
        compassImage.uvRect = new Rect (player.localEulerAngles.y/360f, 0f, 1f, 1f);
        
        foreach(goalMarker marker in goalMarkers){
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
        
        }
        
    }

    public GameObject AddGoalMarker(goalMarker marker){
        GameObject newMarker= Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        goalMarkers.Add(marker);
        print("this is marker = "+marker);
        return newMarker;
    }

    public void reduceMarker(goalMarker marker)
    {
        goalMarkers.Remove(marker);
    }

    Vector2 GetPosOnCompass(goalMarker marker){
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
        return new Vector2(compassUnit*angle, 0f);
    }
}

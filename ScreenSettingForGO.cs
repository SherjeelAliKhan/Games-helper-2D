using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettingForGO : MonoBehaviour
{


    public GameObject[] GameObjects;

    void Update() {
        foreach (GameObject gO in GameObjects) {
            MaintainGOInScreen(gO);
        }    
    }

    // Maintain game object in fixed 2D screen 
    // if game object moves beyond screen edge 
    // by moving the game object from one edge to another edge.  
    void MaintainGOInScreen(GameObject gO) {

        Vector2 currentRes = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        Vector2 resolution = new Vector2(Screen.width, Screen.height);

        Vector2 minPosition = new Vector2(0, 0);
        Vector2 maxPosition = resolution;   // new Vector2(1024, 768);

        if (gO.transform.position.x >= maxPosition.x) { //Go beyond the limit of the screen from right side

            gO.transform.position = new Vector3(minPosition.x, gO.transform.position.y, 0);

        } else if (gO.transform.position.x <= minPosition.x) { //Go beyond the limit of the screen from left side

            gO.transform.position = new Vector3(maxPosition.x, gO.transform.position.y, 0);

        }

        if (gO.transform.position.y >= maxPosition.y) { //Go beyond the limit of the screen from top side

            gO.transform.position = new Vector3(gO.transform.position.x, minPosition.y, 0);

        } else if (gO.transform.position.y <= minPosition.y) { //Go beyond the limit of the screen from bottom side

            gO.transform.position = new Vector3(gO.transform.position.x, maxPosition.y, 0); ;

        }
    }
}

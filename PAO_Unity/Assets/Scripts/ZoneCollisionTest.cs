using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollisionTest : MonoBehaviour
{

    bool open = false;
    bool enter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");
        }
    }



    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "tag == player");
        }

        if (other.CompareTag("Player"))
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "CompareTag(player)");
        }

    Debug.Log("OnTriggerEnter OK");

    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) 
    { 
        if (collider.name == "Player")
        {
            // collider.GetComponent<CharacterMotor>().isCrouch = true;
            print("ENTRE");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
            // collider.GetComponent<CharacterMotor>().isCrouch = false;
            print("SORS");
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Player")
        {
            // collider.GetComponent<Animation>().Play("run");
            print("STAY");
        }
    }

}

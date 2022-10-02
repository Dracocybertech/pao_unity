using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{


    void OnTriggerEnter(Collider col) //passer en  paramètre le nom de la classe pour tester qu'il a bien un rigid body
    {
        if (col.name == "Player")
        {
            print("Joueur entr� dans la zone");

            col.GetComponent<Rigidbody>().velocity = new Vector3(0,10,0); //regarder addForce 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            print("Joueur sorti de la zone");
        }
    }
}

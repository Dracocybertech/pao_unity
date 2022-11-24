using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSight : MonoBehaviour
{

    GameObject leMonstre;

    Monster leMonstreIA;

    // Start is called before the first frame update
    void Start()
    {
        leMonstre = this.transform.parent.gameObject;
        leMonstreIA = leMonstre.GetComponent<Monster>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Joueur entré dans le fov du monstre");

            leMonstreIA.setVueJ();

        }

    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Joueur sorti du fov du monstre");

            leMonstreIA.setVueR();

            leMonstreIA.setDPJoueur();
        }
    }
}

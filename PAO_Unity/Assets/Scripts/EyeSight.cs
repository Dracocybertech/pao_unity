using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSight : MonoBehaviour
{
    GameObject lePlayer;

    GameObject leMonstre;

    Monster leMonstreIA;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        leMonstre = this.transform.parent.gameObject;
        leMonstreIA = leMonstre.GetComponent<Monster>();
        lePlayer = GameObject.Find("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.collider == lePlayer.GetComponent<CapsuleCollider>())
                Debug.Log("A détecté le joueur normalement");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            if (hit.collider == lePlayer.GetComponent<CapsuleCollider>())
                Debug.Log("A détecté le joueur via un rayon de sortie de map");
        }
    }

    // Activate the Main function when Player enter the trigger area
    /*void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Joueur entré dans le fov du monstre");

            leMonstreIA.setVueJ();

        }

    }*/



    void OnTriggerStay(Collider other)
    {
        if ((other.name == "Player") && (hit.collider == lePlayer.GetComponent<CapsuleCollider>()))//  (leMonstreIA.getEtat() != Etats.Etat.aPorteeDuJ))
        {
            Debug.Log("Joueur toujours dans dans le fov du monstre et non dans la range du coup");

            leMonstreIA.setVueJ();

            leMonstreIA.setDPJoueur();

        }

    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Joueur sorti du fov du monstre");

            leMonstreIA.setVueR();


        }
    }
}

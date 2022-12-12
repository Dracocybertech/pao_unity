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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.collider == lePlayer.GetComponent<CapsuleCollider>())
                Debug.Log("A détecté le joueur normalement");
        }
    }


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

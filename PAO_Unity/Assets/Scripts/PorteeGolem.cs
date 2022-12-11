using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteeGolem : MonoBehaviour
{


    GameObject leJoueur;

    Joueur leJoueurScr;

    GameObject leMonstre;

    Monster leMonstreIA;

    public bool testeurDegats;


    // Start is called before the first frame update
    void Start()
    {

        leMonstre = this.transform.parent.gameObject;
        leMonstreIA = leMonstre.GetComponent<Monster>();
        leJoueur = GameObject.Find("Player");
        leJoueurScr = leJoueur.GetComponent<Joueur>();
        
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
            //Debug.Log("Joueur entré dans la range de coup du monstre");

            leMonstreIA.setAPorteeDuJ();

            if (testeurDegats) //testeur de dégâts manuel
                leJoueurScr.estTouche();


        }

    }





    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            //Debug.Log("Joueur sorti de la range de coup du monstre");

            leMonstreIA.setAPorteeDuJ();
        }
    }


}

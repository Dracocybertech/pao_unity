using System.Collections;
using System.Collections.Generic;
using static Etats;
using UnityEngine;


public class gameMaster : MonoBehaviour
{

    Dictionary<string,int> recompenses = new Dictionary<string, int>(){
        {"seul",100},
        {"jBlesse", 25},
        {"aPorteeDuJ",10},
        {"suitJ",2},
        {"suitDP",1},
        {"voitR",-1}
    };

    public struct EtatsJoueur
    {

            public Vector3 position;
            public int ptDeVie;
            //public bool visible


    }

    public struct EtatsMonstre
    {

            public Vector3 position;
            public Etat etat;
            public bool visible;

    }

    EtatsMonstre EM = new EtatsMonstre();

    EtatsJoueur EJ = new EtatsJoueur();

    GameObject lePlayer = GameObject.Find("Player");

    GameObject leMonstre = GameObject.Find("PBR_Golem");

    Joueur lePlayerScript;

    Monster leMonstreScript;


    public gameMaster()
    {
        lePlayerScript = lePlayer.GetComponent<Joueur>();

        leMonstreScript = leMonstre.GetComponent<Monster>();
    }

    //Etats.Action action = null;

    //QTable = new Qtable; A compléter

    // Start is called before the first frame update
    void Start()
    {
        getEtats();

        //Etats.Action ordre = qtable(etat,récompense);

        //leMonstre.donnerOrdre(ordre);
        
    }

    // fixedUpdate is called once per frame
    void fixedUpdate()
    {

        //A chaque chgt d'etat quand il y a event et reping toutes les 10 secondes. Buter le joueur exprès au début de la game pour que la récompense soit obtenue.

        getEtats();

        //Action ordre = qtable(etat,récompense);

        //leMonstre.donnerOrdre(ordre);
        
    }


    void getEtats()
    {
        EJ.position = lePlayer.transform.position;
        EJ.ptDeVie = lePlayerScript.getHP();
        //EtatsJoueur.visible = lePlayer.getVisibilite();

        EM.position = leMonstre.transform.position;
        EM.etat = leMonstreScript.getEtat();
        EM.visible = leMonstreScript.getVisibilite();



    }

}

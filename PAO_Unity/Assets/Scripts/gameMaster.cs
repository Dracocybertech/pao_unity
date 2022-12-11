using System.Collections;
using System.Collections.Generic;
using static Etats;
using UnityEngine;
using UnityEngine.UI;



public class gameMaster : MonoBehaviour
{

    Dictionary<string,int> recompenses = new Dictionary<string, int>(){
        {"seul",100},
        {"jBlesse", 25},
        {"aPorteeDuJ",10},
        {"suitJ",5},
        {"voitj",2},
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

    EtatsMonstre EM;

    EtatsJoueur EJ;

    GameObject lePlayer;

    GameObject leMonstre;

    Joueur lePlayerScript;

    Monster leMonstreScript;

    bool gameOver;

    //Etats.Action action = null;

    //QTable = new Qtable; A compléter

    // Start is called before the first frame update
    void Start()
    {
        EM = new EtatsMonstre();

        EJ = new EtatsJoueur();

        lePlayer = GameObject.Find("Player");

        leMonstre = GameObject.Find("PBR_Golem");

        leMonstreScript = leMonstre.GetComponent<Monster>();

        lePlayerScript = lePlayer.GetComponent<Joueur>();

        getEtats();

        //Etats.Action ordre = qtable(EM.etat,recompense);

        //leMonstre.donnerOrdre(ordre);
    }

    // fixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            //A chaque chgt d'etat quand il y a event et reping toutes les 10 secondes. Buter le joueur exprès au début de la game pour que la récompense soit obtenue.

            getEtats();

            //Action ordre = qtable(etat,récompense);

            //leMonstre.donnerOrdre(ordre);

            int HPJoueur = lePlayerScript.getHP();

            if (HPJoueur == 0)
            {
                this.GameOver();
            }
        }
    }


    public void GameOver()
    {
        gameOver = true;
        //Debug.Log("GameOver triggered");
        GameObject.Find("GameOverScreen").GetComponent<RawImage>().enabled = true;
        lePlayer.GetComponent<CharacterController>().enabled = false;
        lePlayer.GetComponent<CharacterMotor>().enabled = false;
        Destroy(leMonstre);

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

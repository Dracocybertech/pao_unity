using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Etats;

public class Monster : MonoBehaviour
{

    public bool visible = true;

    Etats.Action ordre;


    [SerializeField] public Transform Target; //cible de l'ennemi
    [SerializeField] public UnityEngine.AI.NavMeshAgent agent; //zone bleu de déplacement

    // Start is called before the first frame update
    void Start()
    {
        //setVisibilite();
        //agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination=Target.position;
        //donnerOrdre(ordre);

    }

    void setVisibilite()
    {

        //GetComponent(MeshRenderer).enabled = visible;
        //visible = ! visible;

    }

    bool getVisibilite()
    {
        return this.visible;
    }

    /*void donnerOrdre(Etats.Action ordre)
    {
        switch (ordre)
        {
            case Etats.Action.frapper:
                frapper();
            case Etats.Action.suivre:
                suivre();
            case Etats.Action.attendre:
                attendre();
            case Etats.Action.ouvrir:
                ouvrir();
            case Etats.Action.avancer:
                avancer();
            case Etats.Action.demitour:
                demitour();
            case Etats.Action.tournerD:
                tournerD();
            case Etats.Action.tournerG:
                tournerG();
        }

    }*/


}

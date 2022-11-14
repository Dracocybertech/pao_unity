using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Etats;

public class Monster : MonoBehaviour
{

    public bool visible = true;
    public Etats.Etat etat;

    Etats.Action ordre = Etats.Action.attendre;


    [SerializeField] public Transform Target; //cible de l'ennemi
    [SerializeField] public UnityEngine.AI.NavMeshAgent agent; //zone bleu de déplacement

    // Start is called before the first frame update
    void Start()
    {
        //agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination=Target.position;
        donnerOrdre(ordre);

    }

    public void setVisibilite()
    {
        if (visible)
        {
            visible = ! visible;
            GetComponent<Renderer>().enabled = visible;
        }

        if (!visible)
        {
            visible = ! visible;
            GetComponent<Renderer>().enabled = visible;
        }


    }

    public Etats.Etat getEtat()
    {
        return this.etat;
    }

    void detection()
    {

    }

    void frapper()
    {

    }

    void suivre()
    {

    }

    void explorer()
    {

    }

    void attendre()
    {

    }

    public bool getVisibilite()
    {
        return this.visible;
    }

    public void donnerOrdre(Etats.Action ordre)
    {
        switch (ordre)
        {
            case Etats.Action.frapper:
                this.frapper();
                break;
            case Etats.Action.suivre:
               this.suivre();
               break;
            case Etats.Action.attendre:
                this.attendre();
                break;
            case Etats.Action.explorer:
                this.explorer();
                break;
            default:
                this.attendre();
                break;

        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Etats;

public class Monster : MonoBehaviour
{

    public bool visible = true;
    public Etats.Etat etat;

    Etats.Action ordre = Etats.Action.attendre;

    Vector3 DPCible;

    Renderer leRenderer;

    MeshCollider leCollider;

    [SerializeField] public Transform target; //cible de l'ennemi
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        leRenderer= GameObject.Find("RockGolemMesh").GetComponent<SkinnedMeshRenderer>(); // non prioritaire
        leCollider = GameObject.Find("RockGolemMesh").GetComponent<MeshCollider>();
        setVisibilite();
        //agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = target.position;
        donnerOrdre(ordre);

    }

    public void setVisibilite()
    {
        if (visible)
        {
            visible = ! visible;

            leRenderer.enabled = visible;
            leCollider.enabled = visible;
        }

        if (!visible)
        {
            visible = ! visible;
            leRenderer.enabled = visible;
            leCollider.enabled = visible;
        }


    }


    public void setVueJ()
    {
        this.etat = Etats.Etat.voitJ;

    }

    public void setVueR()
    {
         this.etat = Etats.Etat.voitR;

    }

    public void setDPJoueur()
    {

        this.DPCible = target.position;

    }

    public Etats.Etat getEtat()
    {
        return this.etat;
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

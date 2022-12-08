using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Etats;

public class Monster : MonoBehaviour
{

    public bool visible;
    public Etats.Etat etat;

    public Etats.Action ordre;

    GameObject leJoueur;

    Joueur leJoueurScr;

    Vector3 DPCible;

    Renderer leRenderer;

    MeshCollider leCollider;

    [SerializeField] public Transform target; //cible de l'ennemi
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("I'm attached to " + gameObject.name);
        //Debug.Log("Visible ?" + visible);

        agent = GetComponent<NavMeshAgent>();
        leJoueur = GameObject.Find("Player");
        leJoueurScr = leJoueur.GetComponent<Joueur>();
        leRenderer= GameObject.Find("RockGolemMesh").GetComponent<SkinnedMeshRenderer>(); // non prioritaire
        leCollider = GameObject.Find("RockGolemMesh").GetComponent<MeshCollider>();
        setVisibilite();


    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = target.position;
        donnerOrdre(ordre);

    }

    // Gestion de la visibilité

    public void setVisibilite()
    {
        visible = !visible;

        if (visible)
        {
            visible = ! visible;

            leRenderer.enabled = visible;
            leCollider.enabled = visible;

            Debug.Log("Renderer: " +leRenderer.enabled);
            Debug.Log("Collider: " +leCollider.enabled);
        } else
        {
            visible = ! visible;
            leRenderer.enabled = visible;
            leCollider.enabled = visible;

            Debug.Log("Renderer: " +leRenderer.enabled);
            Debug.Log("Collider: " +leCollider.enabled);


        }

    }

    public bool getVisibilite()
    {
        return this.visible;
    }


    //Getteur Setteur des Etats du monstre


    public void setAPorteeDuJ()
    {



        if (this.etat == Etats.Etat.aPorteeDuJ)
        {
            this.setVueJ();

        } else
        {

            this.etat = Etats.Etat.aPorteeDuJ;

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

    public void setjBlesse()
    {
        this.etat = Etats.Etat.jBlesse;

    }

    public void setjMort()
    {
        this.etat = Etats.Etat.seul;

    }

    public Etats.Etat getEtat()
    {
        return this.etat;
    }


    //Getteur Setteur de Déplacement


    public void setDPJoueur()
    {

        this.DPCible = target.position;

    }



    //Execution des ordres


    void frapper()
    {
        if (this.getEtat() == Etats.Etat.aPorteeDuJ)
        {

            leJoueurScr.estTouche();

            if(leJoueurScr.vivant())
            {
                this.setjBlesse();


            } else
            {

                this.setjMort();

            }

        }
    }

    void suivre()
    {
        this.target = GameObject.Find("Player").transform;
    }

    void explorer()
    {
        //nouvelleDest()
    }

    void attendre()
    {
        this.target = gameObject.transform;
    }


    public void donnerOrdre(Etats.Action ordre)
    {
        switch (ordre)
        {
            case Etats.Action.frapper:
                this.frapper();
                break;
            case Etats.Action.suivre:
                //Debug.Log("Ordre de suivre");
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

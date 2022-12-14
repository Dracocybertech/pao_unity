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

    public int timerVal;

    public int vitesseVoitJ;

    public int vitesseVoitR;

    int timer = 0;

    GameObject leJoueur;

    GameObject Waypoint;

    GameObject WaypointDPJ;

    GameObject ExploRange;

    Bounds borduresCercle;

    Joueur leJoueurScr;

    Renderer leRenderer;

    MeshCollider leCollider;

    [SerializeField] public Transform target; //cible de l'ennemi
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Waypoint = GameObject.Find("Waypoint");

        WaypointDPJ = GameObject.Find("WaypointDPJ");

        ExploRange = GameObject.Find("ExploRange");

        agent = GetComponent<NavMeshAgent>();
        leJoueur = GameObject.Find("Player");
        leJoueurScr = leJoueur.GetComponent<Joueur>();
        leRenderer= GameObject.Find("RockGolemMesh").GetComponent<SkinnedMeshRenderer>();
        leCollider = GameObject.Find("RockGolemMesh").GetComponent<MeshCollider>();
        setVisibilite();
    }


    void FixedUpdate()
    {

        //Donner la cible à l'Agent
        agent.destination = target.position;
        //Mettre à jour la vitesse en fct de l'état
        this.setSpeed();

        //Permet de bloquer le waypoint d'exploration
        if (timer == 0)
        {
            donnerOrdre(ordre);
        } else
        {
            timer = timer - 1;
        }
    }

    // Gestion de la visibilité afin de désactiver le MeshCollider et le Renderer qui affiche le monstre
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


    //Fixe la vitesse en fonction de si le monstre voit le joueur.
    public void setSpeed()
    {
        if (this.etat == Etats.Etat.voitJ)
            agent.speed = vitesseVoitJ;
        else
            agent.speed = vitesseVoitR;

    }

    // Fixer le waypoint de la dernière position du joueur sur le joueur, au moment où il quitte la vue du monstre.
    public void setDPJoueur()
    {
        WaypointDPJ.transform.position = leJoueur.transform.position;
    }

    //Déplace un waypoint d'exploration
    public void nouvelleDest()
    {
        Debug.Log("nouvelleDest triggered");
        this.randomWaypoint();
        this.target = Waypoint.transform;
    }

    //Cherche une localisation correcte pour le waypoint
    public void randomWaypoint()
    {
        borduresCercle = ExploRange.GetComponent<SphereCollider>().bounds;

        Waypoint.transform.position = this.randomVect3(borduresCercle);
    }

    //Génère des coordonnées dans les bordures du cercle.
    public Vector3 randomVect3(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            0,
            Random.Range(bounds.min.z, bounds.max.z)
        );
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
        if (this.etat == Etats.Etat.voitJ)
        {
            this.target = leJoueur.transform;
        } else
            this.target = WaypointDPJ.transform;
    }

    void explorer()
    {
        this.timer = timerVal;
        this.nouvelleDest();
    }

    void attendre()
    {
        this.timer = timerVal;
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

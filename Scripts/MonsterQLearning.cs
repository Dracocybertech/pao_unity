using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQLearning : MonoBehaviour
{
    [SerializeField] public FieldOfView FOVFront;
    [SerializeField] public FieldOfView FOVRight;
    [SerializeField] public FieldOfView FOVLeft;

    public float speed;
    [SerializeField] public Transform Target; //cible de l'ennemi
    [SerializeField] public UnityEngine.AI.NavMeshAgent agent; //zone bleu de déplacement

    public Etats etats;
    public int[] etat;
    public Actions action;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        //Récupérer le FoV du golem = récupérer l'état de chaque FoV et les stocker dans un tableau
        etat = new int[] {FOVLeft.getEtat(),FOVFront.getEtat(),FOVRight.getEtat()};
        /*print(etat[0]);
        print(etat[1]);
        print(etat[2]);
        print(etat.ToString());*/

        //Récupérer l'action correspondante
        action = etats.getAction(etat);
        print(action);

        //En fonction de l'action le golem agit 
        if(action.Equals("Continuer")){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(action.Equals("Droite")){
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(action.Equals("Gauche")){
            transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(action.Equals("Retourner")){
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(action.Equals("Suivre")){
            agent.destination=Target.position;
        }
        
    }
}

   
//private RaycastHit Hit;

/*transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //int alea = Random.Range(0, 10);
        //print(alea);
        //if (alea==1)
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 1))
        {
            print("Ici aussi");
            transform.Rotate(Vector3.up * Random.Range(90, 180) * Time.deltaTime);
        } */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] public Transform Target; //cible de l'ennemi
    [SerializeField] public UnityEngine.AI.NavMeshAgent agent; //zone bleu de déplacement

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination=Target.position;

    }
}

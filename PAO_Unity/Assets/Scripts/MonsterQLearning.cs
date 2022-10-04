using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQLearning : MonoBehaviour
{
    // [SerializeField] public FieldOfView FOVFront;
    // [SerializeField] public FieldOfView FOVRight;
    // [SerializeField] public FieldOfView FOVLeft;

    public float speed;

    private RaycastHit Hit;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //int alea = Random.Range(0, 10);
        //print(alea);
        //if (alea==1)
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 1))
        {
            print("Ici aussi");
            transform.Rotate(Vector3.up * Random.Range(90, 180) * Time.deltaTime);
        }
    }
}

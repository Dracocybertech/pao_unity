using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public string Obstacle;

    void OnTriggerEnter(Collider collider)
    {
        Obstacle = collider.tag;
        print(this.name+" "+Obstacle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public string Obstacle;
    public Etats etats;

    void Start()
    {
        this.Obstacle = "Rien";
    }

    private void OnTriggerStay(Collider collider)
    {
        print("Gilles");
        Obstacle = collider.tag;
        print(this.name+" "+Obstacle);
    }

    private void OnTriggerExit(Collider other) {
        Obstacle = "Rien";
    }

    public int getEtat(){
        return etats.EtatToInt(this.Obstacle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : Objet
{
    [SerializeField]
    public Clef clef;

    public override bool estRecuperable()
    {
        return false;
    }

    public override void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Player" && Input.GetKeyDown(KeyCode.E) && collider.GetComponent<CharacterMotor>().possedeObjet(this.clef))
        {
            this.GetComponent<Rigidbody>().isKinematic=false;
        }
    }
}

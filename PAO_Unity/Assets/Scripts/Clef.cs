using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clef : Objet
{
    public override bool estRecuperable()
    {
        return true;
    }

    public override void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collider.GetComponent<CharacterMotor>().ramasserObjet(this);
            gameObject.SetActive(false);
        }
    }
}

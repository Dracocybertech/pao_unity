using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterie : Objet
{
    // Start is called before the first frame update
    public override bool estRecuperable()
    {
        return true;
    }

    public override void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Player" && !collider.GetComponentInChildren<Flashlight>().isFull() && Input.GetKeyDown(KeyCode.E))
        {
            collider.GetComponentInChildren<Flashlight>().addCharge();
            gameObject.SetActive(false);
        }
    }
}

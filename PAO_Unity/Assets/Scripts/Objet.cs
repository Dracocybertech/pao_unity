using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objet : MonoBehaviour
{
    public abstract bool estRecuperable();

    public abstract void OnTriggerStay(Collider collider);

}

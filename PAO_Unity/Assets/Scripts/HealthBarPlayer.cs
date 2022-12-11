using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{

    GameObject leJoueur;

    GameObject Healthtext;

    // Start is called before the first frame update
    void Start()
    {
        leJoueur = this.transform.parent.gameObject;
        Healthtext = GameObject.Find("HealthText");
    }

    // Update is called once per frame
    void Update()
    {
        Healthtext.GetComponent<Text>().text = $"HP : {leJoueur.GetComponent<Joueur>().getHP()}";
    }
}

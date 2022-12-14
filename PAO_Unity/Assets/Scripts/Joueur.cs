using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joueur : MonoBehaviour
{

    public int pointDeVie;

    public bool visible = true;

    bool aEteTouche;

    int timer = 0;


    // Start is called before the first frame update
    void Start()
    {

        //setVisibilite();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (timer!=0)
            timer= timer-1;
        else
            aEteTouche = false;

    }

    // Activer la visibilité. Sera utile plus tard pour que le monstre ne puisse pas voir le joueur si besoin.
    public void setVisibilite()
    {
        if (visible)
        {
            visible = ! visible;
            GetComponent<Renderer>().enabled = visible;
        }

        if (!visible)
        {
            visible = ! visible;
            GetComponent<Renderer>().enabled = visible;
        }


    }

    //Getter setter des dégâts
    public int getHP()
    {
        return this.pointDeVie;
    }

    //Retire "coup" hp
    public void setDamage(int coup)
    {
        this.pointDeVie = this.pointDeVie - coup;
    }

    public bool getVisibilite()
    {
        return this.visible;
    }

    public bool vivant()
    {
        if (this.getHP()==0)
            return false;
        else
            return true;

    }

    //Permet de blesser le joueur et de créer une période d'invulnérabilité de 3 secondes.
    public void estTouche()
    {
        if (timer==0)
        {
            this.setDamage(1);
            this.aEteTouche = true;
            this.timer = 180;
        } else
        {
            Debug.Log("Période d'invulnérabilité");

        }


    }


    void OnGUI()
    {
        if (aEteTouche)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height - 65, 155, 30), "Vous avez pris un coup");

        }


    }

}

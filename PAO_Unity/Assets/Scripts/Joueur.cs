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

    public int getHP()
    {
        return this.pointDeVie;
    }

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

    public void estTouche()
    {
        this.setDamage(1);
        this.aEteTouche = true;
        this.timer = 180;

    }


    void OnGUI()
    {
        if (aEteTouche)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height - 65, 155, 30), "Vous avez pris un coup");

        }


    }

}

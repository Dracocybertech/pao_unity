using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{

    public int pointDeVie;

    public bool visible = true;


    // Start is called before the first frame update
    void Start()
    {
        //setVisibilite();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public bool getVisibilite()
    {
        return this.visible;
    }

}

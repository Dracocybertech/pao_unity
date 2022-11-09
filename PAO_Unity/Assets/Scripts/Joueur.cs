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

    void setVisibilite()
    {

        //GetComponent(MeshRenderer).enabled = visible;
        visible = ! visible;

    }

    int getHP()
    {
            return this.pointDeVie;
    }

    bool getVisibilite()
    {
        return this.visible;
    }

}

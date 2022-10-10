using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeCacher2 : MonoBehaviour
{
    // Le but de la fonction est de vérifier que le Joueur (collider)

    public Transform poseCamera; //on l'utilise comme position de référence. La manière d'en construire un dans unity c'est de créer un cube et de supprimer tous ses composants
    public Transform ancienTransform; // sauf le Transform où je mets les valeurs des caméras que j'ai déjà créées. Ca sert de support pour tp la main camera.

    public Vector3 positionAncienTransform;
    public Quaternion rotationAncienTransform;
    public UnityEngine.Camera camJoueur;
    public GameObject player; // dans un premier temps on le passe en dur et après on vérifiera via le collider que l'objet en collision l'a

    
    public bool peutSeCacher;
    public bool estCacher;

    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Joueur>() != null) // on vérifiera à la place que le script de type Joueur est dans le gameObject Player pour ne rendre l'action de se cacher possible que pour le joueur.
        {
            player = col.gameObject;
            peutSeCacher = true;
            //recupererTransform();
        }
    }

    /*private void recupererTransform(){
        this.camJoueur = player.GetComponentInChildren<Camera>();
        this.ancienTransform = camJoueur.transform;
        this.transformAvant =  this.ancienTransform.position;
    }*/

    private void seCacher()
    {
        //On se cache
        if(Input.GetKeyDown(KeyCode.R) && peutSeCacher && !estCacher)
        {
            //penser à sauvegarder l'ancien transform de la caméra avant tp pour la méthode sortirCachette
            this.camJoueur = player.GetComponentInChildren<Camera>();
            camJoueur.enabled = false;
            player.SetActive(false);

            this.camJoueur.transform.parent=null;
            
            this.ancienTransform = camJoueur.transform;
            this.positionAncienTransform =  this.ancienTransform.position;
            this.rotationAncienTransform =  this.ancienTransform.rotation;

            //this. camJoueur.transform.parent=this.poseCamera;
            camJoueur.transform.position = this.poseCamera.position;
            camJoueur.transform.rotation = this.poseCamera.rotation;
            camJoueur.enabled = true;

            estCacher = true;
        }

    }

     private void sortirCachette()
    {
        //Sortir de la cachette
        if(Input.GetKeyDown(KeyCode.A)&& peutSeCacher && estCacher)
        {
            
            this.camJoueur.enabled = false;
            camJoueur.transform.SetParent(player.transform);
            camJoueur.transform.position = this.positionAncienTransform;
            camJoueur.transform.rotation = this.rotationAncienTransform;
            
            player.SetActive(true);
            camJoueur.enabled = true;

            estCacher=false;
        }

    }
    
    private void Update()
    {
        seCacher();
        sortirCachette();
    }
    

    private void OnTriggerExit(Collider col)
    {
        if(col.name == "Player")
        {
            peutSeCacher = false;
        }
    }


}

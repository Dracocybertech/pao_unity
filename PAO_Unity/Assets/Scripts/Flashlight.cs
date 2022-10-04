using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    public LampeTorche lampe;

    [SerializeField]
    private float nbCharges;
    const float maxNbBatterie = 1; 

    //Pour gérer le niveau de batterie de ma lampe
    const float maxCharge = 50;
    const float baisseSuivante = 1; 
    [SerializeField]
    private float nivBatterie;
    private float baisseNivBatterie;

    //Propriété de la lampe
    private float intensité;

    //Affichage des batteries
    public Text affichage;
    

    //Accesseurs
    public float NbCharges
    {
        get { return this.nbCharges; }
        set { this.nbCharges=value;  }
    }

    public float NivBatterie
    {
        get { return this.nivBatterie; }
        set { this.nivBatterie = value; }
    }

    //Méthode Start
    void Start()
    {
        nbCharges = 0;
        nivBatterie = maxCharge;
        baisseNivBatterie = 0;
        intensité = GetComponent<Light>().intensity;
    }

    //Méthodes Updtate
    void Update()
    {
        //Gère l'allumage ou non de la lampe
        if (gameObject.transform.parent.GetComponent<CharacterMotor>().possedeObjet(lampe))
        {
            if (Input.GetKeyDown(KeyCode.F) && this.NivBatterie>0)
            {
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            }
        }

        //Gère le rechargement de la lampe
        if (Input.GetKeyDown(KeyCode.R) && this.NivBatterie < maxCharge && this.NbCharges>0)
        {
            this.rechargerBatterie();
            this.consumeCharge();
        }

        //Mise à jour du niveau de la batterie ; on décrémente toute les secondes si la lampe est allumée
        if (GetComponent<Light>().isActiveAndEnabled && Time.time>baisseNivBatterie && this.NivBatterie>0)
        {
            this.nivBatterie -= 1;
            this.baisseNivBatterie = Time.time + baisseSuivante;
        }

        //On met à jour l'état de la lampe
        this.etatLampe();

        //affichage des batteries
        affichage.GetComponent<Compteur>().afficherBatterie(this.NbCharges.ToString(), maxNbBatterie.ToString());
    }

    //Méthodes liées aux nombre de batteries disponibles
    public void addCharge()
    {
        this.nbCharges++;
    }

    private void consumeCharge()
    {
        this.nbCharges--;
    }

    public bool isFull()
    {
        return NbCharges == maxNbBatterie;
    }

    //Recharger le niveau de batterie
    private void rechargerBatterie()
    {
        this.NivBatterie = maxCharge;
    }

    //Etat de la lampe en focntion de la batterie
    private void etatLampe()
    {
        if (this.NivBatterie > maxCharge / 2)
        {
            GetComponent<Light>().intensity = intensité;
        }

        if (this.NivBatterie == maxCharge / 2)
        {
            GetComponent<Light>().intensity = intensité / 2; 
        }

        if (this.NivBatterie == maxCharge / 3)
        {
            GetComponent<Light>().intensity = intensité / 3;
        }

        if (this.NivBatterie == maxCharge / 4)
        {
            GetComponent<Light>().intensity = intensité / 4;
        }

        if (this.NivBatterie == 0)
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}

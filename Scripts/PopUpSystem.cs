using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public GameObject dialogBox;
    public string dialogFerme;
    public string dialogOuvert;

    public bool playerInRange;
    public bool playerHasKey;

    [SerializeField]
    public Objet objet;

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            playerInRange = true;
            if (col.GetComponent<CharacterMotor>().possedeObjet(objet))
            {
                playerHasKey = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.name == "Player")
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    private void affichageText()
    {
        if(Input.GetKeyDown(KeyCode.E)&& playerInRange && !playerHasKey)
        {
            if(dialogBox.activeSelf)
            {
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogBox.GetComponentInChildren<Text>().text = dialogFerme;
            }
        }
        if(Input.GetKeyDown(KeyCode.E)&& playerInRange && playerHasKey)
        {
            if(dialogBox.activeSelf)
            {
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogBox.GetComponentInChildren<Text>().text = dialogOuvert;
            }
        }
    }

    void Update()
    {

        affichageText();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compteur : MonoBehaviour
{
    public void afficherBatterie(string nbActuel, string nbMax)
    {
        GetComponent<Text>().text = $"Batterie : {nbActuel} / {nbMax}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Etat
{
   Obstacle, /*0*/
   Joueur, /*1*/
   Rien /*2*/
}

public enum Actions
{
   Continuer, 
   Droite, 
   Gauche, 
   Retourner,
   Suivre 
}

public class Etats : MonoBehaviour
{
    Dictionary<int[], Actions> dico = new Dictionary<int[], Actions>();

    private void Start()
   {
      dico.Add(new int[] {2,2,2}, Actions.Continuer);
      dico.Add(new int[] {2,0,2}, (Actions)UnityEngine.Random.Range(1,2));
      dico.Add(new int[] {2,2,0}, Actions.Gauche);
      dico.Add(new int[] {0,2,2}, Actions.Droite);
      dico.Add(new int[] {0,0,2}, Actions.Droite);
      dico.Add(new int[] {0,2,0}, Actions.Continuer);
      dico.Add(new int[] {2,0,0}, Actions.Gauche);
      dico.Add(new int[] {0,0,0}, Actions.Retourner);
      
      dico.Add(new int[] {1,2,2}, Actions.Suivre);
      dico.Add(new int[] {2,1,2}, Actions.Suivre);
      dico.Add(new int[] {2,2,1}, Actions.Suivre);

      dico.Add(new int[] {1,0,0}, Actions.Suivre);
      dico.Add(new int[] {0,1,0}, Actions.Suivre);
      dico.Add(new int[] {0,0,1}, Actions.Suivre);

      dico.Add(new int[] {1,2,0}, Actions.Suivre);
      dico.Add(new int[] {1,0,2}, Actions.Suivre);
      dico.Add(new int[] {2,1,0}, Actions.Suivre);
      dico.Add(new int[] {0,1,2}, Actions.Suivre);
      dico.Add(new int[] {0,2,1}, Actions.Suivre);
      dico.Add(new int[] {2,0,1}, Actions.Suivre);
   }

   public int EtatToInt(string etat){
       switch(etat){
           case "Obstacle" : return 0;
           case "Joueur" : return 1;
           case "Rien" : return 2;
       }
       return -1;
   }

   public Actions getAction(int[] etat){
       return dico[etat];
   }
}


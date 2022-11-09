using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etats : MonoBehaviour
{
      public enum Etat
   {
      voitR,
      voitJ,
      jBlesse,
      voitP,
      suitJ,
      seCogne,
      aPorteeDuJ,
      aPorteeDeP,
      //Rajouter se cacher et virer des portes.
   };



   /*public enum Etat
   {
      Obstacle,
      Joueur,
      Rien
   }*/

   public enum Action
   {
      frapper,
      suivre, //très haut niveau
      attendre,
      ouvrir,
      avancer, //peut-être stupide donc mettre un point de passage
      demitour,
      tournerD,
      tournerG
   };


   //public enum Action
   //{
   //   Continuer, /*Tout droit*/ /*0*/
   //   Droite, /*1*/
   //   Gauche, /*2*/
   //   Retourner, /*3*/
   //   Suivre /*4*/
   //}


   /*public class Etats : MonoBehaviour
   {
      Dictionary<Etat[,,],Actions> dico = new Dictionary<Etat[,,], Actions>();

      private void Start()
      {
         dico.Add(new Etat[2,2,2], Actions.Continuer);
         dico.Add(new Etat[2,0,2], (Actions)Random.Range(1,2));
         dico.Add(new Etat[2,2,0], Actions.Gauche);
         dico.Add(new Etat[0,2,2], Actions.Droite);
         dico.Add(new Etat[0,0,2], Actions.Droite);
         dico.Add(new Etat[0,2,0], Actions.Continuer);
         dico.Add(new Etat[2,0,0], Actions.Gauche);
         dico.Add(new Etat[0,0,0], Actions.Retourner);

         dico.Add(new Etat[1,2,2], Actions.Suivre);
         dico.Add(new Etat[2,1,2], Actions.Suivre);
         dico.Add(new Etat[2,2,1], Actions.Suivre);

         dico.Add(new Etat[1,0,0], Actions.Suivre);
         dico.Add(new Etat[0,1,0], Actions.Suivre);
         dico.Add(new Etat[0,0,1], Actions.Suivre);

         dico.Add(new Etat[1,2,0], Actions.Suivre);
         dico.Add(new Etat[1,0,2], Actions.Suivre);
         dico.Add(new Etat[2,1,0], Actions.Suivre);
         dico.Add(new Etat[0,1,2], Actions.Suivre);
         dico.Add(new Etat[0,2,1], Actions.Suivre);
         dico.Add(new Etat[2,0,1], Actions.Suivre);

      }

   }
   */


}


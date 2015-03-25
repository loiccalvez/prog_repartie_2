using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPromotion.Business.BC
{
    public class BusinessEtudiant
    {
        public BusinessEtudiant() { }

        // Ajout Etudiant à la liste 
        public static void Ajout_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Entity.BC.Promotions v_listepromo;
            try
            {
                v_listepromo = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                v_listepromo = new Entity.BC.Promotions();
            }


            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in v_listepromo.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    Boolean v_existe = false;
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in p_promo.Liste_etudiant)
                    {
                        if (p_etu.Id == v_etu.Id)
                        {
                            v_existe = true;
                        }
                    }

                    if (v_existe == false)
                    {
                        v_promo.Liste_etudiant.Add(p_etu); // Ajout de l'étudiant dans la liste
                    }
                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo); // Sauvegarde du fichier
        }

        // Supprimer un étudiant
        public static void Supp_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions v_listepromo;
            try
            {
                v_listepromo = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                v_listepromo = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in v_listepromo.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in v_promo.Liste_etudiant)
                    {
                        if (p_etu.Id == v_etu.Id)
                        {
                            v_promo.Liste_etudiant.Remove(v_etu);
                            break;
                        }
                    }
                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo); // Sauvegarde du fichier xml + fermeture
        }

        // Modification Etudiant de la liste
        public static void Modif_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions v_listepromo;
            try
            {
                v_listepromo = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                v_listepromo = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in v_listepromo.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in v_promo.Liste_etudiant)
                    {
                        if (p_etu.Id == v_etu.Id)
                        {
                            v_promo.Liste_etudiant.Remove(v_etu); // supression de l'étudiant à modifier
                            v_promo.Liste_etudiant.Add(p_etu); // modif du nouvel étudiant
                            break;
                        }
                    }
                }
            }
            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo); // sauvegarde du fichier xml + fermeture
        }
    }
}

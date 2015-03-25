using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace GestionPromotion.Business.BC
{

    public class Business
    {

        public Business() { }


        public static void Initialisation()
        {
            //tests
            GestionPromotion.Data.BC.Serialisation.test_serial();

            //GestionPromotion.Entity.BC.Promotions v_liste = new Entity.BC.Promotions();
            //GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_liste);
        }

        // Fonction servant à retourner la liste des promotions
        public static GestionPromotion.Entity.BC.Promotions affiche()
        {
            try
            {
                return GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion();
            }
            catch (Exception)
            {
                return null;
            } 
        }

        // Ajout Etudiant à la liste 
        public static void Ajout_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Entity.BC.Promotions Promotions;
            try
            {
                Promotions = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                Promotions = new Entity.BC.Promotions();
            } 
            

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    Boolean v_existe = false;
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in p_promo.Liste_etudiant)
                    {
                        if (p_etu.Nom == v_etu.Nom)
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

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(Promotions); // Sauvegarde du fichier
        }

        // Ajout d'une promotion 
        public static void Ajout_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions;
            try
            {
                Promotions = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                Promotions = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            Boolean v_existe = false;
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    v_existe = true;
                }
            }

            if (v_existe == false)
            {
                Promotions.Liste_promotion.Add(p_promo); // Ajout d'une promotion
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(Promotions); // Sauvegarde du fichier xml
        }

        // Supprimer un étudiant
        public static void Supp_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions;
            try
            {
                Promotions = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                Promotions = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in v_promo.Liste_etudiant)
                    {
                        if (p_etu.Nom == v_etu.Nom)
                        {
                            v_promo.Liste_etudiant.Remove(p_etu);
                        }
                    }

                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(Promotions); // Sauvegarde du fichier xml + fermeture
        }

        // Supprimer Promotion
        public static void Supp_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions;
            try
            {
                Promotions = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                Promotions = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    Promotions.Liste_promotion.Remove(p_promo); // suppression de la promotion
                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(Promotions); // sauvegarde du fichier xml + fermeture

        }

        // Modification Etudiant de la liste
        public static void Modif_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions;
            try
            {
                Promotions = GestionPromotion.Data.BC.Deserialisation.deserialiser_promotion(); // Ouverture du fichier
            }
            catch (Exception)
            {
                Promotions = new Entity.BC.Promotions();
            }

            //Recherche de l'existance de la promotion
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    // Recherche de l'existance de l'etudiant
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in v_promo.Liste_etudiant)
                    {
                        if (p_etu.Nom == v_etu.Nom)
                        {
                            v_promo.Liste_etudiant.Remove(v_etu); // supression de l'étudiant à modifier
                            v_promo.Liste_etudiant.Add(p_etu); // modif du nouvel étudiant
                        }
                    }
                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(Promotions); // sauvegarde du fichier xml + fermeture
        }

    }
}

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
         static GestionPromotion.Data.BC.Serialisation m_serial; // variable pour les ouvertures du fichier xml
         static GestionPromotion.Data.BC.Deserialisation m_deserial; // variable pour la fermeture du fichier xml

        public Business() { }

        //Affichage de la promotion
        public GestionPromotion.Entity.BC.Promotions affiche()
        {
            return m_deserial.deserialiser_promotion(); // Retourne le fichier xml
        }

        // Ajout Etudiant à la liste 
        public static void Ajout_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion(); // Ouverture du fichier


            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
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

            m_serial.serialiser_promotion(Promotions); // Sauvegarde du fichier + fermeture
        }

        // Ajout d'une promotion 
        public static void Ajout_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion(); // Ouverture du fichier xml
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
            
            m_serial.serialiser_promotion(Promotions); // Sauvegarde du fichier xml + fermeture
        }

        // Supprimer un étudiant
        public static void Supp_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion(); // Ouverture du fichier

            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    foreach (GestionPromotion.Entity.BC.Etudiant v_etu in v_promo.Liste_etudiant)
                    {
                        if (p_etu.Nom == v_etu.Nom)
                        {
                            v_promo.Liste_etudiant.Remove(p_etu);
                        }
                    }

                }
            }

            m_serial.serialiser_promotion(Promotions); // Sauvegarde du fichier xml + fermeture
        }

        // Supprimer Promotion
        public static void Supp_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion(); // ouverture du fichier

            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    Promotions.Liste_promotion.Remove(p_promo); // suppression de la promotion
                }
            }

            m_serial.serialiser_promotion(Promotions); // sauvegarde du fichier xml + fermeture

        }

        // Modification Etudiant de la liste
        public static void Modif_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            // Ouverture du fichier
            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion();

            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
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

            m_serial.serialiser_promotion(Promotions); // sauvegarde du fichier xml + fermeture
        }

    }
}

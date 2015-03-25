using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPromotion.Business.BC
{
    public class BusinessPromotion
    {
        public BusinessPromotion() { }

        public static void Initialisation()
        {
            GestionPromotion.Entity.BC.Promotions v_listepromo = new Entity.BC.Promotions();
            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo);
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

        // Ajout d'une promotion 
        public static void Ajout_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
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
            Boolean v_existe = false;
            foreach (GestionPromotion.Entity.BC.Promotion v_promo in v_listepromo.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    v_existe = true;
                }
            }

            if (v_existe == false)
            {
                v_listepromo.Liste_promotion.Add(p_promo); // Ajout d'une promotion
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo); // Sauvegarde du fichier xml
        }

        // Supprimer Promotion
        public static void Supp_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
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
                    v_listepromo.Liste_promotion.Remove(v_promo); // suppression de la promotion
                    break;
                }
            }

            GestionPromotion.Data.BC.Serialisation.serialiser_promotion(v_listepromo); // sauvegarde du fichier xml + fermeture

        }
    }
}

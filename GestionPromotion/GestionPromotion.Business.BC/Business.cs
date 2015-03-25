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
         static XmlReader reader;
         static String filename = "promotion.xml";
         static GestionPromotion.Data.BC.Serialisation m_serial;
         static GestionPromotion.Data.BC.Deserialisation m_deserial;

        public Business() { }

        //Affichage de la promotion
        public GestionPromotion.Entity.BC.Promotions affiche()
        {
            return m_deserial.deserialiser_promotion();
        }

        // Init Sérialisation
        /*public void Init_Serialisation()
        {
            GestionPromotion.Data.BC.Serialisation Sr;

            try
            {
                Sr = new Data.BC.Serialisation();
                Sr.test_serial();
            }
            catch (Exception ee)
            {

                //ValidationEventHandler eventHandler = new ValidationEventHandler(XmlDocumentSample.ValidationCallback);

                try
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Parse;
                    settings.ValidationType = ValidationType.DTD;
                    //settings.ValidationEventHandler += eventHandler;

                    reader = XmlReader.Create(filename, settings);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    Console.WriteLine(doc.OuterXml);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
             }       
        
        }*/

        // Ajout Etudiant à la liste 
        public static void Ajout_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion();


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
                        v_promo.Liste_etudiant.Add(p_etu);
                    }
                }
            }

            m_serial.serialiser_promotion(Promotions);
        }

        // Ajout d'une promotion 
        public static void Ajout_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion();
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
                Promotions.Liste_promotion.Add(p_promo);
            }
            
            m_serial.serialiser_promotion(Promotions); 
        }

        // Supprimer un étudiant
        public static void Supp_Etudiant(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
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
                            v_promo.Liste_etudiant.Remove(p_etu);
                        }
                    }

                }
            }

            m_serial.serialiser_promotion(Promotions);
        }

        // Supprimer Promotion
        public static void Supp_Promo(GestionPromotion.Entity.BC.Promotion p_promo)
        {

            GestionPromotion.Entity.BC.Promotions Promotions = m_deserial.deserialiser_promotion();


            foreach (GestionPromotion.Entity.BC.Promotion v_promo in Promotions.Liste_promotion)
            {
                if (p_promo.Annee == v_promo.Annee)
                {
                    Promotions.Liste_promotion.Remove(p_promo);
                }
            }

            m_serial.serialiser_promotion(Promotions);

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
                            v_promo.Liste_etudiant.Remove(v_etu);
                            v_promo.Liste_etudiant.Add(p_etu);
                        }
                    }
                }
            }

            m_serial.serialiser_promotion(Promotions);
        }

    }
}

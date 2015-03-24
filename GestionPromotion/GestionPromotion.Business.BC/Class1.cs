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
        public void affiche(Entity.BC.Promotions p_promotions)
        {
            Entity.BC.Promotion[] m_tab_copy = new Entity.BC.Promotion[p_promotions.Liste_promotion.Count()];
            GestionPromotion.Data.BC.Serialisation Sr = new Data.BC.Serialisation();
            Sr.serialiser_promotion(p_promotions);
            p_promotions.Liste_promotion.CopyTo(m_tab_copy);
            for (int i = 0; i < p_promotions.Liste_promotion.Count(); i++)
                Console.WriteLine("{0}", m_tab_copy[i]);
        }

        // Init Sérialisation
        public void Init_Serialisation()
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
        
        }

        // Ajout Etudiant à la liste 
        public static void Ajout_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant, String nom_groupe)
        {

            m_deserial.deserialiser_promotion(); // Ouverture du fichier

            List<GestionPromotion.Entity.BC.Etudiant> L_ET1 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu1 = new Entity.BC.Etudiant(nom_etudiant, prenom_etudiant, date_etudiant);
            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions();
            L_ET1.Add(etu1);
            

            m_serial.serialiser_promotion(Promotions); // fermeture + sauvegarde
        }

        // Ajout d'une promotion 
        public static void Ajout_Promo(String nom_groupe, List<GestionPromotion.Entity.BC.Etudiant> L_Et)
        {
            m_deserial.deserialiser_promotion();

            GestionPromotion.Entity.BC.Promotion Promo1 = new Entity.BC.Promotion(nom_groupe, 2015, L_Et);
            List<GestionPromotion.Entity.BC.Promotion> L_PR = new List<Entity.BC.Promotion>();
            L_PR.Add(Promo1);

            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions(L_PR);

            // A garder, c'est l'appel à la fonction. La surchage sera à choisir par tes soins :=)
            GestionPromotion.Data.BC.Serialisation Sr = new Data.BC.Serialisation();
            //Sr.serialiser_promotion(Promotions, "C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2","promotions.xml"); // Lien Loïc
            Sr.serialiser_promotion(Promotions, "F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2", "promotions.xml"); // Lien Dylan

            m_serial.serialiser_promotion(Promotions); 
        }

        // Supprimer un étudiant
        public static void Supp_Etudiant(List<GestionPromotion.Entity.BC.Etudiant> L_Et, Entity.BC.Etudiant nom_etudiant, Entity.BC.Etudiant prenom_etudiant, Entity.BC.Etudiant date_etudiant)
        {

            m_deserial.deserialiser_promotion(); // Ouverture du fichier
            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions();
            try
            {
                L_Et.Remove(nom_etudiant);
                L_Et.Remove(prenom_etudiant);
                L_Et.Remove(date_etudiant);

            }
            catch
            {
                Console.WriteLine(" L'Etudiant : {0} {1} n'existe pas", nom_etudiant.Nom, prenom_etudiant.Prenom);
            }

            m_serial.serialiser_promotion(Promotions);
        }

        // Supprimer Promotion
        public GestionPromotion.Entity.BC.Promotions Supp_Promo()
        {

            m_deserial.deserialiser_promotion();
            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions();

            try
            {
                GestionPromotion.Data.BC.Deserialisation DSr = new Data.BC.Deserialisation();
                //return DSr.deserialiser_promotion("C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2"); // Lien Loïc
                return DSr.test_deserial();
            }
            catch
            {
                Console.WriteLine("Promotion inexistante");
                return null;
            }

            m_serial.serialiser_promotion(Promotions);
        }

        // Modification Etudiant de la liste
        public static void Modif_Etudiant(List<GestionPromotion.Entity.BC.Etudiant> L_Et, Entity.BC.Etudiant ancien_nom_etudiant, Entity.BC.Etudiant ancien_prenom_etudiant, Entity.BC.Etudiant ancien_date_etudiant, Entity.BC.Etudiant new_nom_etudiant, Entity.BC.Etudiant new_prenom_etudiant, Entity.BC.Etudiant new_date_etudiant)
        {
            try
            {
                ancien_nom_etudiant.Nom.Replace(ancien_nom_etudiant.Nom, new_nom_etudiant.Nom);
                ancien_prenom_etudiant.Prenom.Replace(ancien_prenom_etudiant.Prenom, new_prenom_etudiant.Prenom);
                ancien_date_etudiant.Date_de_naissance.Replace(ancien_date_etudiant.Date_de_naissance, new_date_etudiant.Date_de_naissance);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

    }
}

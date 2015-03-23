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
        /* private String m_nom_Etudiant;
         private String m_prenom_Etudiant;
         private String m_date_Etudiant;
         private String m_nom_groupe;*/
         static XmlReader reader;
         static String filename = "promotion.xml";
        
        public Business() { }

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
        public void Ajout_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant, String nom_groupe)
        {
            List<GestionPromotion.Entity.BC.Etudiant> L_ET1 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu1 = new Entity.BC.Etudiant(nom_etudiant, prenom_etudiant, date_etudiant);
            L_ET1.Add(etu1);


        }

        // Ajout d'une promotion 
        public void Ajout_Promo(String nom_groupe, List<GestionPromotion.Entity.BC.Etudiant> L_Et)
        {
            GestionPromotion.Entity.BC.Promotion Promo1 = new Entity.BC.Promotion(nom_groupe, 2015, L_Et);
            List<GestionPromotion.Entity.BC.Promotion> L_PR = new List<Entity.BC.Promotion>();
            L_PR.Add(Promo1);

            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions(L_PR);

            // A garder, c'est l'appel à la fonction. La surchage sera à choisir par tes soins :=)
            GestionPromotion.Data.BC.Serialisation Sr = new Data.BC.Serialisation();
            //Sr.serialiser_promotion(Promotions, "C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2","promotions.xml"); // Lien Loïc
            Sr.serialiser_promotion(Promotions, "F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2", "promotions.xml"); // Lien Dylan
        }

        // Supprimer un étudiant
        public void Supp_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant)
        {
            StreamReader sr;
            StreamWriter sw = null;
            String str;
            String Del;
            String soluce;
           

            sr = promotions.xml;
            sw = File.AppendText("temp_promotions.xml");

            // tentative d'ouverture du fichier
            try
            {
                sr = new StreamReader("promotions.xml");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            str = sr.ReadLine();
            string[] eclate = str.Split(new Char[] { ' ', ' ', '\n', '\t' });

            if (eclate[1] == nom_etudiant && eclate[2] == prenom_etudiant && eclate[3] == date_etudiant)
            {
                soluce = nom_etudiant + prenom_etudiant + date_etudiant;

                while (str != null)
                {
                    Del = str;
                    str = sr.ReadLine();

                    if (Del != soluce)
                    {
                        sw.WriteLine(Del);
                    }

                }
                sr.Close();
                sw.Close();
                File.Delete("promotions.xml");
                File.Move("temp_promotions.xml", "promotions.xml");

            }
            else
                Console.WriteLine("L'étudiant : {0} {1} n'existe pas", nom_etudiant, prenom_etudiant);
                sr.Close();
        }

        // Supprimer une promotion
        public void Supp_Promotion(String nom_promotion,Int16 annee_promotion)
        {
            StreamReader sr;
            StreamWriter sw = null;
            String str;
            String Del;
            String soluce;


            sr = "promotions.xml";
            sw = File.AppendText("temp_promotions.xml");

            // tentative d'ouverture du fichier
            try
            {
                sr = new StreamReader("promotions.xml");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            str = sr.ReadLine();
            string[] eclate = str.Split(new Char[] { ' ', ' ', '\n', '\t' });

            if (eclate[5] == nom_promotion && Int16.Parse(eclate[6]) == annee_promotion)
            {
                soluce = nom_promotion + annee_promotion;

                while (str != null)
                {
                    Del = str;
                    str = sr.ReadLine();

                    if (Del != soluce)
                    {
                        sw.WriteLine(Del);
                    }

                }

                sr.Close();
                sw.Close();
                File.Delete("promotions.xml");
                File.Move("temp_promotions.xml", "promotions.xml");

            }
            else
            {
                Console.WriteLine("La promotion : {0} {1} n'existe pas", nom_promotion, annee_promotion);
                sr.Close();
            }
        }

        // Modification Etudiant de la liste
        public void Modif_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant, String nom_groupe, String nom_promotion, Int16 annee_promotion)
        {
            //GestionPromotion.Data.BC.Serialisation verif = new Data.BC.Serialisation();
            // verif.serialiser_promotion(p_promotions, "F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2", "promotions.xml"); // lien à changer
            StreamReader sr;
            StreamWriter sw = null;
            String str;
            String Modif;
            String soluce;

            sr = "promotions.xml";
            sw = File.AppendText("temp_promotions.xml");

            // tentative d'ouverture du fichier
            try
            {
                sr = new StreamReader("promotions.xml");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            str = sr.ReadLine();
            string[] eclate = str.Split(new Char[] { ' ', ' ', '\n', '\t' });

            if (eclate[1] == nom_etudiant && eclate[2] == prenom_etudiant && eclate[3] == date_etudiant && eclate[4] == nom_groupe && eclate[5] == nom_promotion && Int16.Parse(eclate[6]) == annee_promotion)
            {
                soluce = nom_promotion + annee_promotion;

                while (str != null)
                {
                    Modif = str;
                    str = sr.ReadLine();

                    if (Modif != soluce)
                    {
                        sw.WriteLine(Modif);
                    }
                    else if (Modif == soluce)
                    {

                    }

                }

                sr.Close();
                sw.Close();
                File.Delete("promotions.xml");
                File.Move("temp_promotions.xml", "promotions.xml");

            }
            else
            {
                Console.WriteLine("La promotion : {0} {1} n'existe pas", nom_etudiant, prenom_etudiant);
                sr.Close();
            }

        }



        // Deserialiser 
        public GestionPromotion.Entity.BC.Promotions Supp_Promo()
        {
            GestionPromotion.Data.BC.Deserialisation DSr = new Data.BC.Deserialisation();
            //return DSr.deserialiser_promotion("C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2"); // Lien Loïc
            return DSr.deserialiser_promotion("F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2"); // Lien Dylan
        }
    }
}

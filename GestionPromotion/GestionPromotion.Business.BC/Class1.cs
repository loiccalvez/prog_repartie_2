using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestionPromotion.Business.BC
{

    public class Business
    {
        /* private String m_nom_Etudiant;
         private String m_prenom_Etudiant;
         private String m_date_Etudiant;
         private String m_nom_groupe;*/

        public Business() { }

        // Init Sérialisation
        public void Init_Serialisation()
        {
            GestionPromotion.Data.BC.Serialisation Sr = new Data.BC.Serialisation();
            Sr.test_serial();
        }

        // Ajout Etudiant à la liste 
        public void Ajout_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant, String nom_groupe)
        {
            List<GestionPromotion.Entity.BC.Etudiant> L_ET1 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu1 = new Entity.BC.Etudiant(nom_etudiant, prenom_etudiant, date_etudiant);
            L_ET1.Add(etu1);


        }
        // Modification Etudiant de la liste
        public void Modif_Etudiant(String nom_etudiant, String prenom_etudiant, String date_etudiant, String nom_groupe, String nom_promotion, Int16 annee_promotion)
        {
            //GestionPromotion.Data.BC.Serialisation verif = new Data.BC.Serialisation();
            // verif.serialiser_promotion(p_promotions, "F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2", "promotions.xml"); // lien à changer
            StreamReader sr;
            String str;

            sr = "promotions.xml";

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

            if (eclate[1] == prenom_etudiant)
            {
                prenom_etudiant = eclate[1];
            }
            if (eclate[2] == nom_etudiant)
            {
                nom_etudiant = eclate[2];
            }
            if (eclate[3] == date_etudiant)
            {
                date_etudiant = eclate[3];
            }
            if (eclate[4] == nom_groupe)
            {
                nom_groupe = eclate[4];
            }
            if (eclate[5] == nom_promotion)
            {
                nom_promotion = eclate[5];
            }
            if (Int16.Parse(eclate[6]) == annee_promotion)
            {
                annee_promotion = Int16.Parse(eclate[6]);
            }

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

        // Supprimer une promotion 
        public GestionPromotion.Entity.BC.Promotions Supp_Promo()
        {
            GestionPromotion.Data.BC.Deserialisation DSr = new Data.BC.Deserialisation();
            //return DSr.deserialiser_promotion("C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2"); // Lien Loïc
            return DSr.deserialiser_promotion("F://Users//DYLAN//Documents//C# projet//Git//Prog//prog_repartie_2"); // Lien Dylan
        }
    }
}

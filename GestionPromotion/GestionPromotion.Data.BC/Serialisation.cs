using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace GestionPromotion.Data.BC
{
    public class Serialisation
    {
        // Constructeur par défaut. Pas d'attribut dans la classe
        public Serialisation() { }

        // Méthodes de la classes
        // Fonction de serialistion avec chemin et avec nom de fichier
        public void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions, String p_chemin_dacces, String p_nom_fichier)
        {
            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotions));
            try
            {
                using (StreamWriter wr = new StreamWriter(p_chemin_dacces + "//" + p_nom_fichier))
                {
                    xs.Serialize(wr, p_promotions );
                }
            }
            catch (Exception ee)
            { }
        }

        // Fonction de sérialisation avec chemin et sans nom de fichier donc avec promotions.xml
        public void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions, String p_chemin_dacces)
        {
            serialiser_promotion(p_promotions, p_chemin_dacces, "promotions.xml");
        }

        // Fonction de sérialisation sans chemin, donc avec C:/TP et sans nom de fichier donc avec promotions.xml
        public void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions)
        {
            serialiser_promotion(p_promotions, "C://TP", "promotions.xml");
        }

        // Fonction de test. A garder pour le moment -- Loïc
        public void test_serial()
        {
            List<GestionPromotion.Entity.BC.Etudiant> L_ET1 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu1 = new Entity.BC.Etudiant("Dylan", "Lecomte", "03/05/1994");
            GestionPromotion.Entity.BC.Etudiant etu2 = new Entity.BC.Etudiant("Raphael", "Debray", "03/05/1996");
            GestionPromotion.Entity.BC.Etudiant etu3 = new Entity.BC.Etudiant("Loïc", "Calvez", "12/04/1995");
            L_ET1.Add(etu1);
            L_ET1.Add(etu2);
            L_ET1.Add(etu3);
            GestionPromotion.Entity.BC.Promotion Promo1 = new Entity.BC.Promotion("Groupe1", 2015, L_ET1);

            List<GestionPromotion.Entity.BC.Etudiant> L_ET2 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu4 = new Entity.BC.Etudiant("Clément", "Palluel", "06/12/1995");
            GestionPromotion.Entity.BC.Etudiant etu5 = new Entity.BC.Etudiant("Thibaut", "Monet", "23/10/1995");
            GestionPromotion.Entity.BC.Etudiant etu6 = new Entity.BC.Etudiant("Duncan", "Billiet", "19/02/1995");
            L_ET2.Add(etu4);
            L_ET2.Add(etu5);
            L_ET2.Add(etu6);
            GestionPromotion.Entity.BC.Promotion Promo2 = new Entity.BC.Promotion("Groupe 2", 2015, L_ET2);

            List<GestionPromotion.Entity.BC.Etudiant> L_ET3 = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu7 = new Entity.BC.Etudiant("Antoine", "Lefevre", "16/10/1995");
            GestionPromotion.Entity.BC.Etudiant etu8 = new Entity.BC.Etudiant("Jonathan", "Loquet", "29/07/1995");
            GestionPromotion.Entity.BC.Etudiant etu9 = new Entity.BC.Etudiant("Rémi", "Ramet", "01/01/1995");
            L_ET3.Add(etu7);
            L_ET3.Add(etu8);
            L_ET3.Add(etu9);
            GestionPromotion.Entity.BC.Promotion Promo3 = new Entity.BC.Promotion("Groupe 3", 2015, L_ET3);

            List<GestionPromotion.Entity.BC.Promotion> L_PR = new List<Entity.BC.Promotion>();
            L_PR.Add(Promo1);
            L_PR.Add(Promo2);
            L_PR.Add(Promo3);

            GestionPromotion.Entity.BC.Promotions Promotions = new Entity.BC.Promotions(L_PR); 

            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotions));
            using (StreamWriter wr = new StreamWriter("promo.xml"))
            {
                xs.Serialize(wr, Promotions);
            }
        }

    }
}

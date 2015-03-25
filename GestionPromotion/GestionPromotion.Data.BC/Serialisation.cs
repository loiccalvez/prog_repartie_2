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
        public static void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions, String p_chemin_dacces, String p_nom_fichier)
        {
            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotions));
            try
            {
                using (StreamWriter wr = new StreamWriter(p_chemin_dacces + "//" + p_nom_fichier))
                {
                    xs.Serialize(wr, p_promotions );
                }
            }
            catch (Exception)
            { }
        }

        // Fonction de sérialisation avec chemin et sans nom de fichier donc avec promotions.xml
        public static void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions, String p_chemin_dacces)
        {
            serialiser_promotion(p_promotions, p_chemin_dacces, "promotions.xml");
        }

        // Fonction de sérialisation sans chemin, donc avec C:/TP et sans nom de fichier donc avec promotions.xml
        public static void serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions)
        {
            serialiser_promotion(p_promotions, "C://TP", "promotions.xml");
        }

    }
}

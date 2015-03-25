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
    public class Deserialisation
    {
        // Constructeur par défaut. Pas d'attribut dans la classe
        public Deserialisation() { }

        // Méthodes de la classe
        // Fonction de déserialisation avec chemin et avec nom de fichier
        public static GestionPromotion.Entity.BC.Promotions deserialiser_promotion(String p_chemin, String p_nom_fichier)
        {
            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotions));
            using (StreamReader rd = new StreamReader(p_chemin + "//" + p_nom_fichier))
            {
                GestionPromotion.Entity.BC.Promotions promotions = xs.Deserialize(rd) as Entity.BC.Promotions;
                return promotions;
            }
        }
        
        // Fonction de deserialisatin avec chemin et sans nom de fichier, donc avec promotions.xml
        public static GestionPromotion.Entity.BC.Promotions deserialiser_promotion(String p_chemin)
        {
            return deserialiser_promotion(p_chemin, "promotions.xml");
        }
        
        // Fonction de désérialisation sans chemin, donc avec C:/TP et sans nom de fichier, donc avec promotions.xml
        public static GestionPromotion.Entity.BC.Promotions deserialiser_promotion()
        {
            return deserialiser_promotion("C://TP", "promotions.xml");
        }

        // Fonction de test. A garder pour le moment -- Loïc C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2
        public static GestionPromotion.Entity.BC.Promotions test_deserial()
        {
            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotions));
            using (StreamReader rd = new StreamReader("C://Users//Loïc//Documents//GestionPromotion//prog_repartie_2//promotions.xml"))
            {
                GestionPromotion.Entity.BC.Promotions promotions = xs.Deserialize(rd) as Entity.BC.Promotions;
                return promotions;
            }
        }
    }
}

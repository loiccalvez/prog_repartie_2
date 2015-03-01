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
        public Serialisation()
        {      

        }

        public void test_serial()
        {
            List<GestionPromotion.Entity.BC.Etudiant> L_ET = new List<Entity.BC.Etudiant>();
            GestionPromotion.Entity.BC.Etudiant etu1 = new Entity.BC.Etudiant("Dylan", "Lecomte", "03/05/1994");
            GestionPromotion.Entity.BC.Etudiant etu2 = new Entity.BC.Etudiant("Raphael", "Debray", "03/05/1996");
            GestionPromotion.Entity.BC.Etudiant etu3 = new Entity.BC.Etudiant("Loïc", "CALVEZ", "12/04/1995");
            L_ET.Add(etu1);
            L_ET.Add(etu2);
            L_ET.Add(etu3);
            GestionPromotion.Entity.BC.Promotion Promo = new Entity.BC.Promotion("PE B", 2015, L_ET);

            XmlSerializer xs = new XmlSerializer(typeof(GestionPromotion.Entity.BC.Promotion));
            using (StreamWriter wr = new StreamWriter("promo.xml"))
            {
                xs.Serialize(wr, Promo);
            }

        }

    }
}

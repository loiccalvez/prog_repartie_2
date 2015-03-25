using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionPromotion.Entity.BC
{
    public class Promotions
    {
        // Variables de la classe
        private List<Promotion> m_liste_promotion;

        // Getter/Setter de la classe
        [XmlElement("Promotion")]
        public List<Promotion> Liste_promotion
        {
            get { return m_liste_promotion; }
            set { m_liste_promotion = value; }
        }

        // Constructeurs
        // Constructeur par défaut. Nécessaire à la sérialisation
        public Promotions() 
        {
            this.m_liste_promotion = new List<Promotion>();
        }
        // Constructeur 1 : prenant une liste de promotion en paramètre
        public Promotions(List<Promotion> p_liste_promotion)
        {
            this.m_liste_promotion = p_liste_promotion;
        }

    }
}

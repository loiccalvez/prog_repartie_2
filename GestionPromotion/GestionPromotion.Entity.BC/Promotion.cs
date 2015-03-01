using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPromotion.Entity.BC
{
    public class Promotion
    {
        // Variables de la classe Promotion
        private String m_nom;
        private Int16 m_annee;
        private List<Etudiant> m_liste_etudiant;

        // Getter/Setter
        public String Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }
        public Int16 Annee
        {
            get { return m_annee; }
            set { m_annee = value; }
        }
        public List<Etudiant> Liste_etudiant
        {
            get { return m_liste_etudiant; }
            set { m_liste_etudiant = value; }
        }

        // Constructeurs
        // Contructeur 0 par défaut. Nécessaire à la sérialisation
        public Promotion()
        {
            this.m_liste_etudiant = new List<Etudiant>();
        }
        // Constructeur 1 : tous les paramètres sont passés
        public Promotion(String p_nom, Int16 p_annee, List<Etudiant> p_liste_etudiant)
        {
            if (p_nom != null)
                this.m_nom = p_nom;
            this.m_annee = p_annee;
            this.m_liste_etudiant = p_liste_etudiant;
        }
        // Constructeur 2 : il n'y a pas encore d'étudiant dans la liste
        public Promotion(String p_nom, Int16 p_annee)
        {
            if (p_nom != null)
                this.m_nom = p_nom;
            this.m_annee = p_annee;
            this.m_liste_etudiant = null;
        }

        // Méthodes de la classe Etudiant
        // ICI
    }
}

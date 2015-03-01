using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPromotion.Entity.BC
{
    class Etudiant
    {
        // Variables de la classe Etudiant
        private String m_prenom;
        private String m_nom;
        private String m_date_de_naissance;

        // Getter/Setter
        public String Prenom
        {
            get { return m_prenom; }
            set { m_prenom = value; }
        }
        public String Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }
        public String Date_de_naissance
        {
            get { return m_date_de_naissance; }
            set { m_date_de_naissance = value; }
        }

        // Constructeur : tous les paramètres doivent être passés.
        public Etudiant(String p_prenom, String p_nom, String p_date_de_naissance)
        {
            if((p_prenom != null) && (p_nom != null) && (p_date_de_naissance != null))
            {
                this.m_prenom = p_prenom;
                this.m_nom = p_nom;
                this.m_date_de_naissance = p_date_de_naissance;
            }
        }

        // Méthodes de la classe Etudiant
        // ICI
    }
}

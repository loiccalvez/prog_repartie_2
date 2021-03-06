﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPromotion.Entity.BC
{
    public class Etudiant
    {
        // Variables de la classe Etudiant
        private String m_prenom;
        private String m_nom;
        private String m_date_de_naissance;
        private int m_id;
        private static int m_nbr_etud = 0;

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
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public static int Nbr_etud
        {
            get { return Etudiant.m_nbr_etud; }
            set { Etudiant.m_nbr_etud = value; }
        }

        // Constructeurs
        // Constructeur par défaut. Nécessaire à la sérialisatio
        public Etudiant()
        {
            m_nbr_etud += 1;
            this.m_id = m_nbr_etud;
        }
        // Constructeur 1 : tous les paramètres doivent être passés.
        public Etudiant(String p_prenom, String p_nom, String p_date_de_naissance)
        {
            if((p_prenom != null) && (p_nom != null) && (p_date_de_naissance != null))
            {
                m_nbr_etud += 1;
                this.m_prenom = p_prenom;
                this.m_nom = p_nom;
                this.m_date_de_naissance = p_date_de_naissance;
                this.m_id = m_nbr_etud;
            }
        }
    }
}

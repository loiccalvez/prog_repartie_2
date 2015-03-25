using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace GestionPromotion.Presentation.WS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Initialisation();

        [OperationContract]
        GestionPromotion.Entity.BC.Promotions GetListePromotions();

        [OperationContract]
        void AjouterPromo(GestionPromotion.Entity.BC.Promotion p_promo);

        [OperationContract]
        void SupprimerPromo(GestionPromotion.Entity.BC.Promotion p_promo);

        [OperationContract]
        void AjouterEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo);

        [OperationContract]
        void SupprimerEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo);

        [OperationContract]
        void ModifierEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo);
    }

    // Utilisez un contrat de données (comme illustré dans l'exemple ci-dessous) pour ajouter des types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "GestionPromotion.Presentation.WS.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    [DataContract]
    public class Etudiant
    {
        // Variables de la classe Etudiant
        private String m_prenom;
        private String m_nom;
        private String m_date_de_naissance;

        // Getter/Setter
        [DataMember]
        public String Prenom
        {
            get { return m_prenom; }
            set { m_prenom = value; }
        }
        [DataMember]
        public String Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }
        [DataMember]
        public String Date_de_naissance
        {
            get { return m_date_de_naissance; }
            set { m_date_de_naissance = value; }
        }

    }


    [DataContract]
    public class Promotion
    {
        // Variables de la classe Promotion
        private String m_nom;
        private Int16 m_annee;
        private List<Etudiant> m_liste_etudiant;

        // Getter/Setter
        [DataMember]
        public String Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }
        [DataMember]
        public Int16 Annee
        {
            get { return m_annee; }
            set { m_annee = value; }
        }
        [DataMember]
        [XmlElement("Etudiant")]
        public List<Etudiant> Liste_etudiant
        {
            get { return m_liste_etudiant; }
            set { m_liste_etudiant = value; }
        }

    }

    [DataContract]
    public class Promotions
    {
        // Variables de la classe
        private List<Promotion> m_liste_promotion;

        // Getter/Setter de la classe
        [DataMember]
        [XmlElement("Promotion")]
        public List<Promotion> Liste_promotion
        {
            get { return m_liste_promotion; }
            set { m_liste_promotion = value; }
        }

    }

}

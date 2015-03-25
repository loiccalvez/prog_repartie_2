using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionPromotion.Presentation.WS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ServiceGestionPromotion : IService1
    {

        public void Initialisation()
        {
            GestionPromotion.Business.BC.BusinessPromotion.Initialisation();
        }

        public GestionPromotion.Entity.BC.Promotions GetListePromotions()
        {
            return GestionPromotion.Business.BC.BusinessPromotion.affiche();
        }

        public void AjouterPromo(GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.BusinessPromotion.Ajout_Promo(p_promo);
        }

        public void SupprimerPromo(GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.BusinessPromotion.Supp_Promo(p_promo);
        }

        public void AjouterEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.BusinessEtudiant.Ajout_Etudiant(p_etu,p_promo);
        }

        public void SupprimerEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.BusinessEtudiant.Supp_Etudiant(p_etu, p_promo);
        }

        public void ModifierEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.BusinessEtudiant.Modif_Etudiant(p_etu, p_promo);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionPromotion.Presentation.WS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {

        public void Initialisation()
        {
            GestionPromotion.Business.BC.Business.Initialisation();
        }

        public GestionPromotion.Entity.BC.Promotions GetListePromotions()
        {
            return GestionPromotion.Business.BC.Business.affiche();
        }

        public void AjouterPromo(GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.Business.Ajout_Promo(p_promo);
        }

        public void SupprimerPromo(GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.Business.Supp_Promo(p_promo);
        }

        public void AjouterEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.Business.Ajout_Etudiant(p_etu,p_promo);
        }

        public void SupprimerEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.Business.Supp_Etudiant(p_etu, p_promo);
        }

        public void ModifierEtu(GestionPromotion.Entity.BC.Etudiant p_etu, GestionPromotion.Entity.BC.Promotion p_promo)
        {
            GestionPromotion.Business.BC.Business.Modif_Etudiant(p_etu, p_promo);
        }

    }
}

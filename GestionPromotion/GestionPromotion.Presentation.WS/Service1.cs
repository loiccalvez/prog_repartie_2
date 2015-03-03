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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        // Fonctions temporaires -- Loïc
        public void tempo_test_1()
        {
            GestionPromotion.Business.BC.Class1 Cl = new Business.BC.Class1();
            Cl.tempo_test_1_1();
        }

        public void tempo_test_2()
        {
            GestionPromotion.Business.BC.Class1 Cl = new Business.BC.Class1();
            Cl.tempo_test_2_1();
        }

        public int tempo_test_3()
        {
            GestionPromotion.Business.BC.Class1 Cl = new Business.BC.Class1();
            return Cl.tempo_test_3_1();
        }
    }
}

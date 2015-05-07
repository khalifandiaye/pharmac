using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_CreerUtilisateur : IWorkflow
    {
        private STR_MSG oMsg;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {
            // TODO vérification du niveau d'autorisation ?
            object[] data = new object[] { "sysdba", "mdpDBA" }; // données du compte sysDBA
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, ""); // pour la connexion


            STR_MSG execution = CL_DATA_ACCES.Connect(msg); // Connexion avec sysDBA

            if (execution.Info.Substring(0, 6) == "Erreur")
            {
                this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "Erreur", "", "", true, "");
                return this.oMsg;
            }

            map = new CL_MAP();
            execution = map.CreateUser(oMsg);


            data = new object[] { "sysdba", (string)execution.Data[0] };
            msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");

            CL_DATA_ACCES.ExecuteAndReturn(msg); // lancement de la requete

            // Deconnexion du compte sysDBA
            CL_DATA_ACCES.Disconnect(msg);

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "Création Réussie", "", "", true, "");

            return this.oMsg;
        }
    }
}

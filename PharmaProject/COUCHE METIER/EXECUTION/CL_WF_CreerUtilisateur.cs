using Oracle.DataAccess.Client;
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
            object[] data = new object[] { "PHARMAWEB", "Azerty64" }; // données du compte sys
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, ""); // pour la connexion


            STR_MSG execution = CL_DATA_ACCES.Connect(msg); // Connexion avec sys

            if (execution.Info != "OK")
            {
                this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "Erreur", "", "", true, "");
                return this.oMsg;
            }

            map = new CL_MAP();
            execution = map.CreateUser(oMsg);


            data = new object[] { "PHARMAWEB", (OracleCommand)execution.Data[0] };
            msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");

            STR_MSG retour = CL_DATA_ACCES.Execute(msg); // lancement de la requete

            // Deconnexion du compte sys
            CL_DATA_ACCES.Disconnect(msg);

            if (retour.Info != "OK")
            {
                this.oMsg = retour;
            }
            else
            {
                this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "OK", "", "", true, "");
            }
            

            return this.oMsg;
        }
    }
}

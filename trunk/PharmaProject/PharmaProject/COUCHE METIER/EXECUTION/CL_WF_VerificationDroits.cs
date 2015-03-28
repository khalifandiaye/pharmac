using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_VerificationDroits : IWorkflow
    {
        private STR_MSG oMsg;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {

            object[] data = new object[] { "C##PHARMAWEB", "PHARMA00" }; // données du compte faible
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, ""); // pour la connexion avec le compte faible

            // Connect avec le compte faible
            STR_MSG verif = CL_DATA_ACCES.Connect(msg);

            // exécute la vérification des droits (map)
            // ExecuteAndReturn
            map = new CL_MAP();
            verif = map.VerifDroits(oMsg); // on récupère la requete formatée

            data = new object[] { "C##PHARMAWEB", (OracleCommand)verif.Data[0] };
            msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");

            this.oMsg = CL_DATA_ACCES.ExecuteAndReturn(msg); // lancement de la requete


            // Créer un objet data et le remplir avec la réponse de la procédure
            DataSet ds = (DataSet)this.oMsg.Data[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                string value = (string)ds.Tables[0].Rows[0].ItemArray.GetValue(0);
                this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { value }, "", "", "", true, "");
            }
            else
            {
                this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { "Utilisateur Inexistant" }, "", "", "", true, "");
            }
            



            


            // Deconnexion du compte faible
            CL_DATA_ACCES.Disconnect(msg);


            // renvoyer le résultat
            return this.oMsg;
        }
    }
}

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


            // exécute la vérification des droits (map)
            // ExecuteAndReturn
            map = new CL_MAP();
            STR_MSG verif = map.VerifDroits(oMsg); // on récupère la requete formatée

            object[] data = new object[] { oMsg.Data[0], (OracleCommand)verif.Data[0] };
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");

            this.oMsg = CL_DATA_ACCES.ExecuteAndReturn(msg); // lancement de la requete






            // Créer un objet data et le remplir avec la réponse de la procédure
            DataSet ds = (DataSet)this.oMsg.Data[0];

            
            string value = (string)ds.Tables[0].Rows[0].ItemArray.GetValue(0); // on récupère le nom de son schéma, et donc, le nom de son type d'utilisateur
            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { value }, "", "", "", true, "");
            
            

            // renvoyer le résultat
            return this.oMsg;
        }
    }
}

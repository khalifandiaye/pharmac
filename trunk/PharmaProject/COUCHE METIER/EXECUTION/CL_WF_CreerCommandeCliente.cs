using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_CreerCommandeCliente : IWorkflow
    {
        private STR_MSG iMsg;
        private CL_MAP map;

        public STR_MSG exec(STR_MSG oMsg)
        {
            map = new CL_MAP();

            //char status = (char)oMsg.Data[0];
            //char prescription = (char)oMsg.Data[1];
            //char hasRead = (char)oMsg.Data[2];
            //int patientID = (int)oMsg.Data[3];
            STR_MSG retour = map.CreerCommandeCliente(oMsg);

            object[] data = new object[] { oMsg.Data[0], retour.Data[0] }; // le nom de l'utilisateur + la commande 
            this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
            this.iMsg = CL_DATA_ACCES.ExecuteAndReturn(this.iMsg);

            // si la commande s'est créée correctement
            // on récupère l'ID de la commande
            if (this.iMsg.Info == "OK")
            {
                OracleParameterCollection ds = (OracleParameterCollection)this.iMsg.Data[0];
                int ID_COMMANDE = int.Parse(ds["id"].Value.ToString());
                data = new object[] { ID_COMMANDE };
                this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "OK", "", "", true, "");
            }

            return this.iMsg;

        }


    }
}

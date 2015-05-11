using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_RecupIDClient : IWorkflow
    {
        private STR_MSG iMsg;
        private CL_MAP map;

        public STR_MSG exec(STR_MSG oMsg)
        {
            map = new CL_MAP();
            STR_MSG retour = map.SelectClientFromName(oMsg);

            object[] data = new object[] { oMsg.Data[0], retour.Data[0] }; // le nom de l'utilisateur + la commande 
            this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
            this.iMsg = CL_DATA_ACCES.ExecuteAndReturn(this.iMsg);


            if (this.iMsg.Info == "OK")
            {
                DataSet ds = (DataSet)this.iMsg.Data[0];
                decimal id = (decimal)ds.Tables[0].Rows[0][0];
                //int ID_CLIENT = 1;
                int ID_CLIENT = (int)id;
                data = new object[] { ID_CLIENT };
                this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "OK", "", "", true, "");
            }


            return this.iMsg;


        }

    }
}

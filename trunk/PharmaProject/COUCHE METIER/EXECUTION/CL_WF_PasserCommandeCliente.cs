using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_PasserCommandeCliente : IWorkflow
    {

        private STR_MSG iMsg;
        private CL_MAP map;


        STR_MSG IWorkflow.exec(STR_MSG oMsg)
        {
            map = new CL_MAP();

            STR_MSG retour = map.RecordMedic(oMsg);
            object[] data = new object[] { oMsg.Data[0], retour.Data[0] }; // le nom de l'utilisateur + la commande 
            this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
            this.iMsg = CL_DATA_ACCES.Execute(this.iMsg);

            return this.iMsg;

        }
    }
}

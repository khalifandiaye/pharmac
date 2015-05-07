using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    public class CL_WF_ListerMedicaments : IWorkflow
    {

        private STR_MSG iMsg;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {
            // mappage
            map = new CL_MAP();

            STR_MSG retour = map.ListMedic(oMsg);

            object[] data = new object[] { retour.Data[0],oMsg.Data[0] }; // la commande + le nom de l'utilisateur

            this.iMsg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");

            this.iMsg = CL_DATA_ACCES.Execute(this.iMsg);

            return this.iMsg;
        }
    }
}

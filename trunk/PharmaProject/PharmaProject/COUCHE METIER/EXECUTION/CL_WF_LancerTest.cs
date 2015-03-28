using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_LancerTest : IWorkflow
    {

        private STR_MSG oMsg;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {

            // mappage
            map = new CL_MAP();

            //oMsg = map.Test(oMsg);

            //cad = new CL_DATA_ACCES();

            // execution
            this.oMsg = CL_DATA_ACCES.Execute(oMsg); //cad.Execute(oMsg);

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", this.oMsg.Data, this.oMsg.Info, "", "", true, "");

            
            // retour
            return this.oMsg;
        }
    }
}

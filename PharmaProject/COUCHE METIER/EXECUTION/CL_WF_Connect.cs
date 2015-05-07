using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_Connect : IWorkflow
    {
        private STR_MSG oMsg;

        public STR_MSG exec(STR_MSG oMsg)
        {
            this.oMsg = CL_DATA_ACCES.Connect(oMsg);
            return this.oMsg;
        }
    }
}

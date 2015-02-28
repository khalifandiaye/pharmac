using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_PROCESS_PHARMACIEN
    {

        private STR_MSG oMsg;
        CL_WORKFLOW workflow;

        public CL_PROCESS_PHARMACIEN()
        {
            workflow = new CL_WORKFLOW();
        }

        public STR_MSG Calcul(STR_MSG oMsg)
        {
            return this.oMsg = workflow.Redirect(oMsg);
        }

    }
}

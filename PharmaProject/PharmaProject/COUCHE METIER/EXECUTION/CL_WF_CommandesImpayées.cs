using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_CommandesImpayées : IWorkflow
    {
        private STR_MSG oMsg;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {
            map = new CL_MAP();
            STR_MSG req = map.UnpaidOrder(oMsg);

            object[] data = new object[] { (string)oMsg.Data[0], (string)req.Data[0] } ;

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
            this.oMsg = CL_DATA_ACCES.ExecuteAndReturn(msg);

            /*
             * if(((DataSet)this.oMsg.Data[0]).Rows.Count > 0)
             * {
             *      data = new object[] { ((DataSet)this.oMsg.Data[0]).Rows.Count } ;
             *      msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
             * }
             * else
             * {
             *      data = new object[] { 0 } ;
             *      msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
             * }
             * 
             * 
             * */

            return this.oMsg;

        }
    }
}

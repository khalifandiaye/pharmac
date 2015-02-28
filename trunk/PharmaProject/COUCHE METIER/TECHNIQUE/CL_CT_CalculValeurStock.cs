using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_CT_CalculValeurStock
    {

        private STR_MSG oMsg;

        public void Calcul(object o)
        {

            STR_MSG oMsg = (STR_MSG)o;

            double dCalcul;

            // DataSet ds = (DataSet)oMsg.Data[0];
            /*
             * foreach(Row r in ds)
             * {
             *      dCalcul += r[prix]*r[quantité];
             * }
             * 
             * object[] data = new object[] {dCalcul};
             * 
             * this.oMsg = CL_MESSAGEFactory.msg_factory("",data,"","","",true,"");
             * 
             * */

        }
        
    }
}

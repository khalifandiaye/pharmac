using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_WF_CalculsFinanciers : IWorkflow
    {
        private STR_MSG oMsg;
        private CL_CT_CalculValeurStock stock;
        private CL_CT_CalculFacturationDateDate factu;
        private CL_MAP map;


        public STR_MSG exec(STR_MSG oMsg)
        {
            map = new CL_MAP();
            STR_MSG req = map.ListStock(oMsg);

            object[] data = new object[] { (string)oMsg.Data[0], (string)req.Data[0] };

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
            this.oMsg = CL_DATA_ACCES.ExecuteAndReturn(msg);


            stock = new CL_CT_CalculValeurStock();
            Thread thr = new Thread(new ParameterizedThreadStart(stock.Calcul));

            factu = new CL_CT_CalculFacturationDateDate(); // a refaire
            Thread thr2 = new Thread(new ParameterizedThreadStart(factu.Calcul));


            {
                thr.Start();
                thr2.Start();


            }

            return this.oMsg;

        }
    }
}

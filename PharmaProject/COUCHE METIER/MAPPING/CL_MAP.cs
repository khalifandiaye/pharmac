using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{

    /// <summary>
    /// Renvoie les requetes SQL
    /// </summary>

    class CL_MAP
    {

        private STR_MSG oMsg;
        private string rq_sql;


        public STR_MSG VerifDroits(STR_MSG oMsg)
        {

            
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "DBCONNECT";

            OracleParameter RV = new OracleParameter();
            RV.Direction = ParameterDirection.ReturnValue;
            RV.OracleDbType = OracleDbType.RefCursor;
            RV.ParameterName = "curs";
            //RV.Size = 255;

            cmd.Parameters.Add(RV);

            cmd.Parameters.Add("login_name", OracleDbType.Varchar2, 255).Value = (string)oMsg.Data[0];
            //cmd.Parameters.Add("RV", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");


            return this.oMsg;
        }



        public STR_MSG CreateUser(STR_MSG oMsg)
        {

            string req = "execute CreateUser('" + (string)oMsg.Data[0] + "','" + 
                    (string)oMsg.Data[1] + "','" + (string)oMsg.Data[2] + "')";  
            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { req }, 
                                                            "", "", "", true, "");

            return this.oMsg;
        }

        public STR_MSG UnpaidOrder(STR_MSG oMsg)
        {

            string req = "execute ListerCommandesImpayees2Mois('" + (string)oMsg.Data[0] + "')"; // TODO Unpaid Order
            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { req }, "", "", "", true, "");

            return this.oMsg;

        }

        public STR_MSG ListStock(STR_MSG oMsg)
        {

            string req = "execute ListerStock()"; // TODO Unpaid Order
            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { req }, "", "", "", true, "");

            return this.oMsg;

        }


    }
}

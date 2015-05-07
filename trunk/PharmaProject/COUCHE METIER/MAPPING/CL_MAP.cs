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
            RV.Direction = ParameterDirection.ReturnValue; // indique si c'est un paramètre entrant, ou de retour
            RV.OracleDbType = OracleDbType.RefCursor;
            RV.ParameterName = "curs";
            //RV.Size = 255;

            cmd.Parameters.Add(RV);

            cmd.Parameters.Add("login_name", OracleDbType.Varchar2, 255).Value = (string)oMsg.Data[0];

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");


            return this.oMsg;
        }



        public STR_MSG CreateUser(STR_MSG oMsg)
        {
            string nomUtilisateur = (string)oMsg.Data[0];
            string mdp = (string)oMsg.Data[1];
            string role = (string)oMsg.Data[2];


            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "CREATE_USER";

            cmd.Parameters.Add("login_name", OracleDbType.Varchar2, 255).Value = nomUtilisateur;
            cmd.Parameters.Add("mdp", OracleDbType.Varchar2, 255).Value = mdp;
            cmd.Parameters.Add("role", OracleDbType.Varchar2, 255).Value = role;

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");

            return this.oMsg;

        }

        public STR_MSG UnpaidOrder(STR_MSG oMsg)
        {


            return this.oMsg;

        }

        public STR_MSG ListStock(STR_MSG oMsg)
        {


            return this.oMsg;

        }

        public STR_MSG ListMedic(STR_MSG oMsg)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "LIST_MEDIC";

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");
            
            return this.oMsg;

        }


    }
}

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


        public STR_MSG VerifDroits(STR_MSG oMsg)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "PHARMAWEB.fn_getuserprofile";

            OracleParameter RV = new OracleParameter();
            RV.Direction = ParameterDirection.ReturnValue; // indique si c'est un paramètre entrant, ou de retour
            RV.OracleDbType = OracleDbType.RefCursor;
            RV.ParameterName = "curs";
            //RV.Size = 255;

            cmd.Parameters.Add(RV);
            cmd.Parameters.Add("user_name", OracleDbType.Varchar2, 255).Value = (string)oMsg.Data[0];

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");


            return this.oMsg;
        }


        public STR_MSG CreateUser(STR_MSG oMsg)
        {
            string nom = (string)oMsg.Data[0];
            string prenom = (string)oMsg.Data[1];
            string adresse = (string)oMsg.Data[2];
            DateTime DOB = (DateTime)oMsg.Data[3]; // date of birth
            string telFixe = (string)oMsg.Data[4];
            string telPortable = (string)oMsg.Data[5];
            string mail = (string)oMsg.Data[6];
            string numeroSecuSociale = (string)oMsg.Data[7];
            string mutuelle = (string)oMsg.Data[8];
            string loginUtilisateur = (string)oMsg.Data[9];
            string mdp = (string)oMsg.Data[10];


            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "pc_createuser";
            cmd.Parameters.Add("nom", OracleDbType.Varchar2, 255).Value = nom;
            cmd.Parameters.Add("prenom", OracleDbType.Varchar2, 255).Value = prenom;
            cmd.Parameters.Add("adresse", OracleDbType.Varchar2, 255).Value = adresse;
            cmd.Parameters.Add("DOB", OracleDbType.Date).Value = DOB;
            cmd.Parameters.Add("telFixe", OracleDbType.Varchar2, 255).Value = telFixe;
            cmd.Parameters.Add("telPortable", OracleDbType.Varchar2, 255).Value = telPortable;
            cmd.Parameters.Add("mail", OracleDbType.Varchar2, 255).Value = mail;
            cmd.Parameters.Add("numeroSecuSociale", OracleDbType.Varchar2, 255).Value = numeroSecuSociale;
            cmd.Parameters.Add("mutuelle", OracleDbType.Varchar2, 255).Value = mutuelle;
            cmd.Parameters.Add("loginUtilisateur", OracleDbType.Varchar2, 255).Value = loginUtilisateur;
            cmd.Parameters.Add("password", OracleDbType.Varchar2, 255).Value = mdp;
            cmd.Parameters.Add("profile", OracleDbType.Varchar2, 255).Value = "CLIENT";


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

            cmd.CommandText = "PHARMAWEB.get_medicaments";


            OracleParameter RV = new OracleParameter();
            RV.Direction = ParameterDirection.ReturnValue; // indique si c'est un paramètre entrant, ou de retour
            RV.OracleDbType = OracleDbType.RefCursor;
            RV.ParameterName = "curs";

            cmd.Parameters.Add(RV);



            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");
            
            return this.oMsg;

        }

        public STR_MSG SelectClientFromName(STR_MSG oMsg)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PHARMAWEB.SELECT_PATIENT_FROM_NAME";

            OracleParameter RV = new OracleParameter();
            RV.Direction = ParameterDirection.ReturnValue; // indique si c'est un paramètre entrant, ou de retour
            RV.OracleDbType = OracleDbType.RefCursor;
            RV.ParameterName = "curs";

            cmd.Parameters.Add(RV);
            cmd.Parameters.Add("username", OracleDbType.Varchar2, 255).Value = (string)oMsg.Data[0];

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");

            return this.oMsg;

        }

        /// <summary>
        /// Créé la commande. Ne permet pas le remplissage des médicaments.
        /// </summary>
        /// <param name="oMsg"></param>
        /// <returns></returns>
        public STR_MSG CreerCommandeCliente(STR_MSG oMsg)
        {

            char status = '1'; // commande OK
            char prescription = '0'; // commande sans prescription
            char hasRead = '1'; //
            int prescription_id = 1;
            int patientID = (int)oMsg.Data[1];

            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PHARMAWEB.Create_Commande";

            OracleParameter RV = new OracleParameter();
            RV.Direction = ParameterDirection.ReturnValue; // indique si c'est un paramètre entrant, ou de retour
            RV.OracleDbType = OracleDbType.Int32;
            RV.ParameterName = "id";

            cmd.Parameters.Add(RV);
            
            cmd.Parameters.Add("statut", OracleDbType.Char).Value = status;
            cmd.Parameters.Add("prescription", OracleDbType.Char).Value = prescription;
            cmd.Parameters.Add("hasRead", OracleDbType.Char).Value = hasRead;
            cmd.Parameters.Add("prescription_id", OracleDbType.Int32, 255).Value = prescription_id;
            cmd.Parameters.Add("patientID", OracleDbType.Int32, 255).Value = patientID;

            

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");

            return this.oMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg">oMsg.Data[1] = ID_MEDIC</param>
        /// <returns></returns>
        public STR_MSG RecordMedic(STR_MSG oMsg)
        {
            char isReserved = '1';
            int quantity = 1;
            int ID_Medic = 3;
            int ID_Commande = (int)oMsg.Data[2];

            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PHARMAWEB.record_commande_client";
            cmd.Parameters.Add("isreserved0", OracleDbType.Char).Value = isReserved;
            cmd.Parameters.Add("quantity0", OracleDbType.Int32, 255).Value = quantity;
            cmd.Parameters.Add("idM", OracleDbType.Int32, 255).Value = ID_Medic;
            cmd.Parameters.Add("idOrder", OracleDbType.Int32, 255).Value = ID_Commande;

            this.oMsg = CL_MESSAGE_Factory.msg_factory("", new object[] { cmd }, "", "", "", true, "");

            return this.oMsg;
        }

        //public STR_MSG RecordMedicOrdonnance(STR_MSG oMsg)
        //{

        //}

    }
}

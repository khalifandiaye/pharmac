using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data; 

namespace PharmaProject
{

    /// <summary>   
    /// COUCHE D'ACCÈS AUX DONNÉES
    /// </summary>


    static public class CL_DATA_ACCES
    {

        // Pas sécurisé
        // on peut récupérer la connexion string
        static Dictionary<string, OracleConnection> connexions = new Dictionary<string, OracleConnection>();
        private static int NB_MAX_CONNECTION = 150;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg">Data[0] = le nom d'utilisateur ; Data[1] = la requete</param>
        /// <returns></returns>
        static public STR_MSG Execute(STR_MSG oMsg)
        {
            
            string exec = (string)oMsg.Data[1]; // la requete
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            try
            {
                OracleCommand oCommand = new OracleCommand(exec, connexions[(string)oMsg.Data[0]]);

                oCommand.ExecuteNonQuery();

                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "OK", "", "", true, "");
            }
            catch(Exception e)
            {
                Disconnected(oMsg);
                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Reconnexion", "", "", true, "");
            }

            

            return msg;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg">Data[0] = le nom d'utilisateur ; Data[1] = la requete</param>
        /// <returns></returns>
        static public STR_MSG ExecuteAndReturn(STR_MSG oMsg)
        {

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            
                try
                {
                    // Créer un objet pour lancer la requete
                    OracleCommand oCommand = (OracleCommand)oMsg.Data[1];
                    oCommand.Connection = GetConnexion((string)oMsg.Data[0]);

                    oCommand.ExecuteNonQuery();

                    OracleDataAdapter da = new OracleDataAdapter(oCommand);
                    

                    // créer un objet pour récupérer le résultat
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // mettre le résultat dans un objet[]
                    object[] data = new object[] { ds };

                    msg = CL_MESSAGE_Factory.msg_factory("", data, "OK", "", "", true, "");
                }
                catch(Exception e)
                {
                    Disconnected(oMsg);
                    msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Reconnexion", "", "", true, "");
                }


            return msg;

        }




        //===================================================
        //===================================================
        //===================================================
        //===================================================
        //===================================================


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg">Data[0] doit contenir le nom d'utilisateur -- Data[1] doit contenir le mot de passe</param>
        /// <returns></returns>
        static public STR_MSG Connect(STR_MSG oMsg)
        {

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            // vérification du nombre de connexion
            if (connexions.Count >= NB_MAX_CONNECTION)
            {
                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Trop de connexions existantes", "", "", true, "");
            }
            else
            {


                //string connexionString = @"Data Source=PharmaProject;User Id=" + (string)oMsg.Data[0] + ";Password=" + (string)oMsg.Data[1] + ";";

                string connexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL = TCP)(HOST = 192.168.1.5)(PORT = 1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = ORCL)));User id=" + (string)oMsg.Data[0] + ";Password=" + (string)oMsg.Data[1];



                OracleConnection con = new OracleConnection(connexionString);

                try
                {
                    con.Open();
                    connexions.Add((string)oMsg.Data[0], con);

                    msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "L'utilisateur " + (string)oMsg.Data[0] + " est à présent connecté", "", "", true, "");
                }
                catch(Exception e)
                {
                    msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Erreur lors de la connexion : " + e.Message, "", "", true, "");
                }

            }


            return msg;
        }

        /// <summary>
        /// Supprime l'utilisateur de la liste des connexions
        /// </summary>
        /// <param name="oMsg">Data[0] doit contenir le nom</param>
        /// <returns></returns>
        static public STR_MSG Disconnected(STR_MSG oMsg)
        {

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            if (connexions.ContainsKey((string)oMsg.Data[0]))
            {
                try
                {
                    connexions[(string)oMsg.Data[0]].Close();
                    connexions.Remove((string)oMsg.Data[0]);
                }
                catch
                {
                    connexions.Remove((string)oMsg.Data[0]);
                }
                
            }

            msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Déconnecté", "", "", true, "");

            return msg;
        }

        //============================================================================
        //============================================================================
        //============================================================================
        //============================================================================

        static public OracleConnection GetConnexion(string name)
        {
            return connexions[name];
        }

    }


}

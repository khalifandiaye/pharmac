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

            OracleCommand exec = (OracleCommand)oMsg.Data[1]; // la requete
            string utilisateur = (string)oMsg.Data[0];
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            try
            {
                exec.Connection = connexions[utilisateur];

                exec.ExecuteNonQuery();

                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "OK", "", "", true, "");
            }
            catch(Exception e)
            {
                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Erreur : "+ e.Message, "", "", true, "");
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

            string nomUtilisateur = (string)oMsg.Data[0];
            OracleCommand command = (OracleCommand)oMsg.Data[1];

            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            
                try
                {
                    // Créer un objet pour lancer la requete
                    command.Connection = GetConnexion(nomUtilisateur);

                    command.ExecuteNonQuery();

                    OracleDataAdapter da = new OracleDataAdapter(command);
                    

                    // créer un objet pour récupérer le résultat
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // mettre le résultat dans un objet[]
                    if (ds.Tables.Count > 0)
                    {
                        object[] data = new object[] { ds };
                        msg = CL_MESSAGE_Factory.msg_factory("", data, "OK", "", "", true, "");
                    }
                    else
                    {
                        object[] data = new object[] { command.Parameters };
                        msg = CL_MESSAGE_Factory.msg_factory("", data, "OK", "", "", true, "");
                    }

                    
                }
                catch(Exception e)
                {
                    Disconnect(oMsg);
                    msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Erreur : " + e.Message, "", "", true, "");
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

            string username = (string)oMsg.Data[0];


            // vérification du nombre de connexion
            if (connexions.Count >= NB_MAX_CONNECTION && (string)oMsg.Data[0] != "sysdba")
            {
                msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "Trop de connexions existantes", "", "", true, "");
            }
            else
            {
                string connexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL = TCP)(HOST = 192.168.1.5)(PORT = 1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = pharmadb)));User id=" + username + ";Password=" + (string)oMsg.Data[1];

                OracleConnection con = new OracleConnection(connexionString);

                try
                {
                    con.Open();
                    connexions.Add(username, con);

                    msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "OK", "", "", true, "");
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
        static public STR_MSG Disconnect(STR_MSG oMsg)
        {
            string nomUtilisateur = (string)oMsg.Data[0];
            STR_MSG msg = CL_MESSAGE_Factory.msg_factory("", new object[] { }, "", "", "", true, "");

            if (connexions.ContainsKey(nomUtilisateur))
            {
                try
                {
                    connexions[nomUtilisateur].Close();
                    connexions.Remove(nomUtilisateur);
                }
                catch
                {
                    connexions.Remove(nomUtilisateur);
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

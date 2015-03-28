using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{

    public struct STR_MSG
    {
        public string App_Name; // nom de l'application
        public string Invoke; // méthode à appeler, demandé par l'utilisateur
        public string P_security; // clé de sécurité pour la partie Composant Serveur
        public bool Statut; // statut du message
        public string Info; // informations complémentaires du message
        public object[] Data; // données transitant entre les couches
        public string token; // niveau d'admninistration du message
    }


    /// <summary>   
    /// =================================
    /// COUCHE DE MESSAGES
    /// =================================
    /// </summary>


    static class CL_MESSAGE_Factory
    {


        static private STR_MSG oMsg;

        static public STR_MSG msg_factory(
        string App_name,
        object[] Data,
        string info,
        string Invoke,
        string P_security,
        bool statut,
        string token)
        {
            oMsg = new STR_MSG();
            oMsg.App_Name = App_name;
            oMsg.Data = Data;
            oMsg.Info = info;
            oMsg.Invoke = Invoke;
            oMsg.P_security = P_security;
            oMsg.Statut = statut;
            oMsg.token = token;
            return oMsg;
        }



    }
}

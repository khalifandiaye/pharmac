using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PharmaProject
{
    public class CL_WORK_COMPONENT
    {

        private CL_SERVER_COMPONENT servComp;
        private STR_MSG oMsg;
        private string ClientName;
        private string ClientID;
        private string Authentification;
        private string Token;

        public CL_WORK_COMPONENT()
        {
            this.ClientID = "@1234";
            this.ClientName = "PharmaProject_v1";
            this.Authentification = "";
            this.Token = "";

            servComp = new CL_SERVER_COMPONENT();
        }

        public void SetAuthentification(string a)
        {
            this.Authentification = a;
        }


        public STR_MSG AppelCommunication(string invoke, object[] data)
        {
            if (this.Authentification == "Fournisseur")
            {
                this.Token = "C##FOURNISSEUR";
            }
            else if (this.Authentification == "Pharmacien")
            {
                this.Token = "C##PHARMACIEN";
            }
            else if (this.Authentification == "Preparateur")
            {
                this.Token = "DEFAULT";
            }
            else // client
            {
                this.Token = "C##CLIENT";
            }

            this.oMsg = CL_MESSAGE_Factory.msg_factory(this.ClientName, data, "", invoke, 
                                                        this.ClientID, true, this.Token);
            this.oMsg = servComp.Service(this.oMsg);

            return this.oMsg;
        }

    }
}

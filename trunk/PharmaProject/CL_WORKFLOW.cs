using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PharmaProject
{


    /// <summary>   
    /// COUCHE MÉTIER (Workflow, Mappage, Composant Technique). Ce sont les services
    /// </summary>


    class CL_WORKFLOW
    {


        private STR_MSG oMsg;
        private IWorkflow work;


        public STR_MSG Redirect(STR_MSG oMsg)
        {
            if (oMsg.token == "Pharmacien")
            {
                // services pharmaciens
            }
            else if (oMsg.token == "Fournisseur")
            {
                // services Fournisseurs
            }
            else if (oMsg.token == "Preparateur")
            {
                // services préparateur
            }
            else
            {

            }



            // SERVICES GÉNÉRAUX
            
            // Connexion à la BDD
            if ((oMsg.Invoke == "Connexion") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                //// vérification des droits
                this.work = new CL_WF_VerificationDroits();
                this.oMsg = work.exec(oMsg);

                // Si la vérification est OK
                if ((string)this.oMsg.Data[0] == oMsg.token) 
                {
                    this.work = new CL_WF_Connect();
                    this.oMsg = work.exec(oMsg);
                }
                else if ((string)this.oMsg.Data[0] == "Utilisateur Inexistant")
                {
                    this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "Utilisateur Inexistant", "", "", true, "");
                }

                else
                {
                    this.oMsg = CL_MESSAGE_Factory.msg_factory("", null, "Mauvais droits", "", "", true, "");
                }

            }

            else if ((oMsg.Invoke == "CreerUtilisateur") && (oMsg.App_Name == "PharmaProject_v1"))
            {

                this.work = new CL_WF_CreerUtilisateur();
                this.oMsg = work.exec(oMsg);

            }




            return this.oMsg;
        }



    }
}

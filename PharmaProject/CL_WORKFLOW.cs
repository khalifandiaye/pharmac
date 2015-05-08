using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace PharmaProject
{


    /// <summary>   
    /// COUCHE MÉTIER (Workflow, Mappage, Composant Technique). Ce sont les services
    /// </summary>


    class CL_WORKFLOW
    {

        private STR_MSG iMsg;
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
                // services préparateurs
            }
            else
            {
                // services clients
            }


            // SERVICES GÉNÉRAUX

            // Connexion à la BDD
            #region Connexion BDD
            if ((oMsg.Invoke == "Connexion") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                
                this.work = new CL_WF_Connect();
                STR_MSG retourMsg = work.exec(oMsg);

                // si la connexion a bien réussie
                if (retourMsg.Info == "OK")
                {
                    // vérification des droits
                    this.work = new CL_WF_VerificationDroits();
                    retourMsg = work.exec(oMsg);

                    this.iMsg = CL_MESSAGE_Factory.msg_factory("", retourMsg.Data, "OK", "", "", true, ""); // on renvoit le type d'utilisateur 
                }
                else
                {
                    this.iMsg = CL_MESSAGE_Factory.msg_factory("", null, "Erreur lors de la connexion : " + retourMsg.Info, "", "", true, "");
                }
                

            }
            #endregion

            else if ((oMsg.Invoke == "CreerUtilisateur") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                this.work = new CL_WF_CreerUtilisateur();
                this.iMsg = work.exec(oMsg);
            }

            else if ((oMsg.Invoke == "ListerMedicaments") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                this.work = new CL_WF_ListerMedicaments();
                this.iMsg = work.exec(oMsg);
            }


            return this.iMsg;
        }



    }
}

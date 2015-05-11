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
                if ((oMsg.Invoke == "CommandeClient") && (oMsg.App_Name == "PharmaProject_v1"))
                {
                    
                    // 1) RecupIDCLient
                    this.work = new CL_WF_RecupIDClient();
                    STR_MSG requete = work.exec(oMsg);

                    if(requete.Info != "OK")
                    {
                        this.iMsg = CL_MESSAGE_Factory.msg_factory("", null, "Erreur lors de la connexion : " + requete.Info, "", "", true, "");
                    }
                    else
                    {
                        // 2) CreerCommandeCliente
                        int ID_CLIENT = (int)requete.Data[0];
                        this.work = new CL_WF_CreerCommandeCliente();

                        object[] data = new object[] { oMsg.Data[0], ID_CLIENT, oMsg.Data[1] }; // nom utilisateur + ID_CLIENT + Liste de Medics
                        requete = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
                        requete = this.work.exec(requete);

                        // on a récupéré l'ID de la commande, on peut remplir la commande
                        if (requete.Info == "OK")
                        {
                            // 3) PasserCommandeCliente
                            int ID_COMMANDE = (int)requete.Data[0];
                            this.work = new CL_WF_PasserCommandeCliente();
                            

                            List<string> ls = (List<string>)oMsg.Data[1];
                            foreach (string s in ls)
                            {
                                data = new object[] { oMsg.Data[0], s, ID_COMMANDE}; // nom utilisateur + nomMedic + ID_CLIENT
                                requete = CL_MESSAGE_Factory.msg_factory("", data, "", "", "", true, "");
                                STR_MSG retour = this.work.exec(requete);
                                if (retour.Info != "OK")
                                {
                                    break;
                                }
                                this.iMsg = retour;
                            }

                        }
                        
                    }

                }
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

            else if ((oMsg.Invoke == "createUser") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                this.work = new CL_WF_CreerUtilisateur();
                this.iMsg = work.exec(oMsg);
            }

            else if ((oMsg.Invoke == "ListerMedics") && (oMsg.App_Name == "PharmaProject_v1"))
            {
                this.work = new CL_WF_ListerMedicaments();
                this.iMsg = work.exec(oMsg);
            }


            return this.iMsg;
        }



    }
}

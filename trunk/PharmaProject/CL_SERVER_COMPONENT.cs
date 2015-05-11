using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    class CL_SERVER_COMPONENT
    {

        public STR_MSG iMsg;

        
        public void Service(object obj)
        {

            STR_MSG oMsg = (STR_MSG)obj;

            if (this.SecuriteAccesPlateforme(oMsg.P_security)) // si la clé de sécurité est OK
            {
                
                if (oMsg.Invoke == "Connexion")
                {
                    CL_PROCESS_CLIENT process = new CL_PROCESS_CLIENT();
                    this.iMsg = process.Connexion(oMsg);
                }
                else if (oMsg.Invoke == "createUser")
                {
                    CL_PROCESS_CLIENT process = new CL_PROCESS_CLIENT();
                    this.iMsg = process.CreerUtilisateur(oMsg);
                }

                else if (oMsg.Invoke == "PrevisionCA")
                {
                    CL_PROCESS_PHARMACIEN process = new CL_PROCESS_PHARMACIEN();
                    this.iMsg = process.Calcul(oMsg);
                }

                else if (oMsg.Invoke == "ListerMedics")
                {
                    CL_PROCESS_CLIENT process = new CL_PROCESS_CLIENT();
                    this.iMsg = process.ListerMedics(oMsg);
                }
                else if (oMsg.Invoke == "CommandeClient")
                {
                    CL_PROCESS_CLIENT process = new CL_PROCESS_CLIENT();
                    this.iMsg = process.PasserCommande(oMsg);
                }

            }

        }

        private bool SecuriteAccesPlateforme(string Cle)
        {
            bool valid;
            valid = false;
            if (Cle == "@1234")
            {
                valid = true;
            }
            return valid;
        }


    }
}

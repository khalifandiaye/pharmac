using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaProject
{
    public partial class Form1 : Form
    {
        string username;
        string token = "Client";
        CL_WORK_COMPONENT work;

        public Form1()
        {
            InitializeComponent();

           
            work = new CL_WORK_COMPONENT();
            work.SetAuthentification("Client");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Add_Client()
        {
            if (login.Text != "" && mdp1.Text != "" && mdp2.Text != "")
            {
                STR_MSG msg = work.AppelCommunication("createUser", new object[] { nom.Text, prenom.Text, adresse.Text, dob.Text, tfix.Text, tp.Text, mail.Text, nss.Text, mutuelle.Text, login.Text, mdp1.Text, mdp2.Text });

                if (msg.Info == "OK")
                {
                    Accueil acc = new Accueil();
                }
            }
        }
    }
}


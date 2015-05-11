using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaProject
{
    public partial class Accueil : Form
    {

        string token = "Client";
        CL_WORK_COMPONENT work;
        //Client cl;
        //Preparateur prep;

        public Accueil()
        {
            InitializeComponent();

            work = new CL_WORK_COMPONENT();
            work.SetAuthentification("Client");

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connexion();
        }


        private void Connexion()
        {
            if (nomTB.Text != "" && mdpTB.Text != "")
            {

                STR_MSG msg = work.AppelCommunication("Connexion", new object[] { nomTB.Text, mdpTB.Text });

                if (msg.Info == "OK")
                {

                    string role = (string)msg.Data[0];

                    // ouvre la fenetre correspondante
                    if (role == "CLIENT")
                    {
                        
                        Client cl = new Client(nomTB.Text);
                        cl.Text = "Espace Client - " + nomTB.Text;
                        cl.Show(this);

                        this.Visible = false;

                    }
                    else if (role == "PHARMACIEN")
                    {
                        Pharmacien ph = new Pharmacien(nomTB.Text);
                        ph.Text = "Espace Pharmacien - " + nomTB.Text;
                        ph.Show(this);

                        this.Visible = false;

                    }
                    else if (role == "FOURNISSEUR")
                    {
                        Fournisseur frni = new Fournisseur(nomTB.Text);
                        frni.Text = "Espace Fournisseur - " + nomTB.Text;
                        frni.Show(this);

                        this.Visible = false;

                    }
                    else if (role == "PREPARATEUR")
                    {

                        Preparateur prep = new Preparateur(nomTB.Text);
                        prep.Text = "Espace Préparateur - " + nomTB.Text;
                        prep.Show();

                        this.Visible = false;

                    }


                }
                else
                {
                    MessageBox.Show((string)msg.Info);
                }

            }
        }





        private void clientRB_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void pharmaRB_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void prepRB_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void fourniRB_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



       


       
    }
}

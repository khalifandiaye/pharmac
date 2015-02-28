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

            Thread thr = new Thread(new ThreadStart(Connexion));
            thr.Start();

        }


        private void Connexion()
        {
            if (nomTB.Text != "" && mdpTB.Text != "")
            {
                STR_MSG msg = work.AppelCommunication("Connexion", new object[] { nomTB.Text, mdpTB.Text });

                if (msg.Data != null)
                {
                    //MessageBox.Show((string)msg.Data[0]);
                    MessageBox.Show((string)msg.Info);
                    // ouvre la fenetre correspondante
                    if (token == "Client")
                    {
                        //cl = new Client();
                        

                        this.Invoke((MethodInvoker)delegate()
                        {
                            Client cl = new Client();
                            cl.Text = "Espace Client - " + nomTB.Text;
                            cl.Show(this);

                            this.Visible = false;

                        });


                    }
                    else if (token == "Pharmacien")
                    {

                    }
                    else if (token == "Fournisseur")
                    {

                    }
                    else if (token == "Preparateur")
                    {
                        //prep = new Preparateur();
                        

                        this.Invoke((MethodInvoker)delegate()
                        {
                            Preparateur prep = new Preparateur();
                            prep.Text = "Espace Préparateur - " + nomTB.Text;
                            prep.Show();

                            this.Visible = false;

                        });


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
            if (clientRB.Checked == true)
            {
                work.SetAuthentification("Client");
                token = "Client";
            }
        }

        private void pharmaRB_CheckedChanged(object sender, EventArgs e)
        {
            if (pharmaRB.Checked == true)
            {
                work.SetAuthentification("Pharmacien");
                token = "Pharmacien";
            }
        }

        private void prepRB_CheckedChanged(object sender, EventArgs e)
        {
            if (prepRB.Checked == true)
            {
                work.SetAuthentification("Preparateur");
                token = "Preparateur";
            }
        }

        private void fourniRB_CheckedChanged(object sender, EventArgs e)
        {
            if (fourniRB.Checked == true)
            {
                work.SetAuthentification("Fournisseur");
                token = "Fournisseur";
            }
        }



       


       
    }
}

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
    public partial class Client : Form
    {
        string username;
        string token = "Client";
        CL_WORK_COMPONENT work;
    
    
        public Client(string username)
        {
            InitializeComponent();
            this.username = username;
            work = new CL_WORK_COMPONENT();
            work.SetAuthentification("Client");
            Recherche_Client();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Recherche_Client()
        {
            //if (rech.Text != "")
            //{
                STR_MSG msg = work.AppelCommunication("ListerMedics", new object[] { username });

                if (msg.Info == "OK")
                {
                    DataSet ds = (DataSet)msg.Data[0];
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListMedic.Items.Add(row["MEDICS_NAME"].ToString());
                    }

                }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepotOrdonnance dpo = new DepotOrdonnance();
        }

        private void add_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ListMedic.SelectedItems)
            {
                ListViewItem newItem = (ListViewItem)item.Clone();

                bool IsContained = false;
                foreach(ListViewItem i in ListCommande.Items)
                {
                    if (i.Text == newItem.Text)
                    {
                        IsContained = true;
                        break;
                    }
                }
                if(!IsContained)
                {
                    ListCommande.Items.Add(newItem);
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ListCommande.SelectedItems)
            {
                ListCommande.Items.Remove(item);
            }
        }

        private void commander_Click(object sender, EventArgs e)
            
        {
            List<string> dataCommande = new List<string>();

            foreach (ListViewItem item in ListCommande.Items)
            {
                dataCommande.Add(item.Text);
            }

            
            string question = null;
           
            if (!checkbox.Checked)
            {
                question = richTextBox1.Text;

            }
             
            STR_MSG msg = work.AppelCommunication("CommandeClient", new object[] { username, dataCommande, question });
            if (msg.Info == "OK")
            {
                MessageBox.Show("La commande a été validée !");
            }
            else
            {
                MessageBox.Show(msg.Info);
            }
        }

        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox.Checked)
            {
                richTextBox1.Visible = false;
            }
            else
            {
                richTextBox1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

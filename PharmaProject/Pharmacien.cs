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

    public partial class Pharmacien : Form
    {
        string username;
        string token = "Pharmacien";
        CL_WORK_COMPONENT work;

        public Pharmacien(string username)
        {
            InitializeComponent();
            this.username = username;
            work = new CL_WORK_COMPONENT();
            work.SetAuthentification("Pharmacien");
        }

        private void ListCommandeClient(object sender, EventArgs e)
        {
            STR_MSG msg = work.AppelCommunication("GetCommandeClient", new object[] { username, rech.Text });

            if (msg.Info == "OK")
            {
                DataSet ds = (DataSet)msg.Data[0];
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ListMedic.Items.Add(row["LISTER_COMMANDE_CLIENT"].ToString());
                }

            }
        }
        private void Recherche_Pharmacien()
        {
            if (rech.Text != "")
            {
                STR_MSG msg = work.AppelCommunication("ListerMedics", new object[] { username, rech.Text });

                if (msg.Info == "OK")
                {
                    DataSet ds = (DataSet)msg.Data[0];
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListMedic.Items.Add(row["MEDICS_NAME"].ToString());
                    }

                }
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ListMedic.SelectedItems)
            {
                ListCommandeFournisseur.Items.Add(item);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ListCommandeFournisseur.SelectedItems)
            {
                ListCommandeFournisseur.Items.Remove(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> dataCommande = new List<string>();

            foreach (ListViewItem item in ListCommandeFournisseur.Items)
            {
                dataCommande.Add(item.Text);
            }

            STR_MSG msg = work.AppelCommunication("CommandePharmacien", new object[] { username, dataCommande});
            if (msg.Info == "OK")
            {
                MessageBox.Show("La commande a été validée !");
            }
            else
            {
                MessageBox.Show(msg.Info);
            }
        }
     
    }

}


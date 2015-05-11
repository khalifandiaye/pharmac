namespace PharmaProject
{
    partial class Pharmacien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ListMedic = new System.Windows.Forms.ListView();
            this.ListCommandeFournisseur = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rech = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.ListeCommandeClient = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Commandes des clients";
            // 
            // ListMedic
            // 
            this.ListMedic.Location = new System.Drawing.Point(585, 106);
            this.ListMedic.Name = "ListMedic";
            this.ListMedic.Size = new System.Drawing.Size(269, 471);
            this.ListMedic.TabIndex = 2;
            this.ListMedic.UseCompatibleStateImageBehavior = false;
            // 
            // ListCommandeFournisseur
            // 
            this.ListCommandeFournisseur.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ListCommandeFournisseur.Location = new System.Drawing.Point(944, 106);
            this.ListCommandeFournisseur.Name = "ListCommandeFournisseur";
            this.ListCommandeFournisseur.Size = new System.Drawing.Size(269, 471);
            this.ListCommandeFournisseur.TabIndex = 3;
            this.ListCommandeFournisseur.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 615);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Valider la commande ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1019, 615);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Valider la commande ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(941, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Commander aux fourniseeurs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Liste médicaments";
            // 
            // rech
            // 
            this.rech.Location = new System.Drawing.Point(585, 49);
            this.rech.Name = "rech";
            this.rech.Size = new System.Drawing.Size(195, 20);
            this.rech.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(786, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Recherche";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(863, 345);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 13;
            this.remove.Text = "Supprimer";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(863, 295);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 12;
            this.add.Text = "Ajouter";
            this.add.UseVisualStyleBackColor = true;
            // 
            // ListeCommandeClient
            // 
            this.ListeCommandeClient.Location = new System.Drawing.Point(15, 106);
            this.ListeCommandeClient.Name = "ListeCommandeClient";
            this.ListeCommandeClient.Size = new System.Drawing.Size(269, 471);
            this.ListeCommandeClient.TabIndex = 14;
            this.ListeCommandeClient.UseCompatibleStateImageBehavior = false;
            // 
            // Pharmacien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 688);
            this.Controls.Add(this.ListeCommandeClient);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.rech);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListCommandeFournisseur);
            this.Controls.Add(this.ListMedic);
            this.Controls.Add(this.label1);
            this.Name = "Pharmacien";
            this.Text = "Pharmacien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListCommandeClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ListMedic;
        private System.Windows.Forms.ListView ListCommandeFournisseur;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rech;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ListView ListeCommandeClient;
    }
}
namespace PharmaProject
{
    partial class Client
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
            this.ListMedic = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rech = new System.Windows.Forms.TextBox();
            this.ListCommande = new System.Windows.Forms.ListView();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.checkbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commander = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ListMedic
            // 
            this.ListMedic.Location = new System.Drawing.Point(12, 77);
            this.ListMedic.Name = "ListMedic";
            this.ListMedic.Size = new System.Drawing.Size(383, 358);
            this.ListMedic.TabIndex = 1;
            this.ListMedic.UseCompatibleStateImageBehavior = false;
            this.ListMedic.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Recherche";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Médicaments";
            // 
            // rech
            // 
            this.rech.Location = new System.Drawing.Point(12, 48);
            this.rech.Name = "rech";
            this.rech.Size = new System.Drawing.Size(195, 20);
            this.rech.TabIndex = 4;
            this.rech.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ListCommande
            // 
            this.ListCommande.Location = new System.Drawing.Point(500, 77);
            this.ListCommande.Name = "ListCommande";
            this.ListCommande.Size = new System.Drawing.Size(383, 358);
            this.ListCommande.TabIndex = 9;
            this.ListCommande.Tag = "Commande";
            this.ListCommande.UseCompatibleStateImageBehavior = false;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(410, 248);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 10;
            this.add.Text = "Ajouter";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(410, 298);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 11;
            this.remove.Text = "Supprimer";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.Checked = true;
            this.checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox.Location = new System.Drawing.Point(15, 480);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(15, 14);
            this.checkbox.TabIndex = 12;
            this.checkbox.UseVisualStyleBackColor = true;
            this.checkbox.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Je possède les informations des médicaments. Je n\'ai pas besoin d\'informations su" +
    "pplémentaires.";
            // 
            // commander
            // 
            this.commander.Location = new System.Drawing.Point(531, 475);
            this.commander.Name = "commander";
            this.commander.Size = new System.Drawing.Size(75, 23);
            this.commander.TabIndex = 14;
            this.commander.Text = "Commander";
            this.commander.UseVisualStyleBackColor = true;
            this.commander.Click += new System.EventHandler(this.commander_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Commande";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 516);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(868, 140);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 668);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commander);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkbox);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.ListCommande);
            this.Controls.Add(this.rech);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListMedic);
            this.Name = "Client";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListMedic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rech;
        private System.Windows.Forms.ListView ListCommande;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.CheckBox checkbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button commander;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
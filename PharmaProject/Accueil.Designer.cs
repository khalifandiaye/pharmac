namespace PharmaProject
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            this.button1 = new System.Windows.Forms.Button();
            this.nomTB = new System.Windows.Forms.TextBox();
            this.mdpTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.clientRB = new System.Windows.Forms.RadioButton();
            this.pharmaRB = new System.Windows.Forms.RadioButton();
            this.prepRB = new System.Windows.Forms.RadioButton();
            this.fourniRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nomTB
            // 
            this.nomTB.Location = new System.Drawing.Point(203, 229);
            this.nomTB.Name = "nomTB";
            this.nomTB.Size = new System.Drawing.Size(143, 20);
            this.nomTB.TabIndex = 1;
            this.nomTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // mdpTB
            // 
            this.mdpTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mdpTB.Location = new System.Drawing.Point(203, 290);
            this.mdpTB.Name = "mdpTB";
            this.mdpTB.Size = new System.Drawing.Size(143, 20);
            this.mdpTB.TabIndex = 2;
            this.mdpTB.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(208, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(409, 539);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Créez-vous un compte";
            // 
            // clientRB
            // 
            this.clientRB.AutoSize = true;
            this.clientRB.Checked = true;
            this.clientRB.Location = new System.Drawing.Point(87, 337);
            this.clientRB.Name = "clientRB";
            this.clientRB.Size = new System.Drawing.Size(51, 17);
            this.clientRB.TabIndex = 6;
            this.clientRB.TabStop = true;
            this.clientRB.Text = "Client";
            this.clientRB.UseVisualStyleBackColor = true;
            this.clientRB.CheckedChanged += new System.EventHandler(this.clientRB_CheckedChanged);
            // 
            // pharmaRB
            // 
            this.pharmaRB.AutoSize = true;
            this.pharmaRB.Location = new System.Drawing.Point(179, 337);
            this.pharmaRB.Name = "pharmaRB";
            this.pharmaRB.Size = new System.Drawing.Size(81, 17);
            this.pharmaRB.TabIndex = 7;
            this.pharmaRB.Text = "Pharmacien";
            this.pharmaRB.UseVisualStyleBackColor = true;
            this.pharmaRB.CheckedChanged += new System.EventHandler(this.pharmaRB_CheckedChanged);
            // 
            // prepRB
            // 
            this.prepRB.AutoSize = true;
            this.prepRB.Location = new System.Drawing.Point(293, 337);
            this.prepRB.Name = "prepRB";
            this.prepRB.Size = new System.Drawing.Size(80, 17);
            this.prepRB.TabIndex = 8;
            this.prepRB.Text = "Préparateur";
            this.prepRB.UseVisualStyleBackColor = true;
            this.prepRB.CheckedChanged += new System.EventHandler(this.prepRB_CheckedChanged);
            // 
            // fourniRB
            // 
            this.fourniRB.AutoSize = true;
            this.fourniRB.Location = new System.Drawing.Point(406, 337);
            this.fourniRB.Name = "fourniRB";
            this.fourniRB.Size = new System.Drawing.Size(79, 17);
            this.fourniRB.TabIndex = 9;
            this.fourniRB.Text = "Fournisseur";
            this.fourniRB.UseVisualStyleBackColor = true;
            this.fourniRB.CheckedChanged += new System.EventHandler(this.fourniRB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nom d\'utilisateur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mot de passe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 562);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fourniRB);
            this.Controls.Add(this.prepRB);
            this.Controls.Add(this.pharmaRB);
            this.Controls.Add(this.clientRB);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mdpTB);
            this.Controls.Add(this.nomTB);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 600);
            this.MinimumSize = new System.Drawing.Size(550, 600);
            this.Name = "Form1";
            this.Text = "Connexion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nomTB;
        private System.Windows.Forms.TextBox mdpTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton clientRB;
        private System.Windows.Forms.RadioButton pharmaRB;
        private System.Windows.Forms.RadioButton prepRB;
        private System.Windows.Forms.RadioButton fourniRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


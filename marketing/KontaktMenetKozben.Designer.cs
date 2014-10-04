namespace marketing
{
    partial class KontaktMenetKozben
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KontaktMenetKozben));
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textNev = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cbBeo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBPartner = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxMobil = new System.Windows.Forms.TextBox();
            this.textBoxFax = new System.Windows.Forms.TextBox();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(168, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "Rendben";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(274, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "Mégse";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textNev);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cbBeo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CBPartner);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.textBoxMobil);
            this.panel1.Controls.Add(this.textBoxFax);
            this.panel1.Controls.Add(this.textBoxTel);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 291);
            this.panel1.TabIndex = 0;
            // 
            // textNev
            // 
            this.textNev.FormattingEnabled = true;
            this.textNev.Location = new System.Drawing.Point(113, 16);
            this.textNev.Name = "textNev";
            this.textNev.Size = new System.Drawing.Size(261, 24);
            this.textNev.TabIndex = 0;
            this.textNev.Tag = "";
            this.textNev.SelectedIndexChanged += new System.EventHandler(this.textNev_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(380, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 43;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbBeo
            // 
            this.cbBeo.FormattingEnabled = true;
            this.cbBeo.Items.AddRange(new object[] {
            "könyvelő",
            "projekt manager",
            "számvitel",
            "tervező",
            "ügyvezető ig."});
            this.cbBeo.Location = new System.Drawing.Point(113, 77);
            this.cbBeo.Name = "cbBeo";
            this.cbBeo.Size = new System.Drawing.Size(155, 24);
            this.cbBeo.TabIndex = 2;
            this.cbBeo.Tag = "beo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "Beosztása:";
            // 
            // CBPartner
            // 
            this.CBPartner.FormattingEnabled = true;
            this.CBPartner.Location = new System.Drawing.Point(113, 47);
            this.CBPartner.MaxLength = 20;
            this.CBPartner.Name = "CBPartner";
            this.CBPartner.Size = new System.Drawing.Size(261, 24);
            this.CBPartner.TabIndex = 1;
            this.CBPartner.Tag = "pid";
            this.CBPartner.Leave += new System.EventHandler(this.cbPartner_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "Cég:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(113, 189);
            this.textBoxEmail.MaxLength = 100;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(413, 22);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.Tag = "email";
            // 
            // textBoxMobil
            // 
            this.textBoxMobil.Location = new System.Drawing.Point(113, 161);
            this.textBoxMobil.MaxLength = 50;
            this.textBoxMobil.Name = "textBoxMobil";
            this.textBoxMobil.Size = new System.Drawing.Size(261, 22);
            this.textBoxMobil.TabIndex = 5;
            this.textBoxMobil.Tag = "mobil";
            // 
            // textBoxFax
            // 
            this.textBoxFax.Location = new System.Drawing.Point(113, 133);
            this.textBoxFax.MaxLength = 50;
            this.textBoxFax.Name = "textBoxFax";
            this.textBoxFax.Size = new System.Drawing.Size(261, 22);
            this.textBoxFax.TabIndex = 4;
            this.textBoxFax.Tag = "fax";
            // 
            // textBoxTel
            // 
            this.textBoxTel.Location = new System.Drawing.Point(113, 105);
            this.textBoxTel.MaxLength = 50;
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(261, 22);
            this.textBoxTel.TabIndex = 3;
            this.textBoxTel.Tag = "telefon";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "E-mail:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 16);
            this.label21.TabIndex = 37;
            this.label21.Text = "Mobil:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 136);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 16);
            this.label22.TabIndex = 36;
            this.label22.Text = "Fax:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 16);
            this.label23.TabIndex = 35;
            this.label23.Text = "Telefon:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 16);
            this.label25.TabIndex = 34;
            this.label25.Text = "Név:";
            // 
            // KontaktMenetKozben
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(543, 291);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KontaktMenetKozben";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "C,PARTNER";
            this.Text = "Új kontakt hozzárendelése";
            this.Shown += new System.EventHandler(this.KontaktMenetKozben_Shown);
            this.VisibleChanged += new System.EventHandler(this.KontaktMenetKozben_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxMobil;
        private System.Windows.Forms.TextBox textBoxFax;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CBPartner;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox cbBeo;
        public System.Windows.Forms.ComboBox textNev;
        public System.Windows.Forms.Panel panel1;
    }
}
namespace marketing
{
    partial class KontaktMenetKozbenUj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KontaktMenetKozbenUj));
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textNev = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cbBeo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPartner = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
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
            this.panel1.Controls.Add(this.cbPartner);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox12);
            this.panel1.Controls.Add(this.textBox13);
            this.panel1.Controls.Add(this.textBox14);
            this.panel1.Controls.Add(this.textBox15);
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
            this.textNev.Location = new System.Drawing.Point(113, 17);
            this.textNev.Name = "textNev";
            this.textNev.Size = new System.Drawing.Size(261, 22);
            this.textNev.TabIndex = 0;
            this.textNev.Tag = "nev";
            this.textNev.Leave += new System.EventHandler(this.textNev_Leave);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(380, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 43;
            this.button3.TabStop = false;
            this.toolTip.SetToolTip(this.button3, "Új partner felvétele");
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
            // cbPartner
            // 
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(113, 47);
            this.cbPartner.MaxLength = 20;
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(261, 24);
            this.cbPartner.TabIndex = 1;
            this.cbPartner.Tag = "pid";
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
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(113, 189);
            this.textBox12.MaxLength = 100;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(413, 22);
            this.textBox12.TabIndex = 6;
            this.textBox12.Tag = "email";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(113, 161);
            this.textBox13.MaxLength = 50;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(261, 22);
            this.textBox13.TabIndex = 5;
            this.textBox13.Tag = "mobil";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(113, 133);
            this.textBox14.MaxLength = 50;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(261, 22);
            this.textBox14.TabIndex = 4;
            this.textBox14.Tag = "fax";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(113, 105);
            this.textBox15.MaxLength = 50;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(261, 22);
            this.textBox15.TabIndex = 3;
            this.textBox15.Tag = "telefon";
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
            this.label23.Size = new System.Drawing.Size(53, 16);
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
            // toolTip
            // 
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            // 
            // KontaktMenetKozbenUj
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
            this.Name = "KontaktMenetKozbenUj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "C,PARTNER";
            this.Text = "Új kontakt felvétele";
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox cbBeo;
        public System.Windows.Forms.TextBox textNev;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
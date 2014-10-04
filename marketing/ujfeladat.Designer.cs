namespace marketing
{
    partial class ujfeladat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ujfeladat));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonMentes = new System.Windows.Forms.ToolStripButton();
            this.buttonVissza = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.napelem = new System.Windows.Forms.CheckBox();
            this.egyeb = new System.Windows.Forms.CheckBox();
            this.alpin = new System.Windows.Forms.CheckBox();
            this.tisztito = new System.Windows.Forms.CheckBox();
            this.biztonsagi = new System.Windows.Forms.CheckBox();
            this.hid = new System.Windows.Forms.CheckBox();
            this.allvany = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 28);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 28);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonMentes,
            this.buttonVissza});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(365, 25);
            this.toolStrip.TabIndex = 14;
            this.toolStrip.Text = "toolStrip1";
            // 
            // buttonMentes
            // 
            this.buttonMentes.Image = ((System.Drawing.Image)(resources.GetObject("buttonMentes.Image")));
            this.buttonMentes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMentes.Name = "buttonMentes";
            this.buttonMentes.Size = new System.Drawing.Size(71, 22);
            this.buttonMentes.Text = "Mentés";
            this.buttonMentes.Click += new System.EventHandler(this.buttonMentes_Click);
            // 
            // buttonVissza
            // 
            this.buttonVissza.Image = global::marketing.Properties.Resources.Button_Previous_01;
            this.buttonVissza.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(68, 22);
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.Click += new System.EventHandler(this.buttonVissza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(458, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Új projekt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.napelem);
            this.groupBox1.Controls.Add(this.egyeb);
            this.groupBox1.Controls.Add(this.alpin);
            this.groupBox1.Controls.Add(this.tisztito);
            this.groupBox1.Controls.Add(this.biztonsagi);
            this.groupBox1.Controls.Add(this.hid);
            this.groupBox1.Controls.Add(this.allvany);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üzletág";
            // 
            // napelem
            // 
            this.napelem.AutoSize = true;
            this.napelem.Location = new System.Drawing.Point(757, 17);
            this.napelem.Name = "napelem";
            this.napelem.Size = new System.Drawing.Size(68, 17);
            this.napelem.TabIndex = 6;
            this.napelem.Tag = "uzletag6";
            this.napelem.Text = "Napelem";
            this.napelem.UseVisualStyleBackColor = true;
            // 
            // egyeb
            // 
            this.egyeb.AutoSize = true;
            this.egyeb.Location = new System.Drawing.Point(857, 17);
            this.egyeb.Name = "egyeb";
            this.egyeb.Size = new System.Drawing.Size(56, 17);
            this.egyeb.TabIndex = 5;
            this.egyeb.Tag = "uzletag7";
            this.egyeb.Text = "Egyéb";
            this.egyeb.UseVisualStyleBackColor = true;
            // 
            // alpin
            // 
            this.alpin.AutoSize = true;
            this.alpin.Location = new System.Drawing.Point(655, 17);
            this.alpin.Name = "alpin";
            this.alpin.Size = new System.Drawing.Size(70, 17);
            this.alpin.TabIndex = 4;
            this.alpin.Tag = "uzletag5";
            this.alpin.Text = "Alpinpont";
            this.alpin.UseVisualStyleBackColor = true;
            // 
            // tisztito
            // 
            this.tisztito.AutoSize = true;
            this.tisztito.Location = new System.Drawing.Point(519, 17);
            this.tisztito.Name = "tisztito";
            this.tisztito.Size = new System.Drawing.Size(104, 17);
            this.tisztito.TabIndex = 3;
            this.tisztito.Tag = "uzletag4";
            this.tisztito.Text = "Tisztító rendszer";
            this.tisztito.UseVisualStyleBackColor = true;
            this.tisztito.CheckedChanged += new System.EventHandler(this.tisztito_CheckedChanged);
            // 
            // biztonsagi
            // 
            this.biztonsagi.AutoSize = true;
            this.biztonsagi.Location = new System.Drawing.Point(357, 17);
            this.biztonsagi.Name = "biztonsagi";
            this.biztonsagi.Size = new System.Drawing.Size(130, 17);
            this.biztonsagi.TabIndex = 2;
            this.biztonsagi.Tag = "uzletag3";
            this.biztonsagi.Text = "Leesés elleni rendszer";
            this.biztonsagi.UseVisualStyleBackColor = true;
            // 
            // hid
            // 
            this.hid.AutoSize = true;
            this.hid.Location = new System.Drawing.Point(225, 17);
            this.hid.Name = "hid";
            this.hid.Size = new System.Drawing.Size(100, 17);
            this.hid.TabIndex = 1;
            this.hid.Tag = "uzletag2";
            this.hid.Text = "Függesztett híd";
            this.hid.UseVisualStyleBackColor = true;
            // 
            // allvany
            // 
            this.allvany.AutoSize = true;
            this.allvany.Location = new System.Drawing.Point(100, 17);
            this.allvany.Name = "allvany";
            this.allvany.Size = new System.Drawing.Size(93, 17);
            this.allvany.TabIndex = 0;
            this.allvany.Tag = "uzletag1";
            this.allvany.Text = "Guruló állvány";
            this.allvany.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1003, 599);
            this.panel3.TabIndex = 3;
            // 
            // ujfeladat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ujfeladat";
            this.Size = new System.Drawing.Size(1003, 678);
            this.Load += new System.EventHandler(this.ujfeladat_Load);
            this.VisibleChanged += new System.EventHandler(this.ujfeladat_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonMentes;
        private System.Windows.Forms.ToolStripButton buttonVissza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox alpin;
        private System.Windows.Forms.CheckBox tisztito;
        private System.Windows.Forms.CheckBox biztonsagi;
        private System.Windows.Forms.CheckBox hid;
        private System.Windows.Forms.CheckBox allvany;
        private System.Windows.Forms.CheckBox egyeb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox napelem;
    }
}

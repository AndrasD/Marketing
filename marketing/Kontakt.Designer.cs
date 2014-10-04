namespace marketing
{
    partial class Kontakt
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kontakt));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonUj = new System.Windows.Forms.ToolStripButton();
            this.buttonTorol = new System.Windows.Forms.ToolStripButton();
            this.buttonVissza = new System.Windows.Forms.ToolStripButton();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.nev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.filterNev = new System.Windows.Forms.TextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonUj,
            this.buttonTorol,
            this.buttonVissza});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(842, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // buttonUj
            // 
            this.buttonUj.Image = global::marketing.Properties.Resources.Button_Add_01;
            this.buttonUj.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonUj.Name = "buttonUj";
            this.buttonUj.Size = new System.Drawing.Size(81, 22);
            this.buttonUj.Text = "Új felvítel";
            this.buttonUj.ToolTipText = "Új elem felvétele";
            this.buttonUj.Click += new System.EventHandler(this.buttonUj_Click);
            // 
            // buttonTorol
            // 
            this.buttonTorol.Image = global::marketing.Properties.Resources.Button_Close_01;
            this.buttonTorol.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonTorol.Name = "buttonTorol";
            this.buttonTorol.Size = new System.Drawing.Size(58, 22);
            this.buttonTorol.Text = "Töröl";
            this.buttonTorol.Click += new System.EventHandler(this.buttonTorol_Click);
            // 
            // buttonVissza
            // 
            this.buttonVissza.Image = global::marketing.Properties.Resources.Button_Previous_01;
            this.buttonVissza.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(64, 22);
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.Click += new System.EventHandler(this.buttonVissza_Click_1);
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.AllowUserToDeleteRows = false;
            this.dataGV.AllowUserToResizeColumns = false;
            this.dataGV.AllowUserToResizeRows = false;
            this.dataGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nev,
            this.id,
            this.pid,
            this.beo});
            this.dataGV.Location = new System.Drawing.Point(3, 71);
            this.dataGV.MultiSelect = false;
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowHeadersWidth = 24;
            this.dataGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGV.Size = new System.Drawing.Size(836, 259);
            this.dataGV.TabIndex = 2;
            this.dataGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_CellClick);
            // 
            // nev
            // 
            this.nev.DataPropertyName = "nev";
            this.nev.Frozen = true;
            this.nev.HeaderText = "Név";
            this.nev.Name = "nev";
            this.nev.ReadOnly = true;
            this.nev.Width = 54;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.Visible = false;
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "pid";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Visible = false;
            // 
            // beo
            // 
            this.beo.DataPropertyName = "beo";
            this.beo.HeaderText = "beo";
            this.beo.Name = "beo";
            this.beo.ReadOnly = true;
            this.beo.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textNev);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cbBeo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbPartner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(27, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 267);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adatok";
            // 
            // textNev
            // 
            this.textNev.Location = new System.Drawing.Point(85, 34);
            this.textNev.Name = "textNev";
            this.textNev.ReadOnly = true;
            this.textNev.Size = new System.Drawing.Size(280, 22);
            this.textNev.TabIndex = 44;
            this.textNev.Tag = "nev";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(373, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 58;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
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
            this.cbBeo.Location = new System.Drawing.Point(85, 94);
            this.cbBeo.Name = "cbBeo";
            this.cbBeo.Size = new System.Drawing.Size(174, 24);
            this.cbBeo.TabIndex = 46;
            this.cbBeo.Tag = "beo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Beosztása:";
            // 
            // cbPartner
            // 
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(85, 64);
            this.cbPartner.MaxLength = 20;
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(280, 24);
            this.cbPartner.TabIndex = 45;
            this.cbPartner.Tag = "pid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Cég:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(85, 206);
            this.textBox12.MaxLength = 100;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(354, 22);
            this.textBox12.TabIndex = 50;
            this.textBox12.Tag = "email";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(85, 178);
            this.textBox13.MaxLength = 50;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(280, 22);
            this.textBox13.TabIndex = 49;
            this.textBox13.Tag = "mobil";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(85, 150);
            this.textBox14.MaxLength = 50;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(280, 22);
            this.textBox14.TabIndex = 48;
            this.textBox14.Tag = "fax";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(85, 122);
            this.textBox15.MaxLength = 50;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(280, 22);
            this.textBox15.TabIndex = 47;
            this.textBox15.Tag = "telefon";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 209);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 16);
            this.label20.TabIndex = 55;
            this.label20.Text = "E-mail:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 181);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 16);
            this.label21.TabIndex = 54;
            this.label21.Text = "Mobil:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 153);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 16);
            this.label22.TabIndex = 53;
            this.label22.Text = "Fax:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 125);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 16);
            this.label23.TabIndex = 52;
            this.label23.Text = "Telefon:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 39);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 16);
            this.label25.TabIndex = 51;
            this.label25.Text = "Név:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Rendben";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // filterNev
            // 
            this.filterNev.Location = new System.Drawing.Point(27, 43);
            this.filterNev.Name = "filterNev";
            this.filterNev.Size = new System.Drawing.Size(137, 22);
            this.filterNev.TabIndex = 19;
            this.filterNev.TextChanged += new System.EventHandler(this.filterNev_TextChanged);
            // 
            // Kontakt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filterNev);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Kontakt";
            this.Size = new System.Drawing.Size(842, 612);
            this.Tag = "Dolgozók karbantartása";
            this.Load += new System.EventHandler(this.Kontakt_Load);
            this.VisibleChanged += new System.EventHandler(this.Kontakt_VisibleChanged);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonUj;
        private System.Windows.Forms.ToolStripButton buttonTorol;
        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripButton buttonVissza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textNev;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox cbBeo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridViewTextBoxColumn nev;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn beo;
        private System.Windows.Forms.TextBox filterNev;
    }
}

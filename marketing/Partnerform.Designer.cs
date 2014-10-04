namespace marketing
{
    partial class Partnerform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partnerform));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonUj = new System.Windows.Forms.ToolStripButton();
            this.buttonTorol = new System.Windows.Forms.ToolStripButton();
            this.buttonMentes = new System.Windows.Forms.ToolStripButton();
            this.buttonVissza = new System.Windows.Forms.ToolStripButton();
            this.filterNev = new System.Windows.Forms.TextBox();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textNev = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKoztj = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIrsz = new System.Windows.Forms.ComboBox();
            this.textTelepules = new System.Windows.Forms.TextBox();
            this.textIRSZ = new System.Windows.Forms.TextBox();
            this.textSzoveg = new System.Windows.Forms.TextBox();
            this.buttonFrissit = new System.Windows.Forms.ToolStripButton();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.azonosito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pirsz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irsz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telepules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkozt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.szoveg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkoztj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phazsz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sajat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verzio_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonVissza,
            this.buttonUj,
            this.buttonTorol,
            this.buttonMentes,
            this.buttonFrissit});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(859, 25);
            this.toolStrip.TabIndex = 2;
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
            // buttonMentes
            // 
            this.buttonMentes.Image = ((System.Drawing.Image)(resources.GetObject("buttonMentes.Image")));
            this.buttonMentes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMentes.Name = "buttonMentes";
            this.buttonMentes.Size = new System.Drawing.Size(69, 22);
            this.buttonMentes.Text = "Mentés";
            this.buttonMentes.Click += new System.EventHandler(this.buttonMent_Click);
            // 
            // buttonVissza
            // 
            this.buttonVissza.Image = global::marketing.Properties.Resources.Button_Previous_01;
            this.buttonVissza.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(64, 22);
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.Click += new System.EventHandler(this.buttonVissza_Click);
            // 
            // filterNev
            // 
            this.filterNev.Location = new System.Drawing.Point(3, 28);
            this.filterNev.Name = "filterNev";
            this.filterNev.Size = new System.Drawing.Size(137, 20);
            this.filterNev.TabIndex = 20;
            this.filterNev.TextChanged += new System.EventHandler(this.filterNev_TextChanged);
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.AllowUserToDeleteRows = false;
            this.dataGV.AllowUserToResizeColumns = false;
            this.dataGV.AllowUserToResizeRows = false;
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.azonosito,
            this.pirsz,
            this.irsz,
            this.telepules,
            this.pkozt,
            this.szoveg,
            this.pkoztj,
            this.phazsz,
            this.sajat,
            this.verzio_id});
            this.dataGV.Location = new System.Drawing.Point(3, 54);
            this.dataGV.MultiSelect = false;
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowHeadersWidth = 24;
            this.dataGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGV.Size = new System.Drawing.Size(853, 339);
            this.dataGV.TabIndex = 21;
            this.dataGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_CellClick);
            this.dataGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGV_DataError);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textSzoveg);
            this.panel1.Controls.Add(this.textIRSZ);
            this.panel1.Controls.Add(this.textTelepules);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textNev);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbKoztj);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbIrsz);
            this.panel1.Location = new System.Drawing.Point(3, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 210);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Partnerazonosító";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(208, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 22;
            this.button2.Text = "Mégse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textNev
            // 
            this.textNev.Location = new System.Drawing.Point(168, 21);
            this.textNev.MaxLength = 50;
            this.textNev.Name = "textNev";
            this.textNev.Size = new System.Drawing.Size(186, 20);
            this.textNev.TabIndex = 0;
            this.textNev.Tag = "azonosito";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(102, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Rendben";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Irsz,helyiség(ker)";
            // 
            // cbKoztj
            // 
            this.cbKoztj.FormattingEnabled = true;
            this.cbKoztj.Location = new System.Drawing.Point(168, 105);
            this.cbKoztj.Name = "cbKoztj";
            this.cbKoztj.Size = new System.Drawing.Size(84, 21);
            this.cbKoztj.TabIndex = 3;
            this.cbKoztj.Tag = "PKOZTJ";
            this.cbKoztj.ValueMember = "SORSZAM";
            this.cbKoztj.Leave += new System.EventHandler(this.cbKoztj_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Közterület";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(168, 135);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Tag = "PHAZSZ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Közt.jellege";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 77);
            this.textBox2.MaxLength = 45;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "PKOZT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Házszám/Hrsz";
            // 
            // cbIrsz
            // 
            this.cbIrsz.FormattingEnabled = true;
            this.cbIrsz.Location = new System.Drawing.Point(168, 47);
            this.cbIrsz.Name = "cbIrsz";
            this.cbIrsz.Size = new System.Drawing.Size(170, 21);
            this.cbIrsz.TabIndex = 1;
            this.cbIrsz.Tag = "PIRSZ";
            this.cbIrsz.ValueMember = "SORSZAM";
            this.cbIrsz.Leave += new System.EventHandler(this.cbIrsz_Leave);
            // 
            // textTelepules
            // 
            this.textTelepules.Location = new System.Drawing.Point(514, 47);
            this.textTelepules.Name = "textTelepules";
            this.textTelepules.Size = new System.Drawing.Size(100, 20);
            this.textTelepules.TabIndex = 23;
            this.textTelepules.Tag = "TELEPULES";
            this.textTelepules.Visible = false;
            // 
            // textIRSZ
            // 
            this.textIRSZ.Location = new System.Drawing.Point(371, 47);
            this.textIRSZ.Name = "textIRSZ";
            this.textIRSZ.Size = new System.Drawing.Size(100, 20);
            this.textIRSZ.TabIndex = 24;
            this.textIRSZ.Tag = "IRSZ";
            this.textIRSZ.Visible = false;
            // 
            // textSzoveg
            // 
            this.textSzoveg.Location = new System.Drawing.Point(371, 105);
            this.textSzoveg.Name = "textSzoveg";
            this.textSzoveg.Size = new System.Drawing.Size(100, 20);
            this.textSzoveg.TabIndex = 25;
            this.textSzoveg.Tag = "SZOVEG";
            this.textSzoveg.Visible = false;
            // 
            // buttonFrissit
            // 
            this.buttonFrissit.Image = global::marketing.Properties.Resources.Button_Refresh_01;
            this.buttonFrissit.ImageTransparentColor = System.Drawing.Color.Black;
            this.buttonFrissit.Name = "buttonFrissit";
            this.buttonFrissit.Size = new System.Drawing.Size(63, 22);
            this.buttonFrissit.Text = "Elölről";
            this.buttonFrissit.Click += new System.EventHandler(this.buttonFrissit_Click);
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "id";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Width = 45;
            // 
            // azonosito
            // 
            this.azonosito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.azonosito.DataPropertyName = "azonosito";
            this.azonosito.HeaderText = "Azonosító";
            this.azonosito.Name = "azonosito";
            this.azonosito.ReadOnly = true;
            this.azonosito.Width = 91;
            // 
            // pirsz
            // 
            this.pirsz.DataPropertyName = "pirsz";
            this.pirsz.HeaderText = "pirsz";
            this.pirsz.Name = "pirsz";
            this.pirsz.ReadOnly = true;
            this.pirsz.Visible = false;
            // 
            // irsz
            // 
            this.irsz.DataPropertyName = "irsz";
            this.irsz.HeaderText = "Irsz";
            this.irsz.Name = "irsz";
            this.irsz.ReadOnly = true;
            this.irsz.Width = 70;
            // 
            // telepules
            // 
            this.telepules.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.telepules.DataPropertyName = "telepules";
            this.telepules.HeaderText = "Település";
            this.telepules.Name = "telepules";
            this.telepules.ReadOnly = true;
            this.telepules.Width = 87;
            // 
            // pkozt
            // 
            this.pkozt.DataPropertyName = "pkozt";
            this.pkozt.HeaderText = "Közterület";
            this.pkozt.Name = "pkozt";
            this.pkozt.ReadOnly = true;
            // 
            // szoveg
            // 
            this.szoveg.DataPropertyName = "szoveg";
            this.szoveg.HeaderText = "Közt.jellege";
            this.szoveg.Name = "szoveg";
            this.szoveg.ReadOnly = true;
            // 
            // pkoztj
            // 
            this.pkoztj.DataPropertyName = "pkoztj";
            this.pkoztj.HeaderText = "pkoztj";
            this.pkoztj.Name = "pkoztj";
            this.pkoztj.ReadOnly = true;
            this.pkoztj.Visible = false;
            // 
            // phazsz
            // 
            this.phazsz.DataPropertyName = "phazsz";
            this.phazsz.HeaderText = "Házszám";
            this.phazsz.Name = "phazsz";
            this.phazsz.ReadOnly = true;
            // 
            // sajat
            // 
            this.sajat.DataPropertyName = "sajat";
            this.sajat.HeaderText = "sajat";
            this.sajat.Name = "sajat";
            this.sajat.ReadOnly = true;
            this.sajat.Visible = false;
            // 
            // verzio_id
            // 
            this.verzio_id.DataPropertyName = "verzio_id";
            this.verzio_id.HeaderText = "verzio_id";
            this.verzio_id.Name = "verzio_id";
            this.verzio_id.ReadOnly = true;
            this.verzio_id.Visible = false;
            // 
            // Partnerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.filterNev);
            this.Controls.Add(this.toolStrip);
            this.Name = "Partnerform";
            this.Size = new System.Drawing.Size(859, 612);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonUj;
        private System.Windows.Forms.ToolStripButton buttonTorol;
        private System.Windows.Forms.ToolStripButton buttonVissza;
        private System.Windows.Forms.TextBox filterNev;
        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textNev;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKoztj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbIrsz;
        private System.Windows.Forms.ToolStripButton buttonMentes;
        private System.Windows.Forms.TextBox textSzoveg;
        private System.Windows.Forms.TextBox textIRSZ;
        private System.Windows.Forms.TextBox textTelepules;
        private System.Windows.Forms.ToolStripButton buttonFrissit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn azonosito;
        private System.Windows.Forms.DataGridViewTextBoxColumn pirsz;
        private System.Windows.Forms.DataGridViewTextBoxColumn irsz;
        private System.Windows.Forms.DataGridViewTextBoxColumn telepules;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkozt;
        private System.Windows.Forms.DataGridViewTextBoxColumn szoveg;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkoztj;
        private System.Windows.Forms.DataGridViewTextBoxColumn phazsz;
        private System.Windows.Forms.DataGridViewTextBoxColumn sajat;
        private System.Windows.Forms.DataGridViewTextBoxColumn verzio_id;
    }
}

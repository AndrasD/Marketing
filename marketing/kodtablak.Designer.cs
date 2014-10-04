namespace marketing
{
    partial class kodtablak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kodtablak));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonUj = new System.Windows.Forms.ToolStripButton();
            this.buttonTorol = new System.Windows.Forms.ToolStripButton();
            this.buttonMentes = new System.Windows.Forms.ToolStripButton();
            this.buttonVissza = new System.Windows.Forms.ToolStripButton();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMegnevezes = new System.Windows.Forms.TextBox();
            this.textKod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbKodtip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.buttonMentes,
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
            // buttonMentes
            // 
            this.buttonMentes.Image = ((System.Drawing.Image)(resources.GetObject("buttonMentes.Image")));
            this.buttonMentes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMentes.Name = "buttonMentes";
            this.buttonMentes.Size = new System.Drawing.Size(69, 22);
            this.buttonMentes.Text = "Mentés";
            this.buttonMentes.Click += new System.EventHandler(this.buttonOK_Click);
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
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(85, 91);
            this.dataGV.MultiSelect = false;
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowHeadersWidth = 24;
            this.dataGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGV.Size = new System.Drawing.Size(411, 500);
            this.dataGV.TabIndex = 2;
            this.dataGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_CellClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMegnevezes);
            this.groupBox1.Controls.Add(this.textKod);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(502, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 500);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adatok";
            // 
            // textMegnevezes
            // 
            this.textMegnevezes.Location = new System.Drawing.Point(39, 86);
            this.textMegnevezes.Name = "textMegnevezes";
            this.textMegnevezes.Size = new System.Drawing.Size(100, 22);
            this.textMegnevezes.TabIndex = 20;
            // 
            // textKod
            // 
            this.textKod.Location = new System.Drawing.Point(39, 40);
            this.textKod.Name = "textKod";
            this.textKod.Size = new System.Drawing.Size(100, 22);
            this.textKod.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(131, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Rendben";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbKodtip
            // 
            this.cbKodtip.FormattingEnabled = true;
            this.cbKodtip.Location = new System.Drawing.Point(85, 48);
            this.cbKodtip.Name = "cbKodtip";
            this.cbKodtip.Size = new System.Drawing.Size(411, 24);
            this.cbKodtip.TabIndex = 19;
            this.cbKodtip.SelectedIndexChanged += new System.EventHandler(this.cbKodtip_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Kódtípusok:";
            // 
            // kodtablak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKodtip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "kodtablak";
            this.Size = new System.Drawing.Size(842, 612);
            this.Tag = "Dolgozók karbantartása";
            this.Load += new System.EventHandler(this.kodtablak_Load);
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
        private System.Windows.Forms.ToolStripButton buttonMentes;
        private System.Windows.Forms.ToolStripButton buttonVissza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textKod;
        private System.Windows.Forms.TextBox textMegnevezes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKodtip;
    }
}

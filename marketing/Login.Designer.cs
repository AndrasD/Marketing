namespace marketing
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.megsem = new System.Windows.Forms.Button();
            this.rendben = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.verzio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Black;
            this.imageList.Images.SetKeyName(0, "rendben-16x16.bmp");
            this.imageList.Images.SetKeyName(1, "eldob-16x16.bmp");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(146, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bejelentkezés";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 34);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.textPWD);
            this.panel2.Controls.Add(this.textUser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.megsem);
            this.panel2.Controls.Add(this.rendben);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 153);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::marketing.Properties.Resources.Maxthon_icon;
            this.pictureBox1.Location = new System.Drawing.Point(23, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(247, 58);
            this.textPWD.MaxLength = 15;
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(124, 22);
            this.textPWD.TabIndex = 7;
            this.textPWD.UseSystemPasswordChar = true;
            this.textPWD.Leave += new System.EventHandler(this.textPWD_Leave);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(247, 30);
            this.textUser.MaxLength = 30;
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(124, 22);
            this.textUser.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Jelszó:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Azonosító:";
            // 
            // megsem
            // 
            this.megsem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megsem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.megsem.ImageIndex = 1;
            this.megsem.ImageList = this.imageList;
            this.megsem.Location = new System.Drawing.Point(277, 99);
            this.megsem.Name = "megsem";
            this.megsem.Size = new System.Drawing.Size(88, 27);
            this.megsem.TabIndex = 11;
            this.megsem.Text = "Mégsem";
            this.megsem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.megsem.UseVisualStyleBackColor = true;
            // 
            // rendben
            // 
            this.rendben.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rendben.ImageIndex = 0;
            this.rendben.ImageList = this.imageList;
            this.rendben.Location = new System.Drawing.Point(165, 99);
            this.rendben.Name = "rendben";
            this.rendben.Size = new System.Drawing.Size(88, 27);
            this.rendben.TabIndex = 9;
            this.rendben.Text = "Rendben";
            this.rendben.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rendben.UseVisualStyleBackColor = true;
            this.rendben.Click += new System.EventHandler(this.rendben_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.verzio);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(409, 20);
            this.panel3.TabIndex = 9;
            // 
            // verzio
            // 
            this.verzio.AutoSize = true;
            this.verzio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.verzio.Location = new System.Drawing.Point(141, 3);
            this.verzio.Name = "verzio";
            this.verzio.Size = new System.Drawing.Size(95, 14);
            this.verzio.TabIndex = 0;
            this.verzio.Text = "S- Marketing  Ver.:";
            // 
            // Login
            // 
            this.AcceptButton = this.rendben;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.megsem;
            this.ClientSize = new System.Drawing.Size(409, 207);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Bejelentkezes_Activated);
            this.Load += new System.EventHandler(this.Bejelentkezes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textPWD;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button megsem;
        private System.Windows.Forms.Button rendben;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label verzio;
    }
}
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Könyvtar.ClassGyujtemeny;
using System.Threading;
//using SplashScreen;
//using TableInfo;

namespace marketing
{
    public partial class MainForm : Form
    {
        public Version ver = new Version(2,0,6);

        private Gyujtemeny Gyujt = new Gyujtemeny();
        private Login bejelentkezes = new Login();
        private InicialForm inicial = new InicialForm();

        private statuslista statlist;
        private ujfeladat feladat;
        public feladatkezeles feladatmod;   
        public lekerdezesekLista dolgozolist;
        public lekerdezesekLista ceglist;
        public lekerdezesekLista kontaktlist;
        public lekerdezesekLista sajatlist;
        public lekerdezesekLista projektlist;
        public lekerdezesekLista kimitcsinaltlist;
        public Dolgozo dolgozoKarb;
        public kodtablak kodTablak;
        public Kontakt kontaktKarb;

        public Partnerform partnerKarb;

        private DataSet dataSet = new DataSet();
        private DataTable tableUser_info = new DataTable();
        private DataTable tableUser = new DataTable();
        private SqlConnection myconn = new SqlConnection();
        private SqlConnection mysqlconn = new SqlConnection();
        private string rendszerconn = "Data Source=ANDRAS-PC\\SQLExpress;Initial Catalog=marketing;Integrated Security=True;";
//        private string rendszerconn = "Data Source=ST-SZERVER\\SQLEXPRESS;Initial Catalog=marketing;USer Id=Skytec;Password=Skytec11;";

        private string user;
        private string pwd;
        private string jogosultsag = "1";

        public string defaultDir = "m:\\Dokumentumok";

        public string ujProjektAzon = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " Ver.:" + ver.ToString();
            bejelentkezes.Verzio = ver.ToString();
            if (bejelentkezes.ShowDialog() == DialogResult.Cancel)
                this.Close();
            else
            {
                myconn = bejelentkezes.Connection;
                rendszerconn = myconn.ConnectionString;
                user = bejelentkezes.User;
                pwd = bejelentkezes.Pwd;
                jogosultsag = bejelentkezes.Jogosultsag;
                defaultDir = bejelentkezes.DefaultDir;

                this.userLoad();

                statlist = new statuslista(this);
                statlist.userId = bejelentkezes.UserId;
                feladat = new ujfeladat(this);
                feladatmod = new feladatkezeles(this);
                feladatmod.textKeres.SelectedIndexChanged -= new EventHandler(feladatmod.textKeres_SelectedIndexChanged);
                feladatmod.userId = bejelentkezes.UserId;

                dolgozolist = new lekerdezesekLista(this, "dolgozo");
                ceglist = new lekerdezesekLista(this, "ceg");
                kontaktlist = new lekerdezesekLista(this, "kontakt");
                sajatlist = new lekerdezesekLista(this, "sajat");
                sajatlist.userId = bejelentkezes.UserId;
                dolgozoKarb = new Dolgozo(this);
                projektlist = new lekerdezesekLista(this, "projekt");
                kodTablak = new kodtablak(this);
                kontaktKarb = new Kontakt(this);
                kimitcsinaltlist = new lekerdezesekLista(this, "kimit");

                partnerKarb = new Partnerform(this);

                panel1.Controls.Add(statlist);
                panel1.Controls.Add(feladat);
                panel1.Controls[1].Visible = false;
                panel1.Controls[1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(feladatmod);
                panel1.Controls[2].Visible = false;
                panel1.Controls[2].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(dolgozolist);
                panel1.Controls[3].Visible = false;
                panel1.Controls[3].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(ceglist);
                panel1.Controls[4].Visible = false;
                panel1.Controls[4].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(kontaktlist);
                panel1.Controls[5].Visible = false;
                panel1.Controls[5].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(sajatlist);
                panel1.Controls[6].Visible = false;
                panel1.Controls[6].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);

                if (jogosultsag == "1")
                {
                    dolgozokToolStripMenuItem.Visible = true;
                    panel1.Controls.Add(dolgozoKarb);
                    panel1.Controls[7].Visible = false;
                    panel1.Controls[7].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                }
                panel1.Controls.Add(projektlist);
                panel1.Controls[panel1.Controls.Count - 1].Visible = false;
                panel1.Controls[panel1.Controls.Count - 1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                if (jogosultsag == "1")
                {
                    kódtáblákToolStripMenuItem.Visible = true;
                    panel1.Controls.Add(kodTablak);
                    panel1.Controls[panel1.Controls.Count - 1].Visible = false;
                    panel1.Controls[panel1.Controls.Count - 1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                }
                panel1.Controls.Add(kontaktKarb);
                panel1.Controls[panel1.Controls.Count - 1].Visible = false;
                panel1.Controls[panel1.Controls.Count - 1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(kimitcsinaltlist);
                panel1.Controls[panel1.Controls.Count - 1].Visible = false;
                panel1.Controls[panel1.Controls.Count - 1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
                panel1.Controls.Add(partnerKarb);
                panel1.Controls[panel1.Controls.Count - 1].Visible = false;
                panel1.Controls[panel1.Controls.Count - 1].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
            }
        }

        #region Tulajdonságok (Get és Set)

        public SqlConnection MyConn
        {
            get { return this.myconn; }
            set { this.myconn = value; }
        }

        public SqlConnection MySqlConn
        {
            get { return this.mysqlconn; }
            set { this.mysqlconn = value; }
        }

        public string UserId
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public string Password
        {
            get { return this.pwd; }
            set { this.pwd = value; }
        }

        public string Jogosultsag
        {
            get { return this.jogosultsag; }
            set { this.jogosultsag = value; }
        }

        #endregion

        #region Saját (private) methodusok (függvények)

        private void userLoad()
        {
            if (jogosultsag != "1")
                dolgozókSzerintToolStripMenuItem.Enabled = false;

            tableUser_info = bejelentkezes.UserTable;
            if (tableUser_info.Rows.Count > 0)
                this.labelUser.Text = tableUser_info.Rows[0]["dolgozo_nev"].ToString();
        }

        public void usercontrol_VisibleChanged(object sender, EventArgs e)
        {
            object lockObject = new Object();
            lock (lockObject)
            {
                Control cont = (Control)sender;
                panel1.Controls[0].Visible = !cont.Visible;

            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("  Biztosan ki akar lépni!", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlCommand sqlc = new SqlCommand("delete from projekt where id not in(select distinct projekt_id from projekt_tetel)",myconn);
                sqlc.ExecuteNonQuery();
                this.Close();
            }
        }

        #endregion
     
        private void panelBeallit(int par)
        {
            panel1.Controls[0].Visible = false;
            for (int i = 1; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].VisibleChanged -= new EventHandler(usercontrol_VisibleChanged);
                if (par == i)
                    panel1.Controls[i].Visible = true;
                else
                    panel1.Controls[i].Visible = false;
                panel1.Controls[i].VisibleChanged += new EventHandler(usercontrol_VisibleChanged);
            }
        }

        private void újFeladatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!feladat.Visible)
            {
                panelBeallit(1);
            }
        }

        private void feladatKezelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!feladatmod.Visible)
            {
                feladatmod.datTol.Value = feladatmod.datTol.MinDate;
                feladatmod.datIg.Value = DateTime.Today;
                feladatmod.valtozokTorlese();
                panelBeallit(2);
                feladatmod.textKeres.SelectedIndexChanged += new EventHandler(feladatmod.textKeres_SelectedIndexChanged);
            }
        }

        private void dolgozókSzerintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dolgozolist.Visible)
            {
                panelBeallit(3);
            }
        }


        private void cégekSzerintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ceglist.Visible)
            {
                panelBeallit(4);
            }
        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kontaktlist.Visible)
                panelBeallit(5);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!sajatlist.Visible)
            {
                panelBeallit(6);
                sajatlist.adatokBetoltese();
            }
        }

        private void dolgozókToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dolgozoKarb.Visible)
                panelBeallit(7);
        }

        private void projektKeresés_Click(object sender, EventArgs e)
        {
            if (!projektlist.Visible)
                if (jogosultsag == "1")
                    panelBeallit(8);
                else
                    panelBeallit(7);
        }

        private void kódtáblákToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kodTablak.Visible)
                panelBeallit(9);
        }

        private void kontaktszemélyekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kontaktKarb.Visible)
                if (jogosultsag == "1")
                    panelBeallit(10);
                else
                    panelBeallit(8);
        }

        private void kiMitCsináltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!kimitcsinaltlist.Visible)
            {
               panelBeallit(11);
            }
        }

        private void partnerekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!partnerKarb.Visible)
            {
                panelBeallit(12);
            }
        }

    }
}
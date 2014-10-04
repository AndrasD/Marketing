using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Könyvtar.ClassGyujtemeny;
using System.IO;

namespace marketing
{
    public partial class Login : Form
    {
        private Gyujtemeny gyujt = new Gyujtemeny();
        private SqlConnection connection = new SqlConnection();
        private string rendszerconn; // = "Data Source=ANDRAS-PC\\SQLExpress;Initial Catalog=marketing;Integrated Security=True";
        private DataSet dataSet = new DataSet();
        private DataTable tableUser_info = new DataTable();
        private SqlDataAdapter da;
        private DataTable conncetions = new DataTable();

        private string szint;
        private int userId;
        private string defaultDir;

        public Login()
        {
            InitializeComponent();
        }

        #region Tulajdonságok (Get és Set)

        public string Verzio
        {
            set { this.verzio.Text = this.verzio.Text + value; }
        }

        public SqlConnection Connection
        {
            set {this.connection = value;}
            get { return this.connection; }
        }

        public string User
        {
            get { return this.textUser.Text; }
        }

        public string Pwd
        {
            get { return this.textPWD.Text; }
        }

        public DataTable UserTable
        {
            get { return this.tableUser_info; }
        }

        public string Jogosultsag
        {
            get { return this.szint; }
        }

        public int UserId
        {
            get { return this.userId; }
        }

        public string DefaultDir
        {
            get { return this.defaultDir; }
        }

        #endregion

        private void Bejelentkezes_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Refresh();
            if (ConfigFileRead())
            {
                createConnection();
            }
            else
                this.Close();

            panel2.Enabled = true;
            this.textUser.Focus();
        }

        private void rendben_Click(object sender, EventArgs e)
        {
            if (textUser.Text == String.Empty)
            {
                this.textUser.Focus();
                errorProvider.SetError(textUser, "Adja meg a dolgozó azonosítoját!");
            }
            else if (textUser.Text != String.Empty)
            {
                errorProvider.SetError(textUser, "");

                if (textPWD.Text == String.Empty)
                {
                    this.textPWD.Focus();
                    errorProvider.SetError(textPWD, "Adja meg a jelszavát!");
                }
                else if (textPWD.Text != String.Empty)
                {
                    errorProvider.SetError(textPWD, "");
 //                   if (textUser.Text == "Supervisor" && gyujt.passwordUnCrypt(textPWD.Text) == "Supervisor1963")
                    if (textUser.Text == "Supervisor" && textPWD.Text == "Supervisor1963")
                    {
                        szint = "1";
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else if (userLoad() && tableUser_info.Rows[0]["programok"].ToString().Substring(1, 1) == "1") // használhatja-e a Marketinget
                    {
                        szint = tableUser_info.Rows[0]["szint"].ToString();
                        userId = Convert.ToInt32(tableUser_info.Rows[0]["id"]);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        if (tableUser_info.Rows[0]["programok"].ToString().Substring(1, 1) != "1")
                            MessageBox.Show("Őn nem használhatja ezt a programot.\r\n");
                        else
                            MessageBox.Show("Hibás Dolgozó/Jelszó.\r\n");
                    }
                }
            }
        }

        private bool userLoad()
        {
            textPWD.Text = gyujt.passwordCrypt(textPWD.Text);

            da = new SqlDataAdapter("select * from dolgozo where azonosito = '" + textUser.Text + "' and jelszo = '"+textPWD.Text+"'" , connection);
            da.Fill(dataSet, "tableUser_info");
            tableUser_info = dataSet.Tables["tableUser_info"];

            if (tableUser_info.Rows.Count == 0)
                return false;
            else
                return true;
        }

        private void textPWD_Leave(object sender, EventArgs e)
        {
            //textPWD.Text = gyujt.passwordCrypt(textPWD.Text);
        }

        private void Bejelentkezes_Activated(object sender, EventArgs e)
        {
            textUser.Focus();
        }

        private bool ConfigFileRead()
        {
            StreamWriter sw;
            bool ret = true;

            try
            {
                string sourceDir = Directory.GetCurrentDirectory();
                string sourceFile = sourceDir + "\\sxs_config.ini";
                string dokDir = sourceDir + "\\Dokumentumok";

                if (!File.Exists(sourceFile) || File.ReadAllText(sourceFile) == String.Empty)
                {
                    connection.ConnectionString = rendszerconn;
                    sw = File.CreateText(sourceFile);
                    sw.WriteLine("[SysConnString] := " + connection.ConnectionString);
                    Directory.CreateDirectory(dokDir);
                    sw.WriteLine("[DefaultDir] := "+dokDir+";");
                    sw.Close();
                    ret = true;
                }
                else
                {
                    connection.ConnectionString = gyujt.StringFromConfig("[SysConnString]");
                    rendszerconn = connection.ConnectionString;
                    defaultDir = gyujt.StringFromConfig("[DefaultDir]");
                    ret = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Hiba a path megállapításánál.");
                ret = false;
            }

            return ret;
        }

        private void createConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show("Adatbázis kapcsolódási hiba.\r\n Hibás Dolgozó/Jelszó.\r\n" + connection.ConnectionString + "\r\n" + err.Message);
                this.Close();
            }
        }

    }
}
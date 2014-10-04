using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace marketing
{
    public partial class statuslista : UserControl
    {
        public DataSet dataSet = new DataSet();
        public DataTable tableProjekt = new DataTable();
        public DataTable tableProjektTetel = new DataTable();

        public DataTable tableIrsz = new DataTable();
        public DataTable tableKozt = new DataTable();
        public DataTable tablePartner = new DataTable();
        public DataTable tableFelelos = new DataTable();
        public DataTable tableProfil = new DataTable();
        public DataTable tableHogyan = new DataTable();
        public DataTable tableStatus = new DataTable();
        public DataTable tableBeo = new DataTable();
        public DataTable tableKontakt = new DataTable();
        public DataTable tablePK = new DataTable();

        public SqlDataAdapter da;
        private SqlDataAdapter daProjekt;
        private SqlDataAdapter daProjektTetel;

        public SqlConnection connection = new SqlConnection();
        public int userId;

        private MainForm mainForm;
        private feladatkezeles feladatmod;
        private OpenFileDialog fileBrowse = new OpenFileDialog();
        private string ProjektString;

        private int aktualisSor = 0;
        private string aktID = "";

        public statuslista(MainForm main)
        {
            mainForm = main;
            connection = main.MyConn;
            InitializeComponent();

            if (mainForm.Jogosultsag == "1")
                törlésToolStripMenuItem.Enabled = true;
            else
                törlésToolStripMenuItem.Enabled = false;
        }

        private void statuslista_Load(object sender, EventArgs e)
        {
            mainForm.feladatmod.feladatkezeles_Load(sender,e);

            tableIrsz.Clear();
            da = new SqlDataAdapter("select distinct telepules, sorszam from irszamok where sorszam = 1 or sorszam > 162", connection);
            da.Fill(dataSet, "tableIrsz");
            tableIrsz = dataSet.Tables["tableIrsz"];
            tableIrsz.PrimaryKey = new DataColumn[] { tableIrsz.Columns["sorszam"] };

            tableKozt.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Koztj'", connection);
            da.Fill(dataSet, "tableKozt");
            tableKozt = dataSet.Tables["tableKozt"];
            tableKozt.PrimaryKey = new DataColumn[] { tableKozt.Columns["sorszam"] };

            tableFelelos.Clear();
            da = new SqlDataAdapter("select * from dolgozo", connection);
            da.Fill(dataSet, "tableFelelos");
            tableFelelos = dataSet.Tables["tableFelelos"];
            tableFelelos.PrimaryKey = new DataColumn[] { tableFelelos.Columns["id"] };
        
            tableProfil.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Profil'", connection);
            da.Fill(dataSet, "tableProfil");
            tableProfil = dataSet.Tables["tableProfil"];
            tableProfil.PrimaryKey = new DataColumn[] { tableProfil.Columns["sorszam"] };

            tableHogyan.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Hogyan'", connection);
            da.Fill(dataSet, "tableHogyan");
            tableHogyan = dataSet.Tables["tableHogyan"];
            tableHogyan.PrimaryKey = new DataColumn[] { tableHogyan.Columns["sorszam"] };

            tableStatus.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Status'", connection);
            da.Fill(dataSet, "tableStatus");
            tableStatus = dataSet.Tables["tableStatus"];
            tableStatus.PrimaryKey = new DataColumn[] { tableStatus.Columns["sorszam"] };

            tableBeo.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Beo'", connection);
            da.Fill(dataSet, "tableBeo");
            tableBeo = dataSet.Tables["tableBeo"];
            tableBeo.PrimaryKey = new DataColumn[] { tableBeo.Columns["sorszam"] };

            cbIrsz.DataSource = tableIrsz;
            cbIrsz.DisplayMember = "telepules";
            cbIrsz.ValueMember = "sorszam";

            cbKoztj.DataSource = tableKozt;
            cbKoztj.DisplayMember = "szoveg";
            cbKoztj.ValueMember = "sorszam";

            cbFelelos.DataSource = tableFelelos;
            cbFelelos.DisplayMember = "dolgozo_nev";
            cbFelelos.ValueMember = "id";

            cbProfil.DataSource = tableProfil;
            cbProfil.DisplayMember = "szoveg";
            cbProfil.ValueMember = "sorszam";

            cbHogyan.DataSource = tableHogyan;
            cbHogyan.DisplayMember = "szoveg";
            cbHogyan.ValueMember = "sorszam";

            cbStatus.DataSource = tableStatus;
            cbStatus.DisplayMember = "szoveg";
            cbStatus.ValueMember = "sorszam";

            if (mainForm.Jogosultsag == "1")
                ProjektString = "select a.*, b.kov_kontakt,k.kod as status_kod, m.mid " +
                                "from projekt a left outer join kodtab k on a.status = k.sorszam, projekt_tetel b, (select max(id) as mid, projekt_id as p_id from projekt_tetel group by projekt_id) as m "+
                                "where a.id = b.projekt_id "+
                                "  and m.p_id = a.id "+
                                "  and b.id = m.mid order by azonosito";
                //ProjektString = "select projekt.*, kodtab.kod as status_kod from projekt left outer join kodtab on projekt.status = kodtab.sorszam order by azonosito";
            else
                ProjektString = "select a.*, b.kov_kontakt,k.kod as status_kod, m.mid " +
                                "from projekt a left outer join kodtab k on a.status = k.sorszam, projekt_tetel b, (select max(id) as mid, projekt_id as p_id from projekt_tetel group by projekt_id) as m " +
                                "where a.id = b.projekt_id " +
                                "  and m.p_id = a.id " +
                                "  and b.id = m.mid " +
                                " and (k.kod in('Ajanlat','Bemutatkozas','Megrendelve') or a.status = 0 )" +
                                //" and (k.kod in('Ajanlat','Bemutatkozas','Megrendelve','Elkeszult','Targytalan') or a.status = 0 )"+
                                //" and (b.ajanlat = 1 or b.megrendel = 1) "+
                                " and a.felelos = " + userId.ToString() +" order by b.kov_kontakt desc";

                //ProjektString = "select projekt.*, kodtab.kod as status_kod from projekt left outer join kodtab on projekt.status = kodtab.sorszam where "+
                //                " (kodtab.kod <> 'Elkeszult' or status = 0) and felelos = " + userId.ToString() + " order by azonosito";

            tablakOlvasasa();
            adatokBetoltese();
        }

        private void adatokBetoltese()
        {
            tableProjekt.Clear();
            daProjekt = new SqlDataAdapter(ProjektString, connection);
            daProjekt.Fill(dataSet, "tableProjekt");
            tableProjekt = dataSet.Tables["tableProjekt"];

            dataGV.DataSource = tableProjekt;
            count.Text = tableProjekt.Rows.Count.ToString();
            if (tableProjekt.Rows.Count > 0)
            {
                if (mainForm.ujProjektAzon != "")
                {
                    DataRow[] r = tableProjekt.Select("azonosito = '" + mainForm.ujProjektAzon + "'");
                    if (r.Length > 0)
                    {
                        dataGV.Rows[tableProjekt.Rows.IndexOf(r[0])].Selected = true;
                        projektTolt(tableProjekt.Rows.IndexOf(r[0]));
                        mainForm.ujProjektAzon = "";
                    }
                }
                else
                {
                    projektTolt(0);
                    dataGV.Rows[0].Selected = true;
                }
            }
            else
                aktualisSor = -1;

            dataGV.Focus();
        }


        private void projektTolt(int aktSor)
        {
            aktID = dataGV.Rows[aktSor].Cells["id"].Value.ToString();
            DataRow[] row = tableProjekt.Select(" id = " + aktID);
            valtozokTolt(panel4.Controls, row[0]);

            tableProjektTetel.Clear();
            daProjektTetel = new SqlDataAdapter("select projekt_tetel.*, dolgozo.dolgozo_nev as felelos_nev from projekt_tetel, dolgozo where projekt_id = "
                                   + aktID + " and dolgozo.id = projekt_tetel.felelos order by id desc", connection);
            daProjektTetel.Fill(dataSet, "tableProjektTetel");
            tableProjektTetel = dataSet.Tables["tableProjektTetel"];

            dataGVTetel.DataSource = tableProjektTetel;

            if (tableProjektTetel.Rows.Count > 0)
            {
                DataRow row1 = tableProjektTetel.Rows[0];
                valtozokTolt(panel5.Controls, row1);
                //DataRow pr = tableKontakt.Rows.Find(row1["kontakt_id"].ToString());

                //cbPartner.SelectedIndex = searchCombo(pr,"pid",tablePartner);
                //cbNev.SelectedIndex = searchCombo(pr, "id", tableKontakt);
                //cbNev.Text = pr["nev"].ToString();
                //cbBeo.SelectedIndex = searchCombo(pr,"beo",tableBeo);
                //textTelefon.Text = pr["telefon"].ToString();
                //textFax.Text = pr["fax"].ToString();
                //textMobil.Text = pr["mobil"].ToString();
                //textEmail.Text = pr["email"].ToString();
            }

            tablePK.Clear();
            da = new SqlDataAdapter("select a.*, c.irsz as partner_irsz, c.telepules, b.pkozt as partner_kozt, b.pkoztj as partner_koztj, b.phazsz as partner_hazsz from view_projekt_kontakt a left outer join partner b on a.pid=b.pid left outer join irszamok c on b.pirsz=c.sorszam where projekt_id = " + aktID, connection);
            da.Fill(dataSet, "tablePK");
            tablePK = dataSet.Tables["tablePK"];
            dataGVKontakt.DataSource = tablePK;
        }

        private void valtozokTolt(ControlCollection con, DataRow row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "TextBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((TextBox)con[i]).Text = row[(string)con[i].Tag].ToString();
                if (con[i].GetType().Name == "ComboBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((ComboBox)con[i]).SelectedIndex = searchCombo(row, (string)con[i].Tag, ((ComboBox)con[i]).DataSource);
                if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((CheckBox)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag]);
                if (con[i].GetType().Name == "DateTimePicker" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((DateTimePicker)con[i]).Value = Convert.ToDateTime(row[(string)con[i].Tag].ToString());
                if (con[i].GetType().Name == "RadioButton" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((RadioButton)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag]);
            }
        }

        public int searchCombo(DataRow r, string t, object tab)
        {
            int ret = -1;
            DataTable table = ((DataTable)tab);
            ret = table.Rows.IndexOf(table.Rows.Find(r[t]));
            return ret;
        }

        private void dataGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                aktualisSor = e.RowIndex;
                projektTolt(aktualisSor);
            }
        }

        private void dataGVTetel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRow row1 = tableProjektTetel.Rows[e.RowIndex];
                valtozokTolt(panel5.Controls, row1);
                //DataRow pr = tableKontakt.Rows.Find(row1["kontakt_id"].ToString());

                //cbPartner.SelectedIndex = searchCombo(pr, "pid", tablePartner);
                //cbNev.SelectedIndex = searchCombo(pr, "id", tableKontakt);
                //cbNev.Text = pr["nev"].ToString();
                //cbBeo.SelectedIndex = searchCombo(pr, "beo", tableBeo);
                //textTelefon.Text = pr["telefon"].ToString();
                //textFax.Text = pr["fax"].ToString();
                //textMobil.Text = pr["mobil"].ToString();
                //textEmail.Text = pr["email"].ToString();
            }
        }

        private void módosításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.feladatmod.datTol.Value = Convert.ToDateTime(dataGV.CurrentRow.Cells["kovkontakt"].Value);
            mainForm.feladatmod.datIg.Value = Convert.ToDateTime(dataGV.CurrentRow.Cells["kovkontakt"].Value);
            mainForm.feladatmod.textKeres.Text = dataGV.CurrentRow.Cells["azonosito"].Value.ToString();
            //mainForm.feladatmod.textKeres.SelectedValue = dataGV.CurrentRow.Cells["id"].Value;
            mainForm.feladatmod.buttonKeres_Click(sender, e);
            mainForm.panel1.Controls[1].VisibleChanged -= new EventHandler(mainForm.usercontrol_VisibleChanged);
            mainForm.panel1.Controls[2].VisibleChanged -= new EventHandler(mainForm.usercontrol_VisibleChanged);
            mainForm.panel1.Controls[0].Visible = false;
            mainForm.panel1.Controls[1].Visible = false;
            this.Visible = false;
            mainForm.panel1.Controls[2].Visible = true;
            mainForm.panel1.Controls[1].VisibleChanged += new EventHandler(mainForm.usercontrol_VisibleChanged);
            mainForm.panel1.Controls[2].VisibleChanged += new EventHandler(mainForm.usercontrol_VisibleChanged);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fileBrowse.Reset();
            fileBrowse.Multiselect = true;
            if (textPath.Text == "")
                fileBrowse.InitialDirectory = mainForm.defaultDir;
            else
                fileBrowse.InitialDirectory = textPath.Text;
            if (fileBrowse.ShowDialog() == DialogResult.OK)
            {
                int li = fileBrowse.FileName.LastIndexOf("\\");
                textPath.Text = fileBrowse.FileName.Substring(0, li);
            }

        }

        private void tablakOlvasasa()
        {
            tablePartner.Clear();
            da = new SqlDataAdapter("select * from partner order by pid", connection);
            da.Fill(dataSet, "tablePartner");
            tablePartner = dataSet.Tables["tablePartner"];
            tablePartner.PrimaryKey = new DataColumn[] { tablePartner.Columns["pid"] };

            tableKontakt.Clear();
            da = new SqlDataAdapter("select * from kontakt order by id", connection);
            da.Fill(dataSet, "tableKontakt");
            tableKontakt = dataSet.Tables["tableKontakt"];
            tableKontakt.PrimaryKey = new DataColumn[] { tableKontakt.Columns["id"] };
        }

        private void buttonFrissit_Click(object sender, EventArgs e)
        {
            tablakOlvasasa();
            adatokBetoltese();
            //mainForm.ceglist.lekerdezesekLista_Load(sender, e);
            //mainForm.kontaktlist.lekerdezesekLista_Load(sender, e);
        }

        private void frissítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablakOlvasasa();
            adatokBetoltese();
        }

        private void statuslista_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                dataGV.Focus();
                if (dataGV.RowCount > 0)
                {
                    if (mainForm.ujProjektAzon != "")
                    {
                        adatokBetoltese();
                    }
                    else
                        projektTolt(aktualisSor);
                }
            }
        }

        private void dataGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DateTime dt = Convert.ToDateTime(dataGV.Rows[e.RowIndex].Cells["kovkontakt"].Value);
                int dtDiff = Convert.ToInt32((DateTime.Today - dt).Days);

                if (dataGV.Rows[e.RowIndex].Cells["status"].Value.ToString() == "Elkeszult" || dataGV.Rows[e.RowIndex].Cells["status"].Value.ToString() == "Targytalan")
                {
                }
                else if (dtDiff > 1  )
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (dtDiff > 0)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                }
            }

        }

        private void dataGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                aktualisSor = e.RowIndex;
                projektTolt(aktualisSor);
            }
            módosításToolStripMenuItem_Click(sender, (EventArgs)e);
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aktualisSor > -1)
            {
                if (MessageBox.Show("Biztosan törölni akarja ezt a projektet? \n" + dataGV.Rows[aktualisSor].Cells["azonosito"].Value.ToString()
                      , "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string queryString = "Delete from projekt_tetel where projekt_id = "+dataGV.Rows[aktualisSor].Cells["id"].Value.ToString()+";";
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, con);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    queryString = "Delete from projekt where id = " + dataGV.Rows[aktualisSor].Cells["id"].Value.ToString() + ";";
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, con);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    adatokBetoltese();
                }
            }

        }

        private void textBox11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = "http://"+textBox11.Text.Trim().Replace("http://","");
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
            procFormsBuilder.Start();

        }

    }
}

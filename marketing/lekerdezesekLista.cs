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
    public partial class lekerdezesekLista : UserControl
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

        public DataTable tableCeg = new DataTable();
        public DataTable tableDolgozo = new DataTable();
        public DataTable tableContact = new DataTable();

        public SqlDataAdapter da;

        public SqlConnection connection = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public int userId;

        private MainForm mainForm;
        private OpenFileDialog fileBrowse;
        private string ProjektString;

        private int aktualisSor = 0;
        private string aktID = "";
        public string aktLekerdezes = "";
        private string sel = "";

        private printForm pForm = new printForm();

        public lekerdezesekLista(MainForm main, string aktLek)
        {
            mainForm = main;
            connection = main.MyConn;
            aktLekerdezes = aktLek;
            InitializeComponent();
        }

        public void lekerdezesekLista_Load(object sender, EventArgs e)
        {
            cmd.CommandText = "select min(letrehozas_datuma) from projekt_tetel";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            dateTol.Value = Convert.ToDateTime(cmd.ExecuteScalar());

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

            tableCeg.Clear();
            da = new SqlDataAdapter("select 0 as pid, ' Válasszon..' as azonosito from partner union select pid, azonosito from partner order by azonosito", connection);
            da.Fill(dataSet, "tableCeg");
            tableCeg = dataSet.Tables["tableCeg"];
            tableCeg.PrimaryKey = new DataColumn[] { tableCeg.Columns["id"] };

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

            tableDolgozo.Clear();
            da = new SqlDataAdapter("select 0 as id, 'Válasszon..' as dolgozo_nev from dolgozo union select id, dolgozo_nev from dolgozo", connection);
            da.Fill(dataSet, "tableDolgozo");
            tableDolgozo = dataSet.Tables["tableDolgozo"];
            tableDolgozo.PrimaryKey = new DataColumn[] { tableDolgozo.Columns["id"] };

            tableContact.Clear();
            da = new SqlDataAdapter("select 0 as id, ' Válasszon..' as nev from kontakt union select id, nev from kontakt order by nev", connection);
            da.Fill(dataSet, "tableContact");
            tableContact = dataSet.Tables["tableContact"];
            tableContact.PrimaryKey = new DataColumn[] { tableContact.Columns["id"] };

            cbIrsz.DataSource = tableIrsz;
            cbIrsz.DisplayMember = "telepules";
            cbIrsz.ValueMember = "sorszam";

            cbKoztj.DataSource = tableKozt;
            cbKoztj.DisplayMember = "szoveg";
            cbKoztj.ValueMember = "sorszam";

            cbFelelos.DataSource = tableFelelos;
            cbFelelos.DisplayMember = "dolgozo_nev";
            cbFelelos.ValueMember = "id";

            comboBox1.DataSource = tableFelelos;
            comboBox1.DisplayMember = "dolgozo_nev";
            comboBox1.ValueMember = "id";

            cbProfil.DataSource = tableProfil;
            cbProfil.DisplayMember = "szoveg";
            cbProfil.ValueMember = "sorszam";

            cbHogyan.DataSource = tableHogyan;
            cbHogyan.DisplayMember = "szoveg";
            cbHogyan.ValueMember = "sorszam";

            cbStatus.DataSource = tableStatus;
            cbStatus.DisplayMember = "szoveg";
            cbStatus.ValueMember = "sorszam";

            caseFunkcio();

            tablakOlvasasa();
        }

        private void caseFunkcio()
        {
            switch (aktLekerdezes)
            {
                case "ceg":
                    toolStripLabel1.Text = "Partner:";
                    label1.Text = "Cégek feladatai";
                    cbKeres.DataSource = tableCeg;
                    cbKeres.DisplayMember = "azonosito";
                    cbKeres.ValueMember = "pid";
                    sel = "(select distinct a.id " +
                              " from projekt a, " +
                              "      projekt_kontakt c, " +
                              "      kontakt d " +
                              " where a.id = c.projekt_id " +
                              "   and c.kontakt_id = d.id " +
                              "   and d.pid in( " + searchCombo(cbKeres.Text, tableCeg) + ")) ";
                    break;
                case "dolgozo":
                    toolStripLabel1.Text = "Dolgozó:";
                    label1.Text = "Dolgozó feladatai";
                    cbKeres.DataSource = tableDolgozo;
                    cbKeres.DisplayMember = "dolgozo_nev";
                    cbKeres.ValueMember = "id";
                    sel = "(select distinct a.id " +
                                 " from projekt a " +
                                 " where a.felelos in( " + searchCombo(cbKeres.Text, tableDolgozo) + ")) ";
                    break;
                case "kontakt":
                    toolStripLabel1.Text = "Kontakt:";
                    label1.Text = "Kontakt személyek feladatai";
                    cbKeres.DataSource = tableContact;
                    cbKeres.DisplayMember = "nev";
                    cbKeres.ValueMember = "id";
                    sel = "(select distinct a.id " +
                        " from projekt a, " +
                        "      projekt_kontakt b " +
                        " where a.id = b.projekt_id " +
                        "   and b.kontakt_id in( " + searchCombo(cbKeres.Text, tableContact) + ")) ";
                    break;
                case "sajat":
                    toolStripLabel1.Visible = false;
                    label1.Text = "Saját projektjeim";
                    cbKeres.Visible = false;
                    sel = "(select distinct a.id " +
                        " from projekt a, " +
                        "      projekt_tetel b " +
                        " where a.id = b.projekt_id " +
                        "   and a.felelos = " + userId.ToString() + ") ";
                    break;
                case "projekt":
                    toolStripLabel1.Text = "Szöveg:";
                    label1.Text = "Projekt keresés";
                    cbKeres.Visible = false;
                    searchText.Visible = true;
                    if (searchText.Text.IndexOf("id=") == 0)
                        sel = "(select id " +
                           " from projekt " +
                           " where id = " + searchText.Text.Substring(searchText.Text.IndexOf("id=")+3) + ") ";
                    else
                        sel = "(select distinct id " +
                            " from view_projekt " +
                            " where coalesce(rtrim(azonosito),' ')+' '+coalesce(rtrim(feladat),' ')+' '+coalesce(rtrim(dolgozo_nev),' ')+' '+coalesce(rtrim(nev),' ')+' '+coalesce(rtrim(partner_azonosito),' ')+' '+coalesce(rtrim(megjegyzes),' ') like '%"
                            +searchText.Text.Trim() +"%') ";
                    break;
                case "kimit":
                    toolStripLabel1.Text = "Dolgozó:";
                    label1.Text = "Ki mit csinált";
                    cbKeres.DataSource = tableDolgozo;
                    buttonPrint.Enabled = true;
                    dTol.Visible = true;
                    dIg.Visible = true;
                    dateTol.Visible = true;
                    dateIg.Visible = true;
                    cbKeres.DisplayMember = "dolgozo_nev";
                    cbKeres.ValueMember = "id";
                    sel = "(select distinct a.id " +
                                 " from projekt a, " +
                                 "      projekt_tetel b " +
                                 " where a.id = b.projekt_id " +
                                 "   and a.felelos in( " + searchCombo(cbKeres.Text, tableDolgozo) + ")" +
                                 "   and (((substring(convert(char, b.letrehozas_datuma, 102),1,10) >= '" + dateTol.Value.ToShortDateString() + "'"+
                                 "         and substring(convert(char, b.letrehozas_datuma, 102),1,10) <= '" + dateIg.Value.ToShortDateString() + "')) " +
                                 "        or "+
                                 "        (substring(convert(char, a.indit, 102),1,10) >= '" + dateTol.Value.ToShortDateString() + "'"+
                                 "         and substring(convert(char, a.indit, 102),1,10) <= '" + dateIg.Value.ToShortDateString() + "'))) ";
                    break;
                default:
                    break;
            }
        }

        public void adatokBetoltese()
        {
            caseFunkcio();
            ProjektString = "select a.*, b.kov_kontakt, k.kod as status_kod, m.mid, b.megjegyzes, b.letrehozas_datuma as utolso_mod " +
                            "from projekt a left outer join kodtab k on a.status = k.sorszam, " +
                            "     projekt_tetel b, " +
                            "     (select max(id) as mid, projekt_id as p_id from projekt_tetel group by projekt_id) as m " +
                            "where a.id = b.projekt_id " +
                            "  and m.p_id = a.id " +
                            "  and b.id = m.mid " +
                            "  and a.id in " + sel +
                            "order by azonosito";

            tableProjekt.Clear();
            da = new SqlDataAdapter(ProjektString, connection);
            try
            {
                da.Fill(dataSet, "tableProjekt");
                tableProjekt = dataSet.Tables["tableProjekt"];

                dataGV.DataSource = tableProjekt;
                count.Text = tableProjekt.Rows.Count.ToString();
                if (tableProjekt.Rows.Count > 0)
                {
                    projektTolt(0);
                    dataGV.Rows[0].Selected = true;
                    aktualisSor = 0;
                }
                else
                {
                    tableProjektTetel.Clear();
                    tablePK.Clear();
                    aktualisSor = -1;
                }

                //dataGV.Focus();
            }
            catch
            {
                MessageBox.Show(" A keresési feltétel hibás! ");
            }
        }


        private void projektTolt(int aktSor)
        {
            aktID = dataGV.Rows[aktSor].Cells["id"].Value.ToString();
            DataRow[] row = tableProjekt.Select(" id = " + aktID);
            valtozokTolt(tabProjekt.Controls, row[0]);

            tableProjektTetel.Clear();
            da = new SqlDataAdapter("select projekt_tetel.*, dolgozo.dolgozo_nev as felelos_nev from projekt_tetel left outer join dolgozo on dolgozo.id = projekt_tetel.felelos where projekt_id = "
                                   + aktID + " order by id desc", connection);
            da.Fill(dataSet, "tableProjektTetel");
            tableProjektTetel = dataSet.Tables["tableProjektTetel"];

            dataGVTetel.DataSource = tableProjektTetel;

            DataRow row1 = tableProjektTetel.Rows[0];
            valtozokTolt(splitContainer2.Panel2.Controls, row1);
            megjegyzesTolt(textBox2);
            DataRow pr = tableKontakt.Rows.Find(row1["kontakt_id"].ToString());

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

        private void megjegyzesTolt(object obj)
        {
            TextBox t = (TextBox)obj;
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            dt = tableProjektTetel.Copy();
            dv.Table = dt;
            dv.Sort = "id";
            t.Text = "";
            for (int i = 0; i < dv.Count; i++)
            {
                if (Convert.ToInt32(dv[i]["id"].ToString()) > 2591)
                    t.Text = t.Text + dv[i]["megjegyzes"].ToString() + "\r\n";
                else
                    t.Text = dv[i]["megjegyzes"].ToString() + "\r\n";
            }
        }

        public int searchCombo(DataRow r, string t, object tab)
        {
            int ret = -1;
            DataTable table = ((DataTable)tab);
            ret = table.Rows.IndexOf(table.Rows.Find(r[t]));
            return ret;
        }

        public string searchCombo(string t, object tab)
        {
            string ret = "";
            DataTable table = ((DataTable)tab);
            DataRow[] row = table.Select(cbKeres.DisplayMember + " like '"+ t +"'");
            for (int i = 0; i < row.Length; i++)
            {
                ret = ret + row[i][cbKeres.ValueMember].ToString();
                if (i + 1 < row.Length)
                    ret = ret + ",";

            }
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
                string id = dataGVTetel.Rows[e.RowIndex].Cells["tid"].Value.ToString();
                DataRow row1 = tableProjektTetel.Select("id = '" + id + "'")[0];
                valtozokTolt(splitContainer2.Panel2.Controls, row1);
                //megjegyzesTolt(textBox1);
                DataRow pr = tableKontakt.Rows.Find(row1["kontakt_id"].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileBrowse == null)
                fileBrowse = new OpenFileDialog();
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

        public void cbKeres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKeres.SelectedIndex > 0)
            {
                adatokBetoltese();
            }
            else
            {
                tableProjekt.Clear();
                tableProjektTetel.Clear();
            }

        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cbKeres_Leave(object sender, EventArgs e)
        {
            adatokBetoltese();
        }

        private void searchText_Leave(object sender, EventArgs e)
        {
            adatokBetoltese();
        }

        private void dataGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mainForm.feladatmod.datTol.Value = Convert.ToDateTime(dataGV.CurrentRow.Cells["kovkontakt"].Value);
            mainForm.feladatmod.datIg.Value = Convert.ToDateTime(dataGV.CurrentRow.Cells["kovkontakt"].Value);
            mainForm.feladatmod.textKeres.Text = dataGV.CurrentRow.Cells["azonosito"].Value.ToString();
            mainForm.feladatmod.buttonKeres_Click(sender, e);
            //mainForm.panel1.Controls["lekerdezesekLista"].VisibleChanged -= new EventHandler(mainForm.usercontrol_VisibleChanged);
            //mainForm.panel1.Controls["feladatkezeles"].VisibleChanged -= new EventHandler(mainForm.usercontrol_VisibleChanged);
            //this.Visible = false;
            mainForm.panel1.Controls["feladatkezeles"].Visible = true;
            //mainForm.panel1.Controls["lekerdezesekLista"].VisibleChanged += new EventHandler(mainForm.usercontrol_VisibleChanged);
            //mainForm.panel1.Controls["feladatkezeles"].VisibleChanged += new EventHandler(mainForm.usercontrol_VisibleChanged);
        }

        private void dateTol_ValueChanged(object sender, EventArgs e)
        {
            if (cbKeres.SelectedIndex > 0)
            {
                adatokBetoltese();
            }
            else
            {
                tableProjekt.Clear();
                tableProjektTetel.Clear();
            }
        }

        private void dateIg_ValueChanged(object sender, EventArgs e)
        {
            if (cbKeres.SelectedIndex > 0)
            {
                adatokBetoltese();
            }
            else
            {
                tableProjekt.Clear();
                tableProjektTetel.Clear();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            pForm.reportSet(tableProjekt,connection,dateTol.Value,dateIg.Value,cbKeres.Text);
            pForm.ShowDialog();
        }

        private void textBox11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = "http://" + textBox11.Text.Trim().Replace("http://", "");
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
            procFormsBuilder.Start();
        }
    }
}

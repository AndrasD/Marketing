using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace marketing
{
    public partial class ujfeladat : UserControl
    {
        public DataSet dataSet = new DataSet();
        public DataTable tableIrsz = new DataTable();
        public DataTable tableKozt = new DataTable();
        public DataTable tablePartner = new DataTable();
        public DataTable tableFelelos = new DataTable();
        public DataTable tableProfil = new DataTable();
        public DataTable tableHogyan = new DataTable();
        public DataTable tableStatus = new DataTable();
        public DataTable tableBeo = new DataTable();
        public DataTable tableProjekt = new DataTable();
        public DataTable tableProjektTetel = new DataTable();
        public DataTable tableKontakt = new DataTable();
        public DataTable viewProjekt = new DataTable();
        public DataTable viewKontakt = new DataTable();
        public DataTable viewPartner = new DataTable();

        public DataTable tablePK = new DataTable();
        public DataTable tableProjektKontakt = new DataTable();

        public SqlDataAdapter da;
        public SqlDataAdapter daProjekt;
        public SqlDataAdapter daProjektTetel;
        public SqlDataAdapter daKontakt;
        public SqlDataAdapter daPartner;
        public SqlCommandBuilder cbProjekt;
        public SqlCommandBuilder cbProjektTetel;
        public SqlCommandBuilder cbKontakt;
        public SqlCommandBuilder cbPartner;

        public SqlDataAdapter daProjektKontakt;
        public SqlCommandBuilder cbProjektKontakt;

        public SqlConnection connection = new SqlConnection();
        public string defaultDir;

        private tisztito Tisztito;

        public int _selectedIndex = -1;
        public int _selectedKontakt = -1;

        private MainForm mF = new MainForm();

        public ujfeladat(MainForm mainForm)
        {
            connection = mainForm.MyConn;
            defaultDir = mainForm.defaultDir;
            mF = mainForm;
            InitializeComponent();
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            valtozokTor(groupBox1.Controls);
            valtozokTor(Tisztito.Controls);
            valtozokTor(Tisztito.groupBox4.Controls);
            valtozokTor(Tisztito.groupBox5.Controls);
            valtozokTor(Tisztito.groupBox6.Controls);
            tablePK.Clear();
        }

        public void ujfeladat_Load(object sender, EventArgs e)
        {
            valtozokTor(groupBox1.Controls);

            mF.ujProjektAzon = "";

            tableProjekt.Clear();
            daProjekt = new SqlDataAdapter("select * from projekt", connection);
            cbProjekt = new SqlCommandBuilder(daProjekt);
            daProjekt.Fill(dataSet, "tableProjekt");
            tableProjekt = dataSet.Tables["tableProjekt"];
            tableProjekt.PrimaryKey = new DataColumn[] { tableProjekt.Columns["azonosito"] };

            tableProjektTetel.Clear();
            daProjektTetel = new SqlDataAdapter("select * from projekt_tetel where id is null", connection);
            cbProjektTetel = new SqlCommandBuilder(daProjektTetel);
            daProjektTetel.Fill(dataSet, "tableProjektTetel");
            tableProjektTetel = dataSet.Tables["tableProjektTetel"];

            da = new SqlDataAdapter("select distinct telepules, sorszam from irszamok where sorszam = 1 or sorszam > 162", connection);
            tableIrsz.Clear();
            da.Fill(dataSet, "tableIrsz");
            tableIrsz = dataSet.Tables["tableIrsz"];
            tableIrsz.PrimaryKey = new DataColumn[] { tableIrsz.Columns["sorszam"] };

            tablePartner.Clear();
            daPartner = new SqlDataAdapter("select * from partner order by azonosito", connection);
            cbPartner = new SqlCommandBuilder(daPartner);
            daPartner.Fill(dataSet, "tablePartner");
            tablePartner = dataSet.Tables["tablePartner"];

            viewPartner.Clear();
            da = new SqlDataAdapter("select * from partner order by azonosito", connection);
            da.Fill(dataSet, "viewPartner");
            viewPartner = dataSet.Tables["viewPartner"];
            viewPartner.PrimaryKey = new DataColumn[] { viewPartner.Columns["pid"] };

            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Koztj'", connection);
            tableKozt.Clear();
            da.Fill(dataSet, "tableKozt");
            tableKozt = dataSet.Tables["tableKozt"];
            tableKozt.PrimaryKey = new DataColumn[] { tableKozt.Columns["sorszam"] };

            da = new SqlDataAdapter("select * from dolgozo", connection);
            tableFelelos.Clear();
            da.Fill(dataSet, "tableFelelos");
            tableFelelos = dataSet.Tables["tableFelelos"];

            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Profil'", connection);
            tableProfil.Clear();
            da.Fill(dataSet, "tableProfil");
            tableProfil = dataSet.Tables["tableProfil"];
            tableProfil.PrimaryKey = new DataColumn[] { tableProfil.Columns["sorszam"] };

            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Hogyan'", connection);
            tableHogyan.Clear();
            da.Fill(dataSet, "tableHogyan");
            tableHogyan = dataSet.Tables["tableHogyan"];
            tableHogyan.PrimaryKey = new DataColumn[] { tableHogyan.Columns["sorszam"] };

            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Status'", connection);
            tableStatus.Clear();
            da.Fill(dataSet, "tableStatus");
            tableStatus = dataSet.Tables["tableStatus"];
            tableStatus.PrimaryKey = new DataColumn[] { tableStatus.Columns["sorszam"] };

            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Beo' order by szoveg", connection);
            tableBeo.Clear();
            da.Fill(dataSet, "tableBeo");
            tableBeo = dataSet.Tables["tableBeo"];
            tableBeo.PrimaryKey = new DataColumn[] { tableBeo.Columns["sorszam"] };

            tableKontakt.Clear();
            daKontakt = new SqlDataAdapter("select * from kontakt order by nev", connection);
            cbKontakt = new SqlCommandBuilder(daKontakt);
            daKontakt.Fill(dataSet, "tableKontakt");
            tableKontakt = dataSet.Tables["tableKontakt"];
            //tableKontakt.PrimaryKey = new DataColumn[] { tableKontakt.Columns["id"] };

            //da = new SqlDataAdapter("select kontakt.*, kontakt.nev+'      Cég:'+partner.azonosito as megjelenit, partner.azonosito from kontakt, partner where kontakt.pid = partner.pid order by megjelenit", connection);
            da = new SqlDataAdapter("select * from kontakt order by nev", connection);
            viewKontakt.Clear();
            da.Fill(dataSet, "viewKontakt");
            viewKontakt = dataSet.Tables["viewKontakt"];
            viewKontakt.PrimaryKey = new DataColumn[] { viewKontakt.Columns["id"] };

            tablePK.Clear();
            da = new SqlDataAdapter("select * from view_projekt_kontakt where projekt_id = 0", connection);
            da.Fill(dataSet, "tablePK");
            tablePK = dataSet.Tables["tablePK"];

            tableProjektKontakt.Clear();
            daProjektKontakt = new SqlDataAdapter("select * from projekt_kontakt where projekt_id = 0", connection);
            cbProjektKontakt = new SqlCommandBuilder(daProjektKontakt);
            daProjektKontakt.Fill(dataSet, "tableProjektKontakt");
            tableProjektKontakt = dataSet.Tables["tableProjektKontakt"];

            _selectedIndex = -1;
            if (tableProjektKontakt.Rows.Count > 0)
            {
                _selectedKontakt = 0;
            }

            Tisztito = new tisztito(this);
            panel3.Controls.Add(Tisztito);
            panel3.Controls[0].Visible = false;
            panel3.Controls[0].Dock = DockStyle.Fill;

            panel3.Controls[0].Visible = true;
            valtozokTor(Tisztito.Controls);
            valtozokTor(Tisztito.groupBox4.Controls);
            valtozokTor(Tisztito.groupBox5.Controls);
            valtozokTor(Tisztito.groupBox6.Controls);

            Tisztito.dataGVKontakt.DataSource = tablePK;

        }

        public void valtozokTor(ControlCollection con)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "TextBox" && con[i].Tag != null)
                    ((TextBox)con[i]).Text = String.Empty;
                if (con[i].GetType().Name == "ComboBox" && con[i].Tag != null)
                    ((ComboBox)con[i]).SelectedIndex = -1;
                if (con[i].GetType().Name == "CheckBox" && con[i].Tag != null)
                    ((CheckBox)con[i]).Checked = false;
                if (con[i].GetType().Name == "DateTimePicker" && con[i].Tag != null)
                    ((DateTimePicker)con[i]).Value = DateTime.Now;
                if (con[i].GetType().Name == "RadioButton" && con[i].Tag != null)
                    ((RadioButton)con[i]).Checked = false;
            }
        }

        public void valtozokTolt(ControlCollection con, DataRow row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "TextBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((TextBox)con[i]).Text = row[(string)con[i].Tag].ToString();
                if (con[i].GetType().Name == "ComboBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    if (row[(string)con[i].Tag].ToString() == "")
                        ((ComboBox)con[i]).SelectedIndex = -1;
                    else
                        ((ComboBox)con[i]).SelectedIndex = searchCombo(row, (string)con[i].Tag, ((ComboBox)con[i]).DataSource);
                if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((CheckBox)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag].ToString());
                if (con[i].GetType().Name == "DateTimePicker" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((DateTimePicker)con[i]).Value = Convert.ToDateTime(row[(string)con[i].Tag].ToString());
                if (con[i].GetType().Name == "RadioButton" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((RadioButton)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag].ToString());
            }
        }

        public int searchCombo(DataRow r, string t, object tab)
        {
            int ret = -1;
            DataTable table = ((DataTable)tab);
            ret = table.Rows.IndexOf(table.Rows.Find(r[t]));
            return ret;
        }

        public void valtozokMent(ControlCollection con, DataRow row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].Tag != null)
                {
                    if (con[i].GetType().Name == "TextBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                        row[(string)con[i].Tag] = ((TextBox)con[i]).Text;
                    if (con[i].GetType().Name == "ComboBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                        row[(string)con[i].Tag] = Convert.ToInt32(((ComboBox)con[i]).SelectedValue);
                    if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                        row[(string)con[i].Tag] = Convert.ToInt32(((CheckBox)con[i]).Checked);
                    if (con[i].GetType().Name == "DateTimePicker" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                        row[(string)con[i].Tag] = ((DateTimePicker)con[i]).Value.ToShortDateString();
                    if (con[i].GetType().Name == "RadioButton" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                        row[(string)con[i].Tag] = Convert.ToInt32(((RadioButton)con[i]).Checked);
                }
            }
        }

        private void tisztito_CheckedChanged(object sender, EventArgs e)
        {
            //if (tisztito.Checked)
            //{
            //    panel3.Controls[0].Visible = true;
            //    valtozokTor(Tisztito.Controls);
            //    valtozokTor(Tisztito.groupBox4.Controls);
            //    valtozokTor(Tisztito.groupBox5.Controls);
            //    valtozokTor(Tisztito.groupBox6.Controls);
            //}
            //else
            //    panel3.Controls[0].Visible = false;
        }

        private bool ellenorzes()
        {
            bool ret = true;

            if (Tisztito.textAzon.Text.Trim() == String.Empty)
            {
                ret = false;
                MessageBox.Show("Hiányzik a projekt azonosító!");
            }
            else
            {
                DataRow[] row = tableProjekt.Select("azonosito = '" + Tisztito.textAzon.Text.Trim() + "'");
                if (row.Length > 0)
                {
                    MessageBox.Show("Ez az azonosító már létezik!");
                }
            }

            if (Tisztito.cbFelelos.SelectedIndex < 0)
            {
                ret = false;
                MessageBox.Show("Hiányzik a felelős!");
            }

            if (tablePK.Rows.Count == 0)
            {
                ret = false;
                MessageBox.Show("Hiányzik a kontaktszemély!");
            }

            return ret;
        }

        private void buttonMentes_Click(object sender, EventArgs e)
        {
            if (ellenorzes())
            {
                DataRow row = tableProjekt.NewRow();
                valtozokMent(groupBox1.Controls, row);
                valtozokMent(Tisztito.Controls, row);
                valtozokMent(Tisztito.groupBox4.Controls, row);
                valtozokMent(Tisztito.groupBox5.Controls, row);
                valtozokMent(Tisztito.groupBox6.Controls, row);
                tableProjekt.Rows.Add(row);

                try
                {
                    daProjekt.Update(tableProjekt);
                    string azon = row["azonosito"].ToString();
                    tableProjekt.AcceptChanges();
                    tableProjekt.Clear();
                    daProjekt = new SqlDataAdapter("select * from projekt where azonosito = '" + azon + "'", connection);
                    daProjekt.Fill(dataSet, "tableProjekt");
                    cbProjekt = new SqlCommandBuilder(daProjekt);
                    tableProjekt = dataSet.Tables["tableProjekt"];

                    row = tableProjektTetel.NewRow();
                    valtozokMent(groupBox1.Controls, row);
                    valtozokMent(Tisztito.Controls, row);
                    valtozokMent(Tisztito.groupBox4.Controls, row);
                    valtozokMent(Tisztito.groupBox5.Controls, row);
                    valtozokMent(Tisztito.groupBox6.Controls, row);
                    row["projekt_id"] = tableProjekt.Rows[0]["id"];
                    row["kontakt_id"] = 0;
                    tableProjektTetel.Rows.Add(row);

                    daProjektTetel.Update(tableProjektTetel);
                    tableProjektTetel.AcceptChanges();

                    DataRow r;
                    DataRow[] r2;
                    for (int i = 0; i < tablePK.Rows.Count; i++)
                    {
                        if (tablePK.Rows[i].RowState != DataRowState.Deleted)
                        {
                            if (tablePK.Rows[i]["projekt_kontakt_id"].ToString() == "")
                            {
                                r = tableProjektKontakt.NewRow();
                                r["projekt_id"] = tableProjekt.Rows[0]["id"];
                                r["kontakt_id"] = tablePK.Rows[i]["kontakt_id"];
                                tableProjektKontakt.Rows.Add(r);
                            }
                            else
                            {
                                r2 = tableProjektKontakt.Select("id = " + tablePK.Rows[i]["projekt_kontakt_id"].ToString());
                                r = r2[0];
                                r["kontakt_id"] = tablePK.Rows[i]["kontakt_id"];
                            }
                        }
                    }

                    daProjektKontakt.Update(tableProjektKontakt);
                    tableProjektKontakt.AcceptChanges();

                    mF.ujProjektAzon = azon;

                    buttonVissza_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                }
            }
        }

        private void ujfeladat_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    valtozokTor(Tisztito.Controls);
            //    valtozokTor(Tisztito.groupBox4.Controls);
            //    valtozokTor(Tisztito.groupBox5.Controls);
            //    valtozokTor(Tisztito.groupBox6.Controls);
            //}
        }
    }

}

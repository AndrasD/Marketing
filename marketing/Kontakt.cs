using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Könyvtar.ClassGyujtemeny;


namespace marketing
{
    public partial class Kontakt : UserControl
    {
        private Gyujtemeny gyujt = new Gyujtemeny();

        private DataSet dataSet = new DataSet();
        private DataTable tableKontakt = new DataTable();
        private DataView viewKontakt = new DataView();
        private DataTable vKontakt = new DataTable();
        public DataTable tableBeo = new DataTable();
        public DataTable viewPartner = new DataTable();

        private SqlConnection myconn = new SqlConnection();

        private SqlDataAdapter da;
        private SqlDataAdapter daK;
        private SqlCommandBuilder cb;

        private MainForm _mainForm;

        public Kontakt(MainForm mainForm)
        {
            myconn = mainForm.MyConn;
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void Kontakt_Load(object sender, EventArgs e)
        {
            myconn = _mainForm.MyConn;

            //for (int i = 0; i < cegektabla.Rows.Count; i++)
            //    ev.Items.Add(cegek.Rows[i]["ev"].ToString());

            viewPartner.Clear();
            da = new SqlDataAdapter("select * from partner order by azonosito", myconn);
            da.Fill(dataSet, "viewPartner");
            viewPartner = dataSet.Tables["viewPartner"];
            viewPartner.PrimaryKey = new DataColumn[] { viewPartner.Columns["pid"] };

            tableBeo.Clear();
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Beo'", myconn);
            da.Fill(dataSet, "tableBeo");
            tableBeo = dataSet.Tables["tableBeo"];
            tableBeo.PrimaryKey = new DataColumn[] { tableBeo.Columns["sorszam"] };

            cbPartner.DataSource = viewPartner;
            cbBeo.DataSource = tableBeo;

            cbPartner.DisplayMember = "azonosito";
            cbPartner.ValueMember = "pid";

            cbBeo.DisplayMember = "szoveg";
            cbBeo.ValueMember = "sorszam";

            this.kontaktLoad();

            if (tableKontakt.Rows.Count == 0)
            {
                this.buttonUj_Click(sender, e);
                textNev.Focus();
            }
        }

        private void kontaktLoad()
        {
            vKontakt.Clear();
            tableKontakt.Clear();
            daK = new SqlDataAdapter("select a.*, b.szoveg as Beosztas, c.azonosito as Partner "
                                    +"from kontakt a left outer join kodtab b on a.beo=b.sorszam, "
                                    +"partner c "
                                    +"where "
                                    +"a.pid = c.pid", myconn);
            daK.Fill(dataSet, "vKontakt");
            vKontakt = dataSet.Tables["vKontakt"];
            vKontakt.PrimaryKey = new DataColumn[] { vKontakt.Columns["nev"] };

            da = new SqlDataAdapter("SELECT * FROM kontakt order by nev", myconn);
            da.Fill(dataSet, "tableKontakt");
            tableKontakt = dataSet.Tables["tableKontakt"];
            tableKontakt.PrimaryKey = new DataColumn[] { tableKontakt.Columns["nev"] };

            this.viewKontakt.BeginInit();
            this.viewKontakt.Table = vKontakt;
            this.viewKontakt.EndInit();

            dataGV.DataSource = this.viewKontakt;

            cb = new SqlCommandBuilder(da);
        }

        private void buttonUj_Click(object sender, EventArgs e)
        {
            this.textNev.ReadOnly = false;
            variabelClear(this.Controls);
            buttonUj.Enabled = false;
            buttonTorol.Enabled = false;
            textNev.Focus();
        }

        public void valtozokTolt(ControlCollection con, DataRow row)
        {
            _Combo comboValt = new _Combo();
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "TextBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((TextBox)con[i]).Text = row[(string)con[i].Tag].ToString();
                if (con[i].GetType().Name == "ComboBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                {
                    comboValt = searchCombo(row, (string)con[i].Tag, ((ComboBox)con[i]).DataSource, (ComboBox)con[i]);
                    ((ComboBox)con[i]).SelectedIndex = comboValt.index;
                    ((ComboBox)con[i]).SelectedText = comboValt.text;
                    ((ComboBox)con[i]).Text = comboValt.text;
                    ((ComboBox)con[i]).SelectedValue = comboValt.value;
                }
                if (con[i].GetType().Name == "CheckBox" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((CheckBox)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag]);
                if (con[i].GetType().Name == "DateTimePicker" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((DateTimePicker)con[i]).Value = Convert.ToDateTime(row[(string)con[i].Tag].ToString());
                if (con[i].GetType().Name == "RadioButton" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
                    ((RadioButton)con[i]).Checked = Convert.ToBoolean(row[(string)con[i].Tag]);
            }
        }

        public _Combo searchCombo(DataRow r, string t, object tab, ComboBox c)
        {
            _Combo ret = new _Combo();
            DataTable table = ((DataTable)tab);
            string comboNev = c.Name;
            if (table.PrimaryKey.Length > 0)
                ret.index = table.Rows.IndexOf(table.Rows.Find(r[t]));
            else
            {
                DataRow[] row = table.Select(t + " = " + r[t].ToString());
                if (row.Length > 0)
                    ret.index = table.Rows.IndexOf(row[0]);
            }
            if (ret.index > -1)
            {
                ret.text = table.Rows[ret.index][c.DisplayMember].ToString();
                ret.value = table.Rows[ret.index][c.ValueMember];
            }
            else
            {
                ret.text = "";
                ret.value = 0;
            }
            return ret;
        }

        private void variabelClear(Control.ControlCollection con)
        {
            errorProvider.SetError(textNev, "");
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "GroupBox")
                    variabelClear(con[i].Controls);
                if (con[i].Tag != null)
                    con[i].Text = String.Empty;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
        }

        public void valtozokMent(ControlCollection con, DataRow row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].Tag != null && (string)con[i].Tag != "" && row.Table.Columns.IndexOf((string)con[i].Tag) > -1)
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

        private bool mezoValidalas(string mezo)
        {
            bool ret = false;

            if (mezo == "Nev")
            {
                if (textNev.ReadOnly)
                    ret = true;
                else
                {
                    DataRow r = tableKontakt.Rows.Find(textNev.Text);
                    if (textNev.Text == String.Empty)
                    {
                        textNev.Focus();
                        errorProvider.SetError(textNev, "Az nevet legyen szíves megadni.");
                        ret = false;
                    }
                    else if (r != null)
                    {
                        textNev.Focus();
                        errorProvider.SetError(textNev, "Már létezik!");
                        ret = false;
                    }
                    else
                    {
                        errorProvider.SetError(textNev, "");
                        ret = true;
                    }
                }
            }

            return ret;
        }

        private void texNev_Validating(object sender, CancelEventArgs e)
        {
            mezoValidalas("Nev");
        }


        private void dataGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textNev.ReadOnly = true;
                DataRow[] findDolgozo = tableKontakt.Select("nev = '" + dataGV.Rows[e.RowIndex].Cells["nev"].Value + "'");
                if (findDolgozo.Length > 0)
                {
                    valtozokTolt(groupBox1.Controls, findDolgozo[0]);
                    buttonUj.Enabled = true;
                    buttonTorol.Enabled = true;
                    errorProvider.SetError(textNev, "");
                }
            }
        }

        private void buttonTorol_Click(object sender, EventArgs e)
        {
            variabelClear(groupBox1.Controls);
            if (dataGV.SelectedRows.Count > -1)
            {
                DataRow[] row = tableKontakt.Select("nev ='" + dataGV.CurrentRow.Cells["nev"].Value + "'");
                row[0].Delete();
                try
                {
                    da.Update(tableKontakt);
                    tableKontakt.AcceptChanges();
                    row = vKontakt.Select("nev ='" + dataGV.CurrentRow.Cells["nev"].Value + "'");
                    row[0].Delete();
                    da.Fill(dataSet, "tableKontakt");
                    tableKontakt = dataSet.Tables["tableKontakt"];
                    daK.Fill(dataSet, "vKontakt");
                    vKontakt = dataSet.Tables["vKontakt"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                }
            }
        }

        private void buttonVissza_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mehetTovabb = true;
            if (cbPartner.Text == "")
            {
                MessageBox.Show("Hiba üres a partner");
                mehetTovabb = false;
            }
            else if (textNev.Text.Trim() != String.Empty)
            {
                textNev.Text = textNev.Text.Replace('ő', 'ö');
                textNev.Text = textNev.Text.Replace('Ő', 'Ö');
                textNev.Text = textNev.Text.Replace('ű', 'ü');
                textNev.Text = textNev.Text.Replace('Ű', 'Ü');
                if (!textNev.ReadOnly)
                {
                    DataRow[] r = tableKontakt.Select("nev = '" + textNev.Text + "'");
                    if (r.Length > 0)
                    {
                        MessageBox.Show("Ez a személy már létezik!");
                        mehetTovabb = false;
                    }
                }
            }

            if (mehetTovabb && textNev.Text.Trim() != String.Empty)
            {
                DataRow row;

                if (!textNev.ReadOnly)
                    row = tableKontakt.NewRow();
                else
                {
                    DataRow[] r = tableKontakt.Select("nev = '" + textNev.Text + "'");
                    row = r[0];
                }


                valtozokMent(groupBox1.Controls, row);

                if (!textNev.ReadOnly)
                    tableKontakt.Rows.Add(row);

                try
                {
                    da.Update(tableKontakt);
                    tableKontakt.AcceptChanges();
                    da.Fill(dataSet, "tableKontakt");
                    tableKontakt = dataSet.Tables["tableKontakt"];
                    daK.Fill(dataSet, "vKontakt");
                    vKontakt = dataSet.Tables["vKontakt"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Hiba üres a név");
            }

        }

        private void Kontakt_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                kontaktLoad();

        }

        private void filterNev_TextChanged(object sender, EventArgs e)
        {
            viewKontakt.RowFilter = "nev like '"+filterNev.Text.Trim()+"*'";
        }
    }
}


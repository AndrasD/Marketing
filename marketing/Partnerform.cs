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
    public partial class Partnerform : UserControl
    {

        private DataSet dataSet = new DataSet();

        private DataTable tableIrsz = new DataTable();
        private DataTable tableKozt = new DataTable();
        private DataTable tablePartner = new DataTable();
        private DataTable vPartner = new DataTable();
        private DataView viewPartner = new DataView();

        private SqlDataAdapter da;
        private SqlDataAdapter daPartner;
        private SqlCommandBuilder cbPartner;

        private SqlConnection connection = new SqlConnection();

        public Partnerform(MainForm mainForm)
        {
            InitializeComponent();
            connection = mainForm.MyConn;
            fillPartner();
            fillKoztj();
            fillIrsz();
        }

        private void fillPartner()
        {
            tablePartner.Clear();
            daPartner = new SqlDataAdapter("select * from partner order by azonosito", connection);
            cbPartner = new SqlCommandBuilder(daPartner);
            daPartner.Fill(dataSet, "tablePartner");
            tablePartner = dataSet.Tables["tablePartner"];

            vPartner.Clear();
            da = new SqlDataAdapter("SELECT partner.*, irszamok.IRSZ, irszamok.TELEPULES, kodtab.SZOVEG " +
                                    "FROM partner LEFT OUTER JOIN " +
                                    "irszamok ON partner.PIRSZ = irszamok.SORSZAM LEFT OUTER JOIN " +
                                    "kodtab ON partner.PKOZTJ = kodtab.SORSZAM ", connection);
            da.Fill(dataSet, "vPartner");
            vPartner = dataSet.Tables["vPartner"];

            this.viewPartner.BeginInit();
            this.viewPartner.Table = vPartner;
            this.viewPartner.EndInit();

            dataGV.DataSource = viewPartner;
        }

        private void fillKoztj()
        {
            da = new SqlDataAdapter("select * from kodtab where kodtipus = 'Koztj'", connection);
            tableKozt.Clear();
            da.Fill(dataSet, "tableKozt");
            tableKozt = dataSet.Tables["tableKozt"];
            tableKozt.PrimaryKey = new DataColumn[] { tableKozt.Columns["sorszam"] };
            cbKoztj.DataSource = tableKozt;
            cbKoztj.DisplayMember = "szoveg";
            cbKoztj.ValueMember = "sorszam";
        }

        private void fillIrsz()
        {
            da = new SqlDataAdapter("select cast(irsz as char(4))+' '+telepules as telepules, sorszam from irszamok ", connection);
            tableIrsz.Clear();
            da.Fill(dataSet, "tableIrsz");
            tableIrsz = dataSet.Tables["tableIrsz"];
            tableIrsz.PrimaryKey = new DataColumn[] { tableIrsz.Columns["sorszam"] };
            cbIrsz.DataSource = tableIrsz;
            cbIrsz.DisplayMember = "telepules";
            cbIrsz.ValueMember = "sorszam";
        }

        private void dataGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dataGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textNev.ReadOnly = true;
                DataGridViewRow findPartner = dataGV.Rows[e.RowIndex];
                if (findPartner != null)
                {
                    valtozokTolt(panel1.Controls, findPartner);
                    buttonUj.Enabled = true;
                    buttonTorol.Enabled = true;
                }
            }
        }

        public void valtozokTolt(ControlCollection con, DataGridViewRow row)
        {
            _Combo comboValt = new _Combo();
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "TextBox" && row.Cells[(string)con[i].Tag] != null)
                    ((TextBox)con[i]).Text = row.Cells[(string)con[i].Tag].Value.ToString();
                if (con[i].GetType().Name == "ComboBox" && row.Cells[(string)con[i].Tag] != null)
                {
                    comboValt = searchCombo(row, (string)con[i].Tag, ((ComboBox)con[i]).DataSource, (ComboBox)con[i]);
                    ((ComboBox)con[i]).SelectedIndex = comboValt.index;
                    ((ComboBox)con[i]).SelectedText = comboValt.text;
                    ((ComboBox)con[i]).Text = comboValt.text;
                    ((ComboBox)con[i]).SelectedValue = comboValt.value;
                }
                if (con[i].GetType().Name == "CheckBox" && row.Cells[(string)con[i].Tag] != null)
                    ((CheckBox)con[i]).Checked = Convert.ToBoolean(row.Cells[(string)con[i].Tag].Value);
                if (con[i].GetType().Name == "DateTimePicker" && row.Cells[(string)con[i].Tag] != null)
                    ((DateTimePicker)con[i]).Value = Convert.ToDateTime(row.Cells[(string)con[i].Tag].Value.ToString());
                if (con[i].GetType().Name == "RadioButton" && row.Cells[(string)con[i].Tag] != null)
                    ((RadioButton)con[i]).Checked = Convert.ToBoolean(row.Cells[(string)con[i].Tag].Value);
            }
        }

        public _Combo searchCombo(DataGridViewRow r, String t, Object tab, ComboBox c)
        {
            _Combo ret = new _Combo();
            DataTable table = ((DataTable)tab);
            if (table.PrimaryKey.Length > 0 && r.Cells[t].Value.ToString().Length > 0)
                ret.index = table.Rows.IndexOf(table.Rows.Find(r.Cells[t].Value));
            else if (r.Cells[t].Value.ToString().Length > 0)
            {
                DataRow[] row = table.Select(t + " = " + r.Cells[t].Value.ToString());
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

        private void buttonUj_Click(object sender, EventArgs e)
        {
            this.textNev.ReadOnly = false;
            variabelClear(panel1.Controls);
            buttonUj.Enabled = false;
            buttonTorol.Enabled = false;
            buttonMentes.Enabled = false;
            textNev.Focus();
        }

        private void buttonTorol_Click(object sender, EventArgs e)
        {
            if (dataGV.SelectedRows.Count > -1)
            {
                try
                {
                    viewPartner.Delete(dataGV.CurrentRow.Index);
                    DataRow[] row = tablePartner.Select("azonosito ='" + textNev.Text + "'");
                    row[0].Delete();
                    variabelClear(panel1.Controls);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                }
            }
        }

        private void buttonMent_Click(object sender, EventArgs e)
        {
            //this.rendben();
            try
            {
                daPartner.Update(tablePartner);
                tablePartner.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
            }
        }

        private void variabelClear(Control.ControlCollection con)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "GroupBox")
                    variabelClear(con[i].Controls);
                if (con[i].Tag != null)
                    con[i].Text = String.Empty;
            }
        }

        private void filterNev_TextChanged(object sender, EventArgs e)
        {
            viewPartner.RowFilter = "azonosito like '" + filterNev.Text.Trim() + "*'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            variabelClear(panel1.Controls);
            buttonUj.Enabled = true;
            buttonTorol.Enabled = true;
            buttonMentes.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mehetTovabb = true;
            if (textNev.Text == "")
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
                    DataRow[] r = tablePartner.Select("azonosito = '" + textNev.Text + "'");
                    if (r.Length > 0)
                    {
                        MessageBox.Show("Ez a személy már létezik!");
                        mehetTovabb = false;
                    }
                }
            }

            if (mehetTovabb && textNev.Text.Trim() != String.Empty)
            {
                DataRow row, vrow;

                if (!textNev.ReadOnly)
                {
                    row = tablePartner.NewRow();
                    vrow = vPartner.NewRow();
                }
                else
                {
                    DataRow[] r = tablePartner.Select("azonosito = '" + textNev.Text + "'");
                    DataRow[] vr = vPartner.Select("azonosito = '" + textNev.Text + "'");
                   
                    row = r[0];
                    vrow = vr[0];
                }

                valtozokMent(panel1.Controls, row);
                valtozokMent(panel1.Controls, vrow);

                if (!textNev.ReadOnly)
                {
                    tablePartner.Rows.Add(row);
                    vPartner.Rows.Add(vrow);
                }

            }
            else
            {
                MessageBox.Show("Hiba üres a név");
            }
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

        private void cbIrsz_Leave(object sender, EventArgs e)
        {
            textIRSZ.Text = cbIrsz.Text.Substring(0, 4);
            textTelepules.Text = cbIrsz.Text.Substring(4);
        }

        private void cbKoztj_Leave(object sender, EventArgs e)
        {
            textSzoveg.Text = cbKoztj.Text;
        }

        private void buttonFrissit_Click(object sender, EventArgs e)
        {
            fillPartner();
            fillKoztj();
            fillIrsz();
            button2_Click(sender, e);
        }

    }
}

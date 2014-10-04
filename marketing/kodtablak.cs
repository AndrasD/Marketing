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
    public partial class kodtablak : UserControl
    {
        private DataSet dataSet = new DataSet();
        private DataTable tableKodtip = new DataTable();
        private DataTable tableKodtab = new DataTable();
        private DataView viewKodtab = new DataView();

        private SqlConnection myconn = new SqlConnection();

        private SqlDataAdapter da;
        private SqlCommandBuilder cb;

        private MainForm _mainForm;

        public kodtablak(MainForm mainForm)
        {
            myconn = mainForm.MyConn;
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void kodtablak_Load(object sender, EventArgs e)
        {
            myconn = _mainForm.MyConn;

            this.kodtablakLoad();

            if (tableKodtip.Rows.Count == 0)
            {
                this.buttonUj_Click(sender, e);
            }
        }

        private void kodtablakLoad()
        {
            da = new SqlDataAdapter("SELECT distinct kodtipus FROM kodtab where megj = 'M' ", myconn);
            da.Fill(dataSet, "tableKodtip");
            tableKodtip = dataSet.Tables["tableKodtip"];

            da = new SqlDataAdapter("SELECT * FROM kodtab where megj = 'M' ", myconn);
            da.Fill(dataSet, "tableKodtab");
            tableKodtab = dataSet.Tables["tableKodtab"];

            cb = new SqlCommandBuilder(da);

            cbKodtip.DataSource = tableKodtip;
            cbKodtip.DisplayMember = "kodtipus";
            cbKodtip.ValueMember = "kodtipus";

            viewKodtab = new DataView(tableKodtab);
            viewKodtab.RowFilter = ("kodtipus = '" + cbKodtip.Text + "'");
            dataGV.DataSource = viewKodtab;
        }

        private void buttonUj_Click(object sender, EventArgs e)
        {
            this.textKod.ReadOnly = false;
            variabelClear(this.Controls);
            buttonUj.Enabled = false;
            buttonTorol.Enabled = false;
            buttonMentes.Enabled = false;
            textKod.Focus();
        }

        private void variabelLoad(Control.ControlCollection con, DataRow[] row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "GroupBox")
                    variabelLoad(con[i].Controls, row);
                if (con[i].Tag != null)
                    con[i].Text = row[0][(string)con[i].Tag].ToString();
            }
        }

        private void variabelClear(Control.ControlCollection con)
        {
            errorProvider.SetError(textMegnevezes, "");
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
            //this.rendben();
            try
            {
                da.Update(tableKodtab);
                tableKodtab.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
            }
        }

        private void rendben()
        {
            if (mezoValidalas("azonosito") && mezoValidalas("nev") && mezoValidalas("jelszo") && mezoValidalas("szint"))
            {
                string prg = "";

                if (!textKod.ReadOnly)
                {
                    DataRow row = tableKodtab.NewRow();
                    variabelSave(this.Controls, row);
                    tableKodtab.Rows.Add(row);
                    variabelClear(this.Controls);
                }
                else
                {
                    DataRow findDolgozo = tableKodtab.Rows.Find(dataGV.CurrentRow.Cells["azonosito"].Value);
                    variabelSave(this.Controls, findDolgozo);
                }
                buttonUj.Enabled = true;
                buttonTorol.Enabled = true;
                buttonMentes.Enabled = true;
            }
        }

        private void variabelSave(Control.ControlCollection con, DataRow row)
        {
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].GetType().Name == "GroupBox")
                    variabelSave(con[i].Controls, row);
                if (con[i].Tag != null)
                    row[(string)con[i].Tag] = con[i].Text;
            }
        }

        private bool mezoValidalas(string mezo)
        {
            bool ret = false;

            if (mezo == "azonosito")
            {
                if (textKod.ReadOnly)
                    ret = true;
                else
                {
                    DataRow r = tableKodtab.Rows.Find(textKod.Text);
                    if (textKod.Text == String.Empty)
                    {
                        textKod.Focus();
                        errorProvider.SetError(textKod, "Az azonsitót legyen szíves megadni.");
                        ret = false;
                    }
                    else if (r != null)
                    {
                        textKod.Focus();
                        errorProvider.SetError(textKod, "Már létezik!");
                        ret = false;
                    }
                    else
                    {
                        errorProvider.SetError(textKod, "");
                        ret = true;
                    }
                }
            }

            if (mezo == "nev")
            {
                if (textMegnevezes.Text == String.Empty)
                {
                    textMegnevezes.Focus();
                    errorProvider.SetError(textMegnevezes, "A nevet legyen szíves megadni.");
                    ret = false;
                }
                else
                {
                    errorProvider.SetError(textMegnevezes, "");
                    ret = true;
                }
            }

            return ret;
        }

        private void textAzonosito_Validating(object sender, CancelEventArgs e)
        {
            mezoValidalas("azonsoito");
        }

        private void textMegnevezes_Validating(object sender, CancelEventArgs e)
        {
            mezoValidalas("nev");
        }

        private void dataGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textKod.ReadOnly = true;
                DataRow[] findDolgozo = tableKodtab.Select("sorszam = '" + dataGV.Rows[e.RowIndex].Cells["sorszam"].Value + "'");
                variabelLoad(this.Controls, findDolgozo);
                buttonUj.Enabled = true;
                buttonTorol.Enabled = true;
                buttonMentes.Enabled = true;
                errorProvider.SetError(textKod, "");
                errorProvider.SetError(textMegnevezes, "");
            }
        }

        private void buttonTorol_Click(object sender, EventArgs e)
        {
            variabelClear(this.Controls);
            if (dataGV.SelectedRows.Count > -1)
            {
                DataRow[] row = tableKodtab.Select("dolgozo_nev ='" + dataGV.CurrentRow.Cells["dolgozo_nev"].Value + "'");
                row[0].Delete();
            }
        }

        private void buttonVissza_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.rendben();
        }

        private void cbKodtip_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewKodtab.RowFilter = ("kodtipus = '" + cbKodtip.Text + "'");
        }
    }
}


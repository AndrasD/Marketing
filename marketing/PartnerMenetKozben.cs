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
    public partial class PartnerMenetKozben : Form
    {
        private ujfeladat _ujfeladat;
        private tisztito _tisztito;
        private feladatkezeles _feladatkezeles;

        public PartnerMenetKozben(ujfeladat uc, tisztito ti)
        {
            _ujfeladat = uc;
            _tisztito = ti;
            InitializeComponent();
            PartnerMenetKozbenInit();
        }

        public PartnerMenetKozben(feladatkezeles uc)
        {
            _feladatkezeles = uc;
            InitializeComponent();
            PartnerMenetKozbenInit();
        }

        public void PartnerMenetKozbenInit()
        {
            if (_ujfeladat != null)
                cbIrsz.DataSource = _ujfeladat.tableIrsz;
            else
                cbIrsz.DataSource = _feladatkezeles.tableIrsz;

            cbIrsz.DisplayMember = "telepules";
            cbIrsz.ValueMember = "sorszam";

            if (_ujfeladat != null)
                cbKoztj.DataSource = _ujfeladat.tableKozt;
            else
                cbKoztj.DataSource = _feladatkezeles.tableKozt;

            cbKoztj.DisplayMember = "szoveg";
            cbKoztj.ValueMember = "sorszam";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] r;
            DataRow row;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Hiba üres a partner");
                DialogResult = DialogResult.Cancel;
            }
            else if (_ujfeladat != null)
            {
                r = _ujfeladat.tablePartner.Select("azonosito = '" + textBox1.Text.Trim() + "'");
                if (r.Length > 0)
                {
                    MessageBox.Show("Ez a partner már létezik!");
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    row = _ujfeladat.tablePartner.NewRow();
                    _ujfeladat.valtozokMent(panel1.Controls, row);
                    row["sajat"] = "N";
                    row["verzio_id"] = 1;
                    _ujfeladat.tablePartner.Rows.Add(row);

                    try
                    {
                        _ujfeladat.daPartner.Update(_ujfeladat.tablePartner);
                        _ujfeladat.tablePartner.AcceptChanges();
                        _ujfeladat.tablePartner.Clear();
                        _ujfeladat.daPartner.Fill(_ujfeladat.dataSet, "tablePartner");
                        _ujfeladat.tablePartner = _ujfeladat.dataSet.Tables["tablePartner"];
                        _ujfeladat.viewPartner.Clear();
                        _ujfeladat.da = new SqlDataAdapter("select * from partner order by azonosito", _ujfeladat.connection);
                        _ujfeladat.da.Fill(_ujfeladat.dataSet, "viewPartner");
                        _ujfeladat.viewPartner = _ujfeladat.dataSet.Tables["viewPartner"];

                        //_tisztito.comboPartner.Text = textBox1.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                    }
                }
            }
            else
            {
                r = _feladatkezeles.tablePartner.Select("azonosito = '" + textBox1.Text + "'");
                if (this.Text == "Új partner felvétele" && r.Length > 0)
                {
                    MessageBox.Show("Ez a partner már létezik!");
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    if (this.Text == "Új partner felvétele")
                        row = _feladatkezeles.tablePartner.NewRow();
                    else
                        row = r[0];
                    _feladatkezeles.valtozokMent(panel1.Controls, row);
                    row["sajat"] = "N";
                    row["verzio_id"] = 1;
                    if (this.Text == "Új partner felvétele")
                        _feladatkezeles.tablePartner.Rows.Add(row);

                    try
                    {
                        _feladatkezeles.daPartner.Update(_feladatkezeles.tablePartner);
                        _feladatkezeles.tablePartner.AcceptChanges();
                        _feladatkezeles.tablePartner.Clear();
                        _feladatkezeles.daPartner.Fill(_feladatkezeles.dataSet, "tablePartner");
                        _feladatkezeles.tablePartner = _feladatkezeles.dataSet.Tables["tablePartner"];
                        _feladatkezeles.viewPartner.Clear();
                        _feladatkezeles.da = new SqlDataAdapter("select * from partner order by azonosito", _feladatkezeles.connection);
                        _feladatkezeles.da.Fill(_feladatkezeles.dataSet, "viewPartner");
                        _feladatkezeles.viewPartner = _feladatkezeles.dataSet.Tables["viewPartner"];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                    }
                }
            }

        }

        private void PartnerMenetKozben_VisibleChanged(object sender, EventArgs e)
        {
            DataRow[] row;
            DataRow r1;

            if (this.Visible == true)
            {
                if (_ujfeladat != null)
                {
                    string hs = textBox1.Text;
                    _ujfeladat.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textBox1.Text = hs;
                }
                else
                {
                    string hs = textBox1.Text;
                    _feladatkezeles.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textBox1.Text = hs;
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + textBox1.Text + "'");
                    if (row.Length > 0)
                    {
                        r1 = row[0];
                        _feladatkezeles.valtozokTolt(panel1.Controls, r1);
                    }
                }
            }

        }

    }
}
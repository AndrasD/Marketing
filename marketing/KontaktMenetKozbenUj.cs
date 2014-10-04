using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace marketing
{
    public partial class KontaktMenetKozbenUj : Form
    {
        private PartnerMenetKozben PartnerMenetKozben;
        private ujfeladat _ujfeladat;
        private tisztito _tisztito;
        private feladatkezeles _feladatkezeles;
        private bool kontaktFound = false;
        public int _selectedKontakt = -1;
        public int kontaktIndex = 0;
        public DataRow kontaktRow;

        public KontaktMenetKozbenUj(ujfeladat uc, tisztito ti)
        {
            _ujfeladat = uc;
            _tisztito = ti;
            InitializeComponent();
            KontaktMenetKozbenInit();
        }

        public KontaktMenetKozbenUj(feladatkezeles fk)
        {
            _feladatkezeles = fk;
            InitializeComponent();
            KontaktMenetKozbenInit();
        }

        public void KontaktMenetKozbenInit()
        {
            if (_ujfeladat != null)
            {
                cbPartner.DataSource = _ujfeladat.viewPartner;
                cbBeo.DataSource = _ujfeladat.tableBeo;
            }
            else
            {
                cbPartner.DataSource = _feladatkezeles.viewPartner;
                cbBeo.DataSource = _feladatkezeles.tableBeo;
            }
            cbPartner.DisplayMember = "azonosito";
            cbPartner.ValueMember = "pid";

            cbBeo.DisplayMember = "szoveg";
            cbBeo.ValueMember = "sorszam";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mindenOK = true;

            if (textNev.Text.Trim() == "")
            {
                MessageBox.Show("Hiba üres a név");
                mindenOK = false;
                //DialogResult = DialogResult.Cancel;
            }
            else if (cbPartner.Text == "")
            {
                MessageBox.Show("Hiba üres a partner");
                mindenOK = false;
                //DialogResult = DialogResult.Cancel;
            }
            else if (textNev.Text.Trim() != String.Empty)
            {
                textNev.Text = textNev.Text.Replace('ő', 'ö');
                textNev.Text = textNev.Text.Replace('Ő', 'Ö');
                textNev.Text = textNev.Text.Replace('ű', 'ü');
                textNev.Text = textNev.Text.Replace('Ű', 'Ü');
                if (_ujfeladat != null)
                {
                    DataRow[] r = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text + "'");
                    if (r.Length > 0)
                    {
                        MessageBox.Show("Ez a személy már létezik!");
                        mindenOK = false;
                    }
                }
                else
                {
                    DataRow[] r = _feladatkezeles.tableKontakt.Select("nev = '" + textNev.Text + "'");
                    if (r.Length > 0)
                    {
                        MessageBox.Show("Ez a személy már létezik!");
                        mindenOK = false;
                    }
                }
            }

            if (mindenOK)
            {
                DataRow row;
                DataRow row2;

                if (_ujfeladat != null)
                {
                    if (!kontaktFound)
                        row = _ujfeladat.tableKontakt.NewRow();
                    else
                        row = kontaktKeres2();

                    _ujfeladat.valtozokMent(panel1.Controls, row);

                    if (Convert.ToInt32(row["pid"].ToString()) <= 0)
                    {
                        MessageBox.Show("Hiba üres a partner");

                    }
                    else
                    {
                        if (!kontaktFound)
                            _ujfeladat.tableKontakt.Rows.Add(row);
                        try
                        {
                            _ujfeladat.daKontakt.Update(_ujfeladat.tableKontakt);
                            _ujfeladat.tableKontakt.AcceptChanges();
                            _ujfeladat.tableKontakt.Clear();
                            _ujfeladat.daKontakt.Fill(_ujfeladat.dataSet, "tableKontakt");
                            _ujfeladat.tableKontakt = _ujfeladat.dataSet.Tables["tableKontakt"];
                            _ujfeladat.viewKontakt.Clear();
                            _ujfeladat.da = new SqlDataAdapter("select kontakt.*, kontakt.nev+'      Cég:'+partner.azonosito as megjelenit, partner.azonosito from kontakt, partner where kontakt.pid = partner.pid", _ujfeladat.connection);
                            _ujfeladat.da.Fill(_ujfeladat.dataSet, "viewKontakt");
                            _ujfeladat.viewKontakt = _ujfeladat.dataSet.Tables["viewKontakt"];

                            DataRow[] r = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text.Trim() + "' and pid = " + cbPartner.SelectedValue.ToString());
                            _ujfeladat.valtozokTolt(_tisztito.groupBox4.Controls, r[0]);

                            DataRow[] r2 = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text + "'");

                            row2 = _ujfeladat.tablePK.NewRow();
                            _ujfeladat.valtozokMent(panel1.Controls, row2);
                            row2["projekt_id"] = _ujfeladat._selectedIndex;
                            row2["kontakt_id"] = r2[0]["id"];
                            row2["nev"] = textNev.Text;
                            row2["szoveg"] = cbBeo.Text;
                            row2["azonosito"] = cbPartner.Text;
                            _ujfeladat.tablePK.Rows.Add(row2);

                            DialogResult = DialogResult.OK;
 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    row = _feladatkezeles.tableKontakt.NewRow();

                    _feladatkezeles.valtozokMent(panel1.Controls, row);

                    _feladatkezeles.tableKontakt.Rows.Add(row);

                    try
                    {
                        _feladatkezeles.daKontakt.Update(_feladatkezeles.tableKontakt);
                        _feladatkezeles.tableKontakt.AcceptChanges();
                        _feladatkezeles.tableKontakt.Clear();
                        _feladatkezeles.daKontakt.Fill(_feladatkezeles.dataSet, "tableKontakt");
                        _feladatkezeles.tableKontakt = _feladatkezeles.dataSet.Tables["tableKontakt"];
                        DataRow[] r2 = _feladatkezeles.tableKontakt.Select("nev = '" + textNev.Text + "'");

                        row2 = _feladatkezeles.tablePK.NewRow();
                        _feladatkezeles.valtozokMent(panel1.Controls, row2);
                        row2["projekt_id"] = _feladatkezeles._selectedIndex;
                        row2["kontakt_id"] = r2[0]["id"];
                        row2["nev"] = textNev.Text;
                        row2["szoveg"] = cbBeo.Text;
                        row2["azonosito"] = cbPartner.Text;
                        _feladatkezeles.tablePK.Rows.Add(row2);

                        DialogResult = DialogResult.OK;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow[] row;
            if (PartnerMenetKozben == null)
                if (_ujfeladat != null)
                    PartnerMenetKozben = new PartnerMenetKozben(_ujfeladat, _tisztito);
                else
                    PartnerMenetKozben = new PartnerMenetKozben(_feladatkezeles);
            else
                PartnerMenetKozben.textBox1.Text = cbPartner.Text.Trim();

            if (PartnerMenetKozben.ShowDialog() == DialogResult.OK)
            {
                if (_ujfeladat != null)
                {
                    row = _ujfeladat.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                    if (row.Length > 0)
                        cbPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                }
                else
                {
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                    if (row.Length > 0)
                        cbPartner.SelectedIndex = _feladatkezeles.searchCombo(row[0], "pid", _feladatkezeles.viewPartner, cbPartner).index;
                }
            }
            PartnerMenetKozben = null;
        }

        private bool kontaktKeres()
        {
            bool ret = false;

            if (_ujfeladat != null)
            {
                if (cbPartner.SelectedValue != null && kontaktRow != null)
                {
                    DataRow r = kontaktRow;
                    _ujfeladat.valtozokTolt(panel1.Controls, r);
                    this.Text = "Kontakt módosítása";
                    ret = true;
                }
            }
            else if (_feladatkezeles != null)
            {
                if (cbPartner.SelectedValue != null && kontaktRow != null)
                {
                    DataRow r = kontaktRow;
                    _feladatkezeles.valtozokTolt(panel1.Controls, r);
                    this.Text = "Kontakt módosítása";
                    ret = true;
                }
            }

            return ret;
        }

        private DataRow kontaktKeres2()
        {
            DataRow[] r;
            DataRow ret = null;

            if (_ujfeladat != null)
            {
                r = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text + "'");
                if (r.Length == 0)
                {
                    ret = null;
                }
                else
                {
                    ret = r[0];
                }
            }
            else if (_feladatkezeles != null)
            {
                r = _feladatkezeles.tableKontakt.Select("nev = '" + textNev.Text + "'");
                if (r.Length == 0)
                {
                    ret = null;
                }
                else
                {
                    ret = r[0];
                }
            }

            return ret;
        }

        private void KontaktMenetKozben_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                kontaktFound = kontaktKeres();
                if (_ujfeladat != null && !kontaktFound)
                {
                    string hs = textNev.Text;
                    _ujfeladat.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textNev.Text = hs;
                    this.Text = "Új kontakt felvitele";
                }
                if (_feladatkezeles != null && !kontaktFound)
                {
                    string hs = textNev.Text;
                    _feladatkezeles.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textNev.Text = hs;
                    this.Text = "Új kontakt felvitele";
                }
            }
        }

        private void cbPartner_Leave(object sender, EventArgs e)
        {
            DataRow[] row;
            if (cbPartner.Text != "")
            {
                if (_ujfeladat != null)
                {
                    row = _ujfeladat.tablePartner.Select("azonosito = '" + cbPartner.Text + "'");
                }
                else
                {
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + cbPartner.Text + "'");
                }
                if (row.Length == 0)
                {
                    if (PartnerMenetKozben == null)
                        if (_ujfeladat != null)
                            PartnerMenetKozben = new PartnerMenetKozben(_ujfeladat, _tisztito);
                        else
                            PartnerMenetKozben = new PartnerMenetKozben(_feladatkezeles);

                    PartnerMenetKozben.textBox1.Text = cbPartner.Text.Trim();

                    if (PartnerMenetKozben.ShowDialog() == DialogResult.OK)
                    {
                        if (_ujfeladat != null)
                        {
                            row = _ujfeladat.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                            if (row.Length > 0)
                            {
                                cbPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                                cbPartner.Text = PartnerMenetKozben.textBox1.Text;
                            }
                        }
                        else
                        {
                            row = _feladatkezeles.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                            if (row.Length > 0)
                            {
                                cbPartner.SelectedIndex = _feladatkezeles.searchCombo(row[0], "pid", _feladatkezeles.viewPartner, cbPartner).index;
                                cbPartner.Text = PartnerMenetKozben.textBox1.Text;
                            }
                        }
                    }
                }
                else
                {
                    if (_ujfeladat != null)
                    {
                        cbPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                    }
                    else
                        cbPartner.SelectedIndex = _feladatkezeles.searchCombo(row[0], "pid", _feladatkezeles.viewPartner, cbPartner).index;

                }
            }
        }

        private void textNev_Leave(object sender, EventArgs e)
        {
            if (_ujfeladat != null)
            {
                DataRow[] r = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text + "'");
                if (r.Length > 0)
                {
                    MessageBox.Show("Ez a személy már létezik!");
                }
            }
            else
            {
                DataRow[] r = _feladatkezeles.tableKontakt.Select("nev = '" + textNev.Text + "'");
                if (r.Length > 0)
                {
                    MessageBox.Show("Ez a személy már létezik!");
                }
            }
        }

    }
}
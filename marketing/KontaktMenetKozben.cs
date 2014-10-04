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
    public partial class KontaktMenetKozben : Form
    {
        private PartnerMenetKozben PartnerMenetKozben;
        private ujfeladat _ujfeladat;
        private tisztito _tisztito;
        private feladatkezeles _feladatkezeles;
        private bool kontaktFound = false;
        public int _selectedKontakt = -1;
        public int kontaktIndex = 0;
        public DataRow kontaktRow;

        public KontaktMenetKozben(ujfeladat uc, tisztito ti)
        {
            _ujfeladat = uc;
            _tisztito = ti;
            InitializeComponent();
            KontaktMenetKozbenInit();
        }

        public KontaktMenetKozben(feladatkezeles fk)
        {
            _feladatkezeles = fk;
            InitializeComponent();
            KontaktMenetKozbenInit();
        }

        public void KontaktMenetKozbenInit()
        {
            if (_ujfeladat != null)
            {
                CBPartner.DataSource = _ujfeladat.viewPartner;
                cbBeo.DataSource = _ujfeladat.tableBeo;
                textNev.DataSource = _ujfeladat.tableKontakt;
            }
            else
            {
                CBPartner.DataSource = _feladatkezeles.viewPartner;
                cbBeo.DataSource = _feladatkezeles.tableBeo;
                textNev.DataSource = _feladatkezeles.tableKontakt;
            }
            CBPartner.DisplayMember = "azonosito";
            CBPartner.ValueMember = "pid";

            cbBeo.DisplayMember = "szoveg";
            cbBeo.ValueMember = "sorszam";

            textNev.DisplayMember = "nev";
            textNev.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CBPartner.Text == "")
            {
                MessageBox.Show("Hiba üres a partner");
                DialogResult = DialogResult.Cancel;
            }
            else if (textNev.Text.Trim() != String.Empty)
            {
                DataRow row;
                DataRow row2;

                if (_ujfeladat != null)
                {
                    if (!kontaktFound && _selectedKontakt == -1)
                    {
                        row = _ujfeladat.tableKontakt.NewRow();
                        row2 = _ujfeladat.tablePK.NewRow();
                    }
                    else
                    {
                        row = kontaktKeres2();
                        if (kontaktRow == null)
                            row2 = _ujfeladat.tablePK.NewRow();
                        else
                            row2 = _ujfeladat.tablePK.Rows[_selectedKontakt];
                    }

                    _ujfeladat.valtozokMent(panel1.Controls, row);
                    _ujfeladat.valtozokMent(panel1.Controls, row2);
                    row2["kontakt_id"] = row["id"];
                    row2["nev"] = row["nev"];
                    row2["szoveg"] = cbBeo.Text;
                    row2["azonosito"] = CBPartner.Text;

                    if (!kontaktFound && _selectedKontakt == -1)
                    {
                        _ujfeladat.tableKontakt.Rows.Add(row);
                        _ujfeladat.tablePK.Rows.Add(row2);
                    }

                    if (kontaktRow == null)
                    {
                        _ujfeladat.tablePK.Rows.Add(row2);
                    }

                    try
                    {
                        _ujfeladat.daKontakt.Update(_ujfeladat.tableKontakt);
                        _ujfeladat.tableKontakt.AcceptChanges();
                        _ujfeladat.tableKontakt.Clear();
                        _ujfeladat.daKontakt.Fill(_ujfeladat.dataSet, "tableKontakt");
                        _ujfeladat.tableKontakt = _ujfeladat.dataSet.Tables["tableKontakt"];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                    }
                }
                else
                {
                    if (!kontaktFound && _selectedKontakt == -1)
                    {
                        row = _feladatkezeles.tableKontakt.NewRow();
                        row2 = _feladatkezeles.tablePK.NewRow();
                    }
                    else
                    {
                        row = kontaktKeres2();
                        if (kontaktRow == null)
                            row2 = _feladatkezeles.tablePK.NewRow();
                        else
                            row2 = _feladatkezeles.tablePK.Rows[_feladatkezeles._selectedKontakt];
                    }

                    this.textNev.SelectedIndexChanged -= new EventHandler(textNev_SelectedIndexChanged);
                    _feladatkezeles.valtozokMent(panel1.Controls, row);
                    _feladatkezeles.valtozokMent(panel1.Controls, row2);
                    this.textNev.SelectedIndexChanged += new EventHandler(textNev_SelectedIndexChanged);
                    row2["projekt_id"] = _feladatkezeles._selectedIndex;
                    row2["kontakt_id"] = row["id"];
                    row2["nev"] = row["nev"];
                    row2["szoveg"] = cbBeo.Text;
                    row2["azonosito"] = CBPartner.Text;

                    if (!kontaktFound && _selectedKontakt == -1)
                    {
                        _feladatkezeles.tableKontakt.Rows.Add(row);
                        _feladatkezeles.tablePK.Rows.Add(row2);
                    }

                    if (kontaktRow == null)
                    {
                        _feladatkezeles.tablePK.Rows.Add(row2);
                    }

                    try
                    {
                        _feladatkezeles.daKontakt.Update(_feladatkezeles.tableKontakt);
                        _feladatkezeles.tableKontakt.AcceptChanges();
                        _feladatkezeles.tableKontakt.Clear();
                        _feladatkezeles.daKontakt.Fill(_feladatkezeles.dataSet, "tableKontakt");
                        _feladatkezeles.tableKontakt = _feladatkezeles.dataSet.Tables["tableKontakt"];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hiba üres a név");
                DialogResult = DialogResult.Cancel;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow[] row;
            int si = -1;

            if (PartnerMenetKozben == null)
                if (_ujfeladat == null)
                    PartnerMenetKozben = new PartnerMenetKozben(_feladatkezeles);
                else
                    PartnerMenetKozben = new PartnerMenetKozben(_ujfeladat, _tisztito);
            else
                PartnerMenetKozben.textBox1.Text = CBPartner.Text.Trim();
            if (CBPartner.Text != String.Empty && CBPartner.SelectedValue.ToString() != String.Empty)
            {
                PartnerMenetKozben.Text = "Partner módosítás";
                PartnerMenetKozben.textBox1.Text = CBPartner.Text.Trim();
                PartnerMenetKozben.textBox1.Enabled = false;
                if (_ujfeladat == null)
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                else
                    row = _ujfeladat.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
            }

            //if (CBPartner.Text != String.Empty)
            //    si = CBPartner.SelectedIndex;

            if (PartnerMenetKozben.ShowDialog() == DialogResult.OK)
            {
                if (_ujfeladat != null)
                {
                    row = _ujfeladat.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                    if (row.Length > 0)
                        CBPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                }
                else
                {
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                    if (row.Length > 0)
                        CBPartner.SelectedIndex = _feladatkezeles.searchCombo(row[0], "pid", _feladatkezeles.viewPartner);
                }
            }
        }

        private bool kontaktKeres()
        {
            bool ret = false;

            if (_ujfeladat != null)
            {
                if (CBPartner.SelectedValue != null && kontaktRow != null)
                {
                    DataRow r = kontaktRow;
                    _ujfeladat.valtozokTolt(panel1.Controls, r);
                    this.Text = "Kontakt módosítása";
                    ret = true;
                }
            }
            else if (_feladatkezeles != null)
            {
                if (CBPartner.SelectedValue != null && kontaktRow != null)
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
                //if (_ujfeladat != null)
                //if (_feladatkezeles != null)
                kontaktFound = kontaktKeres();
                if (_ujfeladat != null && !kontaktFound)
                {
                    string hs = textNev.Text;
                    _ujfeladat.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textNev.Text = hs;
                    //this.Text = "Új kontakt felvitele";
                }
                if (_feladatkezeles != null && !kontaktFound)
                {
                    string hs = textNev.Text;
                    _feladatkezeles.valtozokTor(panel1.Controls);
                    if (hs.Trim().Length != 0)
                        textNev.Text = hs;
                    //this.Text = "Új kontakt felvitele";
                }

            }

        }

        private void cbPartner_Leave(object sender, EventArgs e)
        {
            DataRow[] row;
            if (CBPartner.Text != "")
            {
                if (_ujfeladat != null)
                {
                    row = _ujfeladat.tablePartner.Select("azonosito = '" + CBPartner.Text + "'");
                }
                else
                {
                    row = _feladatkezeles.tablePartner.Select("azonosito = '" + CBPartner.Text + "'");
                }
                if (row.Length == 0)
                {
                    if (PartnerMenetKozben == null)
                    {
                        PartnerMenetKozben = new PartnerMenetKozben(_ujfeladat, _tisztito);
                        PartnerMenetKozben.textBox1.Text = CBPartner.Text.Trim();
                    }
                    else
                        PartnerMenetKozben.textBox1.Text = CBPartner.Text.Trim();

                    if (PartnerMenetKozben.ShowDialog() == DialogResult.OK)
                    {
                        if (_ujfeladat != null)
                        {
                            row = _ujfeladat.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                        }
                        else
                        {
                            row = _feladatkezeles.tablePartner.Select("azonosito = '" + PartnerMenetKozben.textBox1.Text + "'");
                        }
                        if (row.Length > 0)
                        {
                            CBPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                            CBPartner.Text = PartnerMenetKozben.textBox1.Text;
                        }
                    }
                }
                else
                {
                    if (_ujfeladat != null)
                    {
                        CBPartner.SelectedIndex = _ujfeladat.searchCombo(row[0], "pid", _ujfeladat.viewPartner);
                    }
                    else
                        CBPartner.SelectedIndex = _feladatkezeles.searchCombo(row[0], "pid", _feladatkezeles.viewPartner, CBPartner).index;

                }
            }
        }

        public void textNev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (_ujfeladat != null)
                {
                    DataRow[] r = _ujfeladat.tableKontakt.Select("nev = '" + textNev.Text + "'");
                    if (r.Length > 0)
                        _ujfeladat.valtozokTolt(panel1.Controls, r[0]);
                }
                else
                {

                    DataRow[] r = _feladatkezeles.tableKontakt.Select("nev = '" + textNev.Text + "'");
                    if (r.Length > 0)
                        _feladatkezeles.valtozokTolt(panel1.Controls, r[0]);
                }
            }
        }

        private void KontaktMenetKozben_Shown(object sender, EventArgs e)
        {
            textNev.SelectedIndexChanged += new EventHandler(textNev_SelectedIndexChanged);
        }
    }
}
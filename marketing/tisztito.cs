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
    public partial class tisztito : UserControl
    {
        private KontaktMenetKozben KontaktMenetKozben;
        private KontaktMenetKozbenUj KontaktMenetKozbenUj;
        private PartnerMenetKozben PartnerMenetKozben;
        private OpenFileDialog fileBrowse;
        ujfeladat _ujfeladat;
        public int _selectedKontakt = -1;

        public tisztito(ujfeladat uc)
        {
            _ujfeladat = uc;
            InitializeComponent();
        }

        private void tisztito_Load(object sender, EventArgs e)
        {
            cbIrsz.DataSource = _ujfeladat.tableIrsz;
            cbIrsz.DisplayMember = "telepules";
            cbIrsz.ValueMember = "sorszam";

            cbKoztj.DataSource = _ujfeladat.tableKozt;
            cbKoztj.DisplayMember = "szoveg";
            cbKoztj.ValueMember = "sorszam";

            cbFelelos.DataSource = _ujfeladat.tableFelelos;
            cbFelelos.DisplayMember = "dolgozo_nev";
            cbFelelos.ValueMember = "id";

            cbProfil.DataSource = _ujfeladat.tableProfil;
            cbProfil.DisplayMember = "szoveg";
            cbProfil.ValueMember = "sorszam";

            cbHogyan.DataSource = _ujfeladat.tableHogyan;
            cbHogyan.DisplayMember = "szoveg";
            cbHogyan.ValueMember = "sorszam";

            cbStatus.DataSource = _ujfeladat.tableStatus;
            cbStatus.DisplayMember = "szoveg";
            cbStatus.ValueMember = "sorszam";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dokDir;
            if (textAzon.Text.Trim() != String.Empty)
            {
                dokDir = _ujfeladat.defaultDir.Replace(";","")+ "\\" + textAzon.Text.Trim();
                if (!Directory.Exists(dokDir))
                    Directory.CreateDirectory(dokDir);
                if (fileBrowse == null)
                    fileBrowse = new OpenFileDialog();
                fileBrowse.Multiselect = false;
                fileBrowse.InitialDirectory = dokDir;
                if (fileBrowse.ShowDialog() == DialogResult.OK)
                {
                    int li = fileBrowse.FileName.LastIndexOf("\\");
                    textPath.Text = fileBrowse.FileName.Substring(0,li);
                }
            }
            else
                MessageBox.Show("Adja meg a projekt azonosítóját!");

        }

        private void textAzon_Leave(object sender, EventArgs e)
        {
            DataRow[] row = _ujfeladat.tableProjekt.Select("azonosito = '"+textAzon.Text.Trim()+"'");
            if (row.Length > 0)
            {
                MessageBox.Show("Ez az azonosító már létezik!");
            }
        }

        private string searchNev(string n)
        {
            int v = n.IndexOf("Cég:");
            if (v == -1) v = n.Length;
            return n.Substring(0,v).Trim();
        }

        private void PartnerKontaktLoad()
        {
            _ujfeladat.tablePartner.Clear();
            _ujfeladat.daPartner = new SqlDataAdapter("select * from partner order by azonosito", _ujfeladat.connection);
            _ujfeladat.cbPartner = new SqlCommandBuilder(_ujfeladat.daPartner);
            _ujfeladat.daPartner.Fill(_ujfeladat.dataSet, "tablePartner");
            _ujfeladat.tablePartner = _ujfeladat.dataSet.Tables["tablePartner"];

            _ujfeladat.viewPartner.Clear();
            _ujfeladat.da = new SqlDataAdapter("select * from partner order by azonosito", _ujfeladat.connection);
            _ujfeladat.da.Fill(_ujfeladat.dataSet, "viewPartner");
            _ujfeladat.viewPartner = _ujfeladat.dataSet.Tables["viewPartner"];
            _ujfeladat.viewPartner.PrimaryKey = new DataColumn[] { _ujfeladat.viewPartner.Columns["pid"] };

            _ujfeladat.tableKontakt.Clear();
            _ujfeladat.daKontakt = new SqlDataAdapter("select * from kontakt order by nev", _ujfeladat.connection);
            _ujfeladat.cbKontakt = new SqlCommandBuilder(_ujfeladat.daKontakt);
            _ujfeladat.daKontakt.Fill(_ujfeladat.dataSet, "tableKontakt");
            _ujfeladat.tableKontakt = _ujfeladat.dataSet.Tables["tableKontakt"];

            _ujfeladat.da = new SqlDataAdapter("select * from kontakt order by nev", _ujfeladat.connection);
            _ujfeladat.viewKontakt.Clear();
            _ujfeladat.da.Fill(_ujfeladat.dataSet, "viewKontakt");
            _ujfeladat.viewKontakt = _ujfeladat.dataSet.Tables["viewKontakt"];
            _ujfeladat.viewKontakt.PrimaryKey = new DataColumn[] { _ujfeladat.viewKontakt.Columns["id"] };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartnerKontaktLoad();
            if (KontaktMenetKozbenUj == null)
            {
                KontaktMenetKozbenUj = new KontaktMenetKozbenUj(_ujfeladat,this);
                KontaktMenetKozbenUj._selectedKontakt = -1;
                KontaktMenetKozbenUj.textNev.Text = "";
            }
            if (KontaktMenetKozbenUj.ShowDialog() == DialogResult.OK)
            {
            }
            KontaktMenetKozbenUj = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PartnerKontaktLoad();
            if (KontaktMenetKozben == null)
            {
                KontaktMenetKozben = new KontaktMenetKozben(_ujfeladat,this);
                KontaktMenetKozben._selectedKontakt = _ujfeladat.tablePK.Rows.Count;
                KontaktMenetKozben.kontaktIndex = 0;
                KontaktMenetKozben.kontaktRow = null;
                _ujfeladat.valtozokTor(KontaktMenetKozben.panel1.Controls);
                KontaktMenetKozben.Text = "Kontakt személy hozzárendelése";
            }
            if (KontaktMenetKozben.ShowDialog() == DialogResult.OK)
            {
            }
            KontaktMenetKozben = null;
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedKontakt > -1)
            {
                if (_ujfeladat.tablePK.Rows[_selectedKontakt]["projekt_kontakt_id"].ToString() != "")
                {
                    DataRow[] r = _ujfeladat.tableProjektKontakt.Select("id = " + _ujfeladat.tablePK.Rows[_selectedKontakt]["projekt_kontakt_id"].ToString());
                    _ujfeladat.tableProjektKontakt.Rows[_ujfeladat.tableProjektKontakt.Rows.IndexOf(r[0])].Delete();
                }
                _ujfeladat.tablePK.Rows[_selectedKontakt].Delete();
            }
        }

        private void dataGVKontakt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                _selectedKontakt = e.RowIndex;
            else
                _selectedKontakt = -1;
        }

        private void dataGVKontakt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedKontakt = e.RowIndex;
                if (KontaktMenetKozben == null)
                {
                    KontaktMenetKozben = new KontaktMenetKozben(_ujfeladat,this);
                    KontaktMenetKozben.textNev.SelectedIndexChanged -= new EventHandler(KontaktMenetKozben.textNev_SelectedIndexChanged);
                    KontaktMenetKozben._selectedKontakt = _selectedKontakt;
                    if (dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value.ToString() != "")
                    {
                        KontaktMenetKozben.textNev.SelectedValue = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value);
                        KontaktMenetKozben.textNev.Text = dataGVKontakt.Rows[_selectedKontakt].Cells["comboNev"].Value.ToString();

                        KontaktMenetKozben.CBPartner.SelectedValue = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["pid"].Value);
                        KontaktMenetKozben.CBPartner.Text = dataGVKontakt.Rows[_selectedKontakt].Cells["partner_azonosito"].Value.ToString();
                        KontaktMenetKozben.kontaktIndex = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value);
                        DataRow[] r = _ujfeladat.tableKontakt.Select("id = " + KontaktMenetKozben.kontaktIndex);
                        KontaktMenetKozben.kontaktRow = r[0];
                    }
                    else
                    {
                        KontaktMenetKozben.kontaktIndex = 0;
                        KontaktMenetKozben.kontaktRow = null;
                    }
                }
                if (KontaktMenetKozben.ShowDialog() == DialogResult.OK)
                {
                }
                KontaktMenetKozben = null;
            }
            else
                _selectedKontakt = -1;
        }

        private void dataGVKontakt_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["projekt_kontakt_id"].Value.ToString() != "")
            {
                DataRow[] r = _ujfeladat.tableProjektKontakt.Select("id = " + e.Row.Cells["projekt_kontakt_id"].Value.ToString());
                _ujfeladat.tableProjektKontakt.Rows[_ujfeladat.tableProjektKontakt.Rows.IndexOf(r[0])].Delete();
            }
        }

    }
}

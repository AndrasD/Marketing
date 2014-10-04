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
    public partial class feladatkezeles : UserControl
    {
        private KontaktMenetKozben KontaktMenetKozben;
        private KontaktMenetKozbenUj KontaktMenetKozbenUj;

        public DataSet dataSet = new DataSet();

        public DataTable tableProjekt = new DataTable();
        public DataTable tableProjektTetel = new DataTable();
        public DataTable viewProjekt = new DataTable();

        public DataTable tableIrsz = new DataTable();
        public DataTable tableKozt = new DataTable();
        public DataTable tablePartner = new DataTable();
        public DataTable tableFelelos = new DataTable();
        public DataTable tableProfil = new DataTable();
        public DataTable tableHogyan = new DataTable();
        public DataTable tableStatus = new DataTable();
        public DataTable tableBeo = new DataTable();
        public DataTable tableKontakt = new DataTable();
        public DataTable viewKontakt = new DataTable();
        public DataTable viewPartner = new DataTable();

        public DataTable tableAzonos = new DataTable();
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
        private OpenFileDialog fileBrowse;
        private MainForm _mainForm;

        public int _selectedIndex = -1;
        private string selectString;
        public int userId;
        public int _selectedKontakt = -1;

        public feladatkezeles(MainForm mainForm)
        {
            connection = mainForm.MyConn;
            _mainForm = mainForm;
            InitializeComponent();

            tableAzonos.Clear();
            da = new SqlDataAdapter("select id, azonosito from projekt", connection);
            da.Fill(dataSet, "tableAzonos");
            tableAzonos = dataSet.Tables["tableAzonos"];
            tableAzonos.PrimaryKey = new DataColumn[] { tableAzonos.Columns["azonosito"] };
        }

        public void feladatkezeles_Load(object sender, EventArgs e)
        {
            adatokToltese();
            valtozokTorlese();
            textKeres.Focus();
        }

        private void feladatkezeles_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                adatokToltese();
                valtozokToltese();
            }
        }

        public void adatokToltese()
        {
            viewProjekt.Clear();
            daProjekt = new SqlDataAdapter("select * from projekt", connection);
            daProjekt.Fill(dataSet, "viewProjekt");
            cbProjekt = new SqlCommandBuilder(daProjekt);
            viewProjekt = dataSet.Tables["viewProjekt"];
            viewProjekt.PrimaryKey = new DataColumn[] { viewProjekt.Columns["id"] };

            tableIrsz.Clear();
            //da = new SqlDataAdapter("select rtrim(cast(irsz as char))+' '+telepules+' '+kerulet as display, irsz from irszamok", connection);
            da = new SqlDataAdapter("select distinct telepules, sorszam from irszamok where sorszam = 1 or sorszam > 162", connection);
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

            tableKontakt.Clear();
            daKontakt = new SqlDataAdapter("select * from kontakt order by nev", connection);
            cbKontakt = new SqlCommandBuilder(daKontakt);
            daKontakt.Fill(dataSet, "tableKontakt");
            tableKontakt = dataSet.Tables["tableKontakt"];
            //tableKontakt.PrimaryKey = new DataColumn[] { tableKontakt.Columns["id"] };

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

            textKeres.DataSource = tableAzonos;
            textKeres.DisplayMember = "azonosito";
            textKeres.ValueMember = "id";
        }

        public void buttonKeres_Click(object sender, EventArgs e)
        {
            feladatkezeles_Load(sender, e);

            viewProjekt.Clear();
            daProjekt = new SqlDataAdapter("select * from projekt", connection);
            daProjekt.Fill(dataSet, "viewProjekt");
            cbProjekt = new SqlCommandBuilder(daProjekt);
            viewProjekt = dataSet.Tables["viewProjekt"];
            viewProjekt.PrimaryKey = new DataColumn[] { viewProjekt.Columns["id"] };

            string projektSelect = "select a.*, b.kov_kontakt " +
                                "from projekt a, projekt_tetel b, (select max(id) as mid, projekt_id as p_id from projekt_tetel group by projekt_id) as m " +
                                "where m.p_id = a.id " +
                                "  and b.id = m.mid ";
            if (textKeres.Text.IndexOf('%') < 0)
                textKeres.Text = textKeres.Text + "%";
            if (_mainForm.Jogosultsag == "1")
                selectString = "azonosito like '" + textKeres.Text + "'";
            else
                selectString = "azonosito like '" + textKeres.Text + "' and a.felelos = " + userId.ToString();

            selectString = selectString + " and kov_kontakt between '" + datTol.Value.ToShortDateString() + "' and '" + datIg.Value.ToShortDateString() + "' ";

            tableProjekt.Clear();
            da = new SqlDataAdapter(projektSelect+" and " + selectString, connection);
            da.Fill(dataSet, "tableProjekt");
            tableProjekt = dataSet.Tables["tableProjekt"];
            tableProjekt.PrimaryKey = new DataColumn[] { tableProjekt.Columns["id"] };

            if (tableProjekt.Rows.Count == 0)
            {
                _selectedIndex = -1;
                textKeres.Text = "";
                panel3.Enabled = false;
                MessageBox.Show("A feltételnek nincs megfelelő tétel\r\n");
            }
            else
            {
                panel3.Enabled = true;

                _selectedIndex = Convert.ToInt32(tableProjekt.Rows[0]["id"].ToString());
                dataGV.DataSource = tableProjekt;

                tableProjektTetel.Clear();
                daProjektTetel = new SqlDataAdapter("select * from projekt_tetel where projekt_id = " + tableProjekt.Rows[0]["id"].ToString() + " order by id desc", connection);
                cbProjektTetel = new SqlCommandBuilder(daProjektTetel);
                daProjektTetel.Fill(dataSet, "tableProjektTetel");
                tableProjektTetel = dataSet.Tables["tableProjektTetel"];

                dataGVTetel.DataSource = tableProjektTetel;
                valtozokToltese();
                textKeres.Text = "";
            }

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
            _Combo comboValt = new _Combo();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            dt = tableProjektTetel.Copy();
            dv.Table = dt;
            dv.Sort = "id";

            try
            {
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

                textBox1.Text = String.Empty;
                if (textBox2.Text == String.Empty)
                    for (int i = 0; i < dv.Count; i++)
                    {
                        if (Convert.ToInt32(dv[i]["id"].ToString()) > 2591)
                            textBox2.Text = textBox2.Text + dv[i]["megjegyzes"].ToString() + "\r\n";
                        else
                            textBox2.Text = dv[i]["megjegyzes"].ToString() + "\r\n";
                    }
            }
            catch
            {
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
                if (row.Length>0)
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


        private void buttonVissza_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _mainForm.panel1.Controls.Count; i++)
            {
                if (_mainForm.panel1.Controls[i].Name == "lekerdezesekLista" && _mainForm.panel1.Controls[i].Visible)
                {
                    _mainForm.panel1.Controls[i].VisibleChanged -= new EventHandler(_mainForm.usercontrol_VisibleChanged);
                    _mainForm.panel1.Controls["feladatkezeles"].VisibleChanged -= new EventHandler(_mainForm.usercontrol_VisibleChanged);
                    //this.Visible = false;
                    _mainForm.panel1.Controls[i].Visible = true;
                    _mainForm.panel1.Controls[i].VisibleChanged += new EventHandler(_mainForm.usercontrol_VisibleChanged);
                    _mainForm.panel1.Controls["feladatkezeles"].VisibleChanged += new EventHandler(_mainForm.usercontrol_VisibleChanged);
                }
            }
            this.Visible = false;
        }

        private bool ellenorzes()
        {
            bool ret = true;

            if (textAzon.Text.Trim() == String.Empty)
            {
                ret = false;
                MessageBox.Show("Hiányzik a projekt azonosító!");
            }
            else
            {
                letezikMar();
            }

            if (cbFelelos.SelectedIndex < 0)
            {
                ret = false;
                MessageBox.Show("Hiányzik a felelős!");
            }

            return ret;
        }

        private void buttonMentes_Click(object sender, EventArgs e)
        {
            if (_selectedIndex > -1 && ellenorzes())
            {
                DataRow row = viewProjekt.Rows.Find(_selectedIndex);
                valtozokMent(panel3.Controls, row);
                valtozokMent(groupBox4.Controls, row);
                valtozokMent(groupBox5.Controls, row);
                valtozokMent(groupBox6.Controls, row);

                //SqlTransaction tran = connection.BeginTransaction(;

                try
                {
                    DataRow r;
                    DataRow[] r2;
                    for (int i = 0; i < tablePK.Rows.Count; i++)
                    {
                        if (tablePK.Rows[i].RowState != DataRowState.Deleted)
                        {
                            if (tablePK.Rows[i]["projekt_kontakt_id"].ToString() == "")
                            {
                                r = tableProjektKontakt.NewRow();
                                r["projekt_id"] = _selectedIndex;
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

                    daProjekt.Update(viewProjekt);
                    viewProjekt.AcceptChanges();

                    row = tableProjektTetel.NewRow();
                    valtozokMent(panel3.Controls, row);
                    valtozokMent(groupBox4.Controls, row);
                    valtozokMent(groupBox5.Controls, row);
                    valtozokMent(groupBox6.Controls, row);
                    row["kontakt_id"] = 0;
                    row["projekt_id"] = _selectedIndex;
                    tableProjektTetel.Rows.Add(row);

                    daProjektTetel.Update(tableProjektTetel);
                    tableProjektTetel.AcceptChanges();

                    tableProjektTetel.Clear();
                    daProjektTetel = new SqlDataAdapter("select * from projekt_tetel where projekt_id = " + _selectedIndex + " order by id desc", connection);
                    cbProjektTetel = new SqlCommandBuilder(daProjektTetel);
                    daProjektTetel.Fill(dataSet, "tableProjektTetel");
                    tableProjektTetel = dataSet.Tables["tableProjektTetel"];

                    //tran.Commit();
                    buttonVissza_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba az adatbázis aktualizálásánál\r\n" + ex.Message);
                }
            }
        }

        private void dataGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _selectedIndex = Convert.ToInt32(dataGV.Rows[e.RowIndex].Cells["id"].Value.ToString());
                valtozokToltese();
            }
        }

        private void valtozokToltese()
        {
            if (_selectedIndex >= 0)
            {
                viewProjekt.Clear();
                daProjekt = new SqlDataAdapter("select * from projekt", connection);
                daProjekt.Fill(dataSet, "viewProjekt");
                cbProjekt = new SqlCommandBuilder(daProjekt);
                viewProjekt = dataSet.Tables["viewProjekt"];
                viewProjekt.PrimaryKey = new DataColumn[] { viewProjekt.Columns["id"] };

                DataRow row = tableProjekt.Rows.Find(_selectedIndex);
                valtozokTolt(panel3.Controls, row);
                valtozokTolt(groupBox4.Controls, row);
                valtozokTolt(groupBox5.Controls, row);
                valtozokTolt(groupBox6.Controls, row);

                tablePK.Clear();
                da = new SqlDataAdapter("select a.*, c.irsz as partner_irsz, c.telepules, b.pkozt as partner_kozt, b.pkoztj as partner_koztj, b.phazsz as partner_hazsz from view_projekt_kontakt a left outer join partner b on a.pid=b.pid left outer join irszamok c on b.pirsz=c.sorszam where projekt_id = " + _selectedIndex, connection);
                da.Fill(dataSet, "tablePK");
                tablePK = dataSet.Tables["tablePK"];
                dataGVKontakt.DataSource = tablePK;

                tableProjektKontakt.Clear();
                daProjektKontakt = new SqlDataAdapter("select * from projekt_kontakt where projekt_id = " + _selectedIndex, connection);
                cbProjektKontakt = new SqlCommandBuilder(daProjektKontakt);
                daProjektKontakt.Fill(dataSet, "tableProjektKontakt");
                tableProjektKontakt = dataSet.Tables["tableProjektKontakt"];

                if (tableProjektKontakt.Rows.Count > 0)
                {
                    _selectedKontakt = 0;
                }

                tableProjektTetel.Clear();
                daProjektTetel = new SqlDataAdapter("select * from projekt_tetel where projekt_id = " + _selectedIndex + " order by id desc", connection);
                cbProjektTetel = new SqlCommandBuilder(daProjektTetel);
                daProjektTetel.Fill(dataSet, "tableProjektTetel");
                tableProjektTetel = dataSet.Tables["tableProjektTetel"];

                row = tableProjektTetel.Rows[0];
                //valtozokTolt(panel3.Controls, row);
                valtozokTolt(groupBox4.Controls, row);
                valtozokTolt(groupBox5.Controls, row);
                valtozokTolt(groupBox6.Controls, row);
            }
        }

        public void valtozokTorlese()
        {
            tableProjekt.Clear();
            tableProjektTetel.Clear();
            tablePK.Clear();
            tableProjektKontakt.Clear();
            valtozokTor(panel3.Controls);
            valtozokTor(groupBox4.Controls);
            valtozokTor(groupBox5.Controls);
            valtozokTor(groupBox6.Controls);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dokDir;
            if (textAzon.Text.Trim() != String.Empty)
            {
                dokDir = _mainForm.defaultDir.Replace(";", "") + "\\" + textAzon.Text.Trim();
                if (!Directory.Exists(dokDir))
                    Directory.CreateDirectory(dokDir);
                if (fileBrowse == null)
                    fileBrowse = new OpenFileDialog();
                fileBrowse.Multiselect = false;
                if (textPath.Text == "")
                    fileBrowse.InitialDirectory = dokDir;
                else
                    fileBrowse.InitialDirectory = textPath.Text;

                if (fileBrowse.ShowDialog() == DialogResult.OK)
                {
                    int li = fileBrowse.FileName.LastIndexOf("\\");
                    textPath.Text = fileBrowse.FileName.Substring(0, li);
                }
            }
            else
                MessageBox.Show("Adja meg a projekt azonosítóját!");
        }

        private void textAzon_Leave(object sender, EventArgs e)
        {
            letezikMar();
        }

        private void letezikMar()
        {
            DataRow[] row = viewProjekt.Select("azonosito = '" + textAzon.Text.Trim() + "'");
            if (row.Length > 0 && textId.Text != row[0]["id"].ToString())
            {
                MessageBox.Show("Ez az azonosító már létezik!");
            }
        }

        private string searchNev(string n)
        {
            int v = n.IndexOf("Cég:");
            if (v == -1) v = n.Length;
            return n.Substring(0, v).Trim();
        }

        private void dataGVKontakt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
               _selectedKontakt = e.RowIndex;
            else
               _selectedKontakt = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KontaktMenetKozbenUj == null)
            {
                KontaktMenetKozbenUj = new KontaktMenetKozbenUj(this);
                KontaktMenetKozbenUj._selectedKontakt = -1;
                KontaktMenetKozbenUj.textNev.Text = "";
            }
            if (KontaktMenetKozbenUj.ShowDialog() == DialogResult.OK)
            {
            }
            KontaktMenetKozbenUj = null;
        }

        private void dataGVKontakt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedKontakt = e.RowIndex;
                if (KontaktMenetKozben == null)
                {
                    KontaktMenetKozben = new KontaktMenetKozben(this);
                    KontaktMenetKozben.textNev.SelectedIndexChanged -= new EventHandler(KontaktMenetKozben.textNev_SelectedIndexChanged);
                    KontaktMenetKozben._selectedKontakt = _selectedKontakt;
                    if (dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value.ToString() != "")
                    {
                        KontaktMenetKozben.textNev.Enabled = false;
                        KontaktMenetKozben.textNev.SelectedValue = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value);
                        KontaktMenetKozben.textNev.Text = dataGVKontakt.Rows[_selectedKontakt].Cells["comboNev"].Value.ToString();
                        
                        KontaktMenetKozben.CBPartner.SelectedValue = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["pid"].Value);
                        KontaktMenetKozben.CBPartner.Text = dataGVKontakt.Rows[_selectedKontakt].Cells["partner_azonosito"].Value.ToString();
                        KontaktMenetKozben.kontaktIndex = Convert.ToInt32(dataGVKontakt.Rows[_selectedKontakt].Cells["kontakt_id"].Value);
                        DataRow[] r = tableKontakt.Select("id = " + KontaktMenetKozben.kontaktIndex);
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (KontaktMenetKozben == null)
            {
                KontaktMenetKozben = new KontaktMenetKozben(this);
                KontaktMenetKozben._selectedKontakt = tablePK.Rows.Count;
                KontaktMenetKozben.kontaktIndex = 0;
                KontaktMenetKozben.kontaktRow = null;
                valtozokTor(KontaktMenetKozben.panel1.Controls);
                KontaktMenetKozben.Text = "Kontakt személy hozzárendelése";
            }
            if (KontaktMenetKozben.ShowDialog() == DialogResult.OK)
            {
            }
            KontaktMenetKozben = null;
        }

        public void textKeres_SelectedIndexChanged(object sender, EventArgs e)
        {
            datTol.Value = Convert.ToDateTime("2000.01.01");
            buttonKeres_Click(sender, e);
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedKontakt > -1)
            {
                if (tablePK.Rows[_selectedKontakt]["projekt_kontakt_id"].ToString() != "")
                {
                    DataRow[] r = tableProjektKontakt.Select("id = " + tablePK.Rows[_selectedKontakt]["projekt_kontakt_id"].ToString());
                    tableProjektKontakt.Rows[tableProjektKontakt.Rows.IndexOf(r[0])].Delete();
                }
                tablePK.Rows[_selectedKontakt].Delete();
            }
        }

        private void dataGVKontakt_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["projekt_kontakt_id"].Value.ToString() != "")
            {
                DataRow[] r = tableProjektKontakt.Select("id = " + e.Row.Cells["projekt_kontakt_id"].Value.ToString());
                tableProjektKontakt.Rows[tableProjektKontakt.Rows.IndexOf(r[0])].Delete();
            }
        }

    }

    public class _Combo
    {
        public int index;
        public string text;
        public object value;
    }
}


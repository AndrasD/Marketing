using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

namespace marketing
{
    public partial class printForm : Form
    {
        private ReportDocument rpt1 = new report1();
        private DataSet ds = new DataSet();
        private DataTable tableProjekt = new DataTable();
        private DataTable tableProjektTetel = new DataTable();
        private SqlDataAdapter da;
        private SqlConnection connection;
        private DateTime datTol;
        private DateTime datIg;
        private string dolgozoNev;


        public printForm()
        {
            InitializeComponent();
        }

        public void reportSet(DataTable dT, SqlConnection con, DateTime dTol, DateTime dIg, String dolgozo)
        {
            tableProjekt = dT.Copy();
            connection = con;
            datTol = dTol;
            datIg = dIg;
            dolgozoNev = dolgozo;
        }

        private void printForm_Load(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            ds.Tables.Add(tableProjekt);
            tableProjektTetel.Clear();
            da = new SqlDataAdapter("select * from projekt_tetel order by projekt_id, id", connection);
            da.Fill(ds, "tableProjektTetel");
            tableProjektTetel = ds.Tables["tableProjektTetel"];

            rpt1.SetDataSource(ds);
            rpt1.SetParameterValue("datTol", datTol.ToShortDateString());
            rpt1.SetParameterValue("datIg", datIg.ToShortDateString());
            rpt1.SetParameterValue("dolgozo", dolgozoNev);
            crystalReportViewer.ReportSource = rpt1;
        }

    }
}

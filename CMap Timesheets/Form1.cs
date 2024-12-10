using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMap_Timesheets
{
    public partial class Form1 : Form
    {

        DataTable dtTimesheetEntries;

        public Form1()
        {
            InitializeComponent();

            /// Create DataTable for in-memory storage
            dtTimesheetEntries = new DataTable();
            dtTimesheetEntries.Columns.Add("colUser", typeof(string));
            dtTimesheetEntries.Columns.Add("colDate", typeof(DateTime));
            dtTimesheetEntries.Columns.Add("colProject", typeof(string));
            dtTimesheetEntries.Columns.Add("colDescription", typeof(string));
            dtTimesheetEntries.Columns.Add("colHours", typeof(decimal));
            dtTimesheetEntries.Columns.Add("colTotalHours", typeof(decimal));

            /// Link DataTable to readonly DataGridView
            dgvAllEntries.DataSource = dtTimesheetEntries;

            /// Adjust columns so they match the Entry
            foreach (DataGridViewColumn col in dgvEntry.Columns)
            {
                dgvAllEntries.Columns[col.Name].HeaderText = col.HeaderText;
                dgvAllEntries.Columns[col.Name].AutoSizeMode = col.AutoSizeMode;
                if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
                {
                    dgvAllEntries.Columns[col.Name].Width = col.Width;
                }
            }
        }

        public void AddRowToDataTable(DataTable dataTable, ref DataGridView dataGridView)
        {
            DataGridViewCellCollection cells = dataGridView.Rows[0].Cells;

            DataRow newRow = dataTable.NewRow();
            foreach (DataGridViewColumn col in dataGridView.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible == true))
            {
                newRow[col.Name] = cells[col.Name].FormattedValue;
            }

            dataTable.Rows.Add(newRow);

            dataGridView.Rows.Clear();

        }

        public void ComputeTotalHours(DataTable dataTable, string userName, string workDate)
        {
            string filter = $"colUser='{userName}' AND colDate='{workDate}'";

            //  Compute the sum of hours for this user/date
            var sum = dataTable.Compute($"SUM(colHours)", filter);

            //  Update the relevant row(s) in the Table 
            foreach (DataRow dataRow in dataTable.Select(filter))
            {
                dataRow["colTotalHours"] = sum;
            }
        }
    }
}

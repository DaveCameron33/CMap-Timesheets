using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            dgvEntry.Rows.Add();    //  Empty Row for first entry

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            /// Make sure entry is complete
            foreach (DataGridViewCell cell in dgvEntry.Rows[0].Cells)
            {
                if (cell.Visible == true && string.IsNullOrEmpty("" + cell.Value))
                {
                    cell.Selected = true;
                    return;
                }
            }

            /// Send DataGridViewRow to DataTable
            AddRowToDataTable(dtTimesheetEntries, ref dgvEntry);

            /// Compute Total Hours related to THIS entry
            DataRow dataRow = dtTimesheetEntries.Select().Last();
            ComputeTotalHours(dtTimesheetEntries, dataRow["colUser"].ToString(), dataRow["colDate"].ToString());

            /// Add new, empty Row
            dgvEntry.Rows.Add();

            /// Set focus on first Cell
            dgvEntry.Select();

        }

        private void dgvEntry_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            var cellContents = dgvEntry.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (dgvEntry.Columns[e.ColumnIndex].Name)
            {
                case "colDate":
                    /// if colDate then reformat as Date
                    DateTime date;
                    DateTime.TryParse(cellContents.FormattedValue.ToString(),out date);
                    if (date.ToString() == "01/01/0001 00:00:00")
                    {
                        cellContents.Value = ""; 
                    }
                    else
                    {
                        cellContents.Value = DateTime.Parse(cellContents.FormattedValue.ToString()).ToShortDateString();
                    }
                    break;
                case "colHours":
                    /// if colHours is not positive number then clear it
                 decimal hours;
                    decimal.TryParse(cellContents.Value.ToString(), out hours);
                    if (hours <= 0)
                    {
                        cellContents.Value = "";
                    }
                    break;
            }
        }

        public (String, int) ExportToCSVString(DataTable dataTable, DataGridViewColumnCollection dataGridViewColumns)
        {

            int lines = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                "\"" + string.Join("\",\"", dataGridViewColumns.Cast<DataGridViewColumn>().Select(c => c.HeaderText)) + "\"");

            lines++;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                stringBuilder.AppendLine("\"" + string.Join("\",\"", dataRow.ItemArray) + "\"");
                lines++;
            }

            return (stringBuilder.ToString(), lines);

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            (string csvString, int rows) = ExportToCSVString(dtTimesheetEntries, dgvAllEntries.Columns);
            bool abort;

            if (rows <= 1)
            {
                if (MessageBox.Show(
                    "Table contains no Timesheet data. Only Header will be exported.\n\nContinue?",
                    "Exporting Timesheet Data",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                };
            }
 
            string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"Timesheets{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
            using (StreamWriter writer = new StreamWriter(fileName,false))
            {
                writer.Write(csvString);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

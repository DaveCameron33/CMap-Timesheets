///
/// https://github.com/DaveCameron33/CMap-Timesheets
/// 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CMap_Timesheets.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private Form1_Test form1;
        private DataGridView dgvEntry_Test;
        private DataTable dtTimesheetEntries;

        public UnitTest1()
        {
            dgvEntry_Test = new DataGridView();
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colUser", HeaderText = "User Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, CellTemplate = new DataGridViewTextBoxCell() });
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colDate", HeaderText = "Date", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, CellTemplate = new DataGridViewTextBoxCell() });
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colProject", HeaderText = "Project", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, CellTemplate = new DataGridViewTextBoxCell() });
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colDescription", HeaderText = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, CellTemplate = new DataGridViewTextBoxCell() });
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colHours", HeaderText = "Hours Worked", AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, CellTemplate = new DataGridViewTextBoxCell() });
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colTotalHours", HeaderText = "Total Hours for the Day", AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, CellTemplate = new DataGridViewTextBoxCell(), Visible = false });

            dtTimesheetEntries = new DataTable();
            dtTimesheetEntries.Columns.Add("colUser", typeof(string));
            dtTimesheetEntries.Columns.Add("colDate", typeof(DateTime));
            dtTimesheetEntries.Columns.Add("colProject", typeof(string));
            dtTimesheetEntries.Columns.Add("colDescription", typeof(string));
            dtTimesheetEntries.Columns.Add("colHours", typeof(decimal));
            dtTimesheetEntries.Columns.Add("colTotalHours", typeof(decimal));

            form1 = new Form1_Test();

        }

        [TestMethod]
        public void DataIsAddedToDataTable()
        {
            /// Arrange
            dgvEntry_Test.Rows.Add("Dave", "06/12/2024", "My First Project", "Setting up for the first time", 1d);

            /// Act
            form1.AddRowToDataTable(dtTimesheetEntries, ref dgvEntry_Test);

            /// Assert
            Assert.IsTrue(dtTimesheetEntries.Rows.Count == 1);  //  Row was added
            Assert.IsTrue(dgvEntry_Test.Rows.Count == 1);       //  Entered row was 'cleared from form'

        }
    }

    class Form1_Test: Form1
    {
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
    }
}

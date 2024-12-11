///
/// https://github.com/DaveCameron33/CMap-Timesheets
/// 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Text;

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
            dgvEntry_Test.Columns.Add(new DataGridViewColumn() { Name = "colDescription", HeaderText = "Description of Tasks", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, CellTemplate = new DataGridViewTextBoxCell() });
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

        [TestMethod]
        public void ComputeTotalHoursUpdatesHours()
        {

            /// Arrange
            dgvEntry_Test.Rows.Add("Dave", "06/12/2024", "My First Project", "Setting up for the first time", 1d);

            /// Act
            form1.AddRowToDataTable(dtTimesheetEntries, ref dgvEntry_Test);
            form1.ComputeTotalHours(dtTimesheetEntries, "Dave", "06/12/2024");

            /// Assert
            Assert.IsTrue(dtTimesheetEntries.Rows.Count == 1);  //  Row was added
            Assert.IsTrue((decimal)dtTimesheetEntries.Select().Last()["colTotalHours"] == 1);  //  Row was added

        }

        [TestMethod]
        public void ComputeTotalHoursUpdatesHoursForMultipleEntries()
        {

            /// Arrange
            /// Adding these direct to the DataTable - the AddRowToDataTable method has been proven to work
            AddMultipleEntriesToDataTable();

            /// Act
            DataView dataView = new DataView(dtTimesheetEntries);
            foreach (DataRow dataRow in dataView.ToTable(true, "colUser", "colDate").Rows)
            {
                form1.ComputeTotalHours(dtTimesheetEntries, dataRow["colUser"].ToString(), dataRow["colDate"].ToString());
            }


            /// Assert
            Assert.AreEqual(4.0m, dtTimesheetEntries.Rows[0]["colTotalHours"]);  //  Row(s) 0+1 : 1+3=4
            Assert.AreEqual(4.0m, dtTimesheetEntries.Rows[1]["colTotalHours"]);  //  Row(s) 0+1 : 1+3=4
            Assert.AreEqual(6.0m, dtTimesheetEntries.Rows[2]["colTotalHours"]);  //  Row(s) 2   : 6
            Assert.AreEqual(7.5m, dtTimesheetEntries.Rows[3]["colTotalHours"]);  //  Row(s) 3+4 : 2.5+5=7.5
            Assert.AreEqual(7.5m, dtTimesheetEntries.Rows[4]["colTotalHours"]);  //  Row(s) 3+4 : 2.5+5=7.5

        }

        [TestMethod]
        public void ExportingToCSVCreatesWritableString()
        {

            /// Arrange
            AddMultipleEntriesToDataTable();

            DataView dataView = new DataView(dtTimesheetEntries);
            foreach (DataRow dataRow in dataView.ToTable(true, "colUser", "colDate").Rows)
            {
                form1.ComputeTotalHours(dtTimesheetEntries, dataRow["colUser"].ToString(), dataRow["colDate"].ToString());
            }

            /// Act
            (string csvString, int lines) = form1.ExportToCSVString(dtTimesheetEntries, dgvEntry_Test.Columns);

            /// Assert
            Assert.IsFalse(String.IsNullOrEmpty(csvString));    /// Check it's a string
            Assert.AreEqual(6, lines);                          /// Check it contains 6 lines (header + 5 entries)
        }


        private void AddMultipleEntriesToDataTable()
        {
            dtTimesheetEntries.Rows.Add("Dave", "06/12/2024", "My First Project", "Setting up for the first time", 1);
            dtTimesheetEntries.Rows.Add("Dave", "06/12/2024", "My First Project", "done some more work", 3);
            dtTimesheetEntries.Rows.Add("Daniel", "06/12/2024", "My First Project", "Someone else's hours", 6);
            dtTimesheetEntries.Rows.Add("Dave", "09/12/2024", "My First Project", "Bit more work", 2.5);
            dtTimesheetEntries.Rows.Add("Dave", "09/12/2024", "My Second Project", "Something else", 5);
        }
    }

    class Form1_Test : Form1
    {
    }
}
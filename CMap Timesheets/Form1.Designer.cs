namespace CMap_Timesheets
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.dgvEntry = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpEntries = new System.Windows.Forms.GroupBox();
            this.dgvAllEntries = new System.Windows.Forms.DataGridView();
            this.grpEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).BeginInit();
            this.grpButtons.SuspendLayout();
            this.grpEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.dgvEntry);
            this.grpEntry.Controls.Add(this.btnAdd);
            this.grpEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEntry.Location = new System.Drawing.Point(0, 0);
            this.grpEntry.Margin = new System.Windows.Forms.Padding(8);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Padding = new System.Windows.Forms.Padding(15);
            this.grpEntry.Size = new System.Drawing.Size(1154, 140);
            this.grpEntry.TabIndex = 1;
            this.grpEntry.TabStop = false;
            this.grpEntry.Text = "New Entry";
            // 
            // dgvEntry
            // 
            this.dgvEntry.AllowUserToAddRows = false;
            this.dgvEntry.AllowUserToDeleteRows = false;
            this.dgvEntry.AllowUserToOrderColumns = true;
            this.dgvEntry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUser,
            this.colDate,
            this.colProject,
            this.colDescription,
            this.colHours,
            this.colTotalHours});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntry.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEntry.Location = new System.Drawing.Point(15, 34);
            this.dgvEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvEntry.MultiSelect = false;
            this.dgvEntry.Name = "dgvEntry";
            this.dgvEntry.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntry.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEntry.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvEntry.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgvEntry.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntry.RowTemplate.Height = 40;
            this.dgvEntry.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntry.Size = new System.Drawing.Size(1024, 91);
            this.dgvEntry.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(1039, 34);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 91);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // colUser
            // 
            this.colUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUser.HeaderText = "User Name";
            this.colUser.Name = "colUser";
            this.colUser.Width = 114;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Width = 69;
            // 
            // colProject
            // 
            this.colProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProject.HeaderText = "Project";
            this.colProject.Name = "colProject";
            this.colProject.Width = 83;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colHours
            // 
            this.colHours.HeaderText = "Hours Worked";
            this.colHours.Name = "colHours";
            // 
            // colTotalHours
            // 
            this.colTotalHours.HeaderText = "Total Hours for the Day";
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.Visible = false;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnExit);
            this.grpButtons.Controls.Add(this.btnExport);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 422);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(1154, 81);
            this.grpButtons.TabIndex = 11;
            this.grpButtons.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExport.Location = new System.Drawing.Point(3, 22);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 56);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(1060, 22);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 56);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // grpEntries
            // 
            this.grpEntries.Controls.Add(this.dgvAllEntries);
            this.grpEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEntries.Location = new System.Drawing.Point(0, 140);
            this.grpEntries.Margin = new System.Windows.Forms.Padding(8);
            this.grpEntries.Name = "grpEntries";
            this.grpEntries.Padding = new System.Windows.Forms.Padding(15);
            this.grpEntries.Size = new System.Drawing.Size(1154, 282);
            this.grpEntries.TabIndex = 12;
            this.grpEntries.TabStop = false;
            this.grpEntries.Text = "Current Entries";
            // 
            // dgvAllEntries
            // 
            this.dgvAllEntries.AllowUserToAddRows = false;
            this.dgvAllEntries.AllowUserToDeleteRows = false;
            this.dgvAllEntries.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllEntries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllEntries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAllEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllEntries.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAllEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllEntries.Enabled = false;
            this.dgvAllEntries.Location = new System.Drawing.Point(15, 34);
            this.dgvAllEntries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAllEntries.MultiSelect = false;
            this.dgvAllEntries.Name = "dgvAllEntries";
            this.dgvAllEntries.RowHeadersVisible = false;
            this.dgvAllEntries.Size = new System.Drawing.Size(1124, 233);
            this.dgvAllEntries.TabIndex = 7;
            this.dgvAllEntries.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 503);
            this.Controls.Add(this.grpEntries);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.grpEntry);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "CMap Timesheet Test";
            this.grpEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).EndInit();
            this.grpButtons.ResumeLayout(false);
            this.grpEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.DataGridView dgvEntry;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHours;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox grpEntries;
        private System.Windows.Forms.DataGridView dgvAllEntries;
    }
}


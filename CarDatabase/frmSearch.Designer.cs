
namespace CarDatabase
{
    partial class frmSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalPerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRegistered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngineSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleRegNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.cboOperator);
            this.groupBox1.Controls.Add(this.cboField);
            this.groupBox1.Location = new System.Drawing.Point(38, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Operator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Field";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(438, 74);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(203, 26);
            this.txtValue.TabIndex = 2;
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">="});
            this.cboOperator.Location = new System.Drawing.Point(301, 74);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(65, 28);
            this.cboOperator.TabIndex = 1;
            this.cboOperator.Text = "=";
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Items.AddRange(new object[] {
            "Make",
            "Engine Size",
            "Rental Per Day",
            "Available"});
            this.cboField.Location = new System.Drawing.Point(16, 74);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(195, 28);
            this.cboField.TabIndex = 0;
            this.cboField.Text = "Engine Size";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(743, 53);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(136, 51);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(743, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 51);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleRegNo,
            this.Make,
            this.EngineSize,
            this.DateRegistered,
            this.RentalPerDay,
            this.Available});
            this.dgvCars.Location = new System.Drawing.Point(38, 174);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowHeadersWidth = 62;
            this.dgvCars.RowTemplate.Height = 28;
            this.dgvCars.Size = new System.Drawing.Size(873, 228);
            this.dgvCars.TabIndex = 3;
            // 
            // Available
            // 
            this.Available.HeaderText = "Available";
            this.Available.MinimumWidth = 8;
            this.Available.Name = "Available";
            this.Available.Width = 90;
            // 
            // RentalPerDay
            // 
            this.RentalPerDay.HeaderText = "RentalPerDay";
            this.RentalPerDay.MinimumWidth = 8;
            this.RentalPerDay.Name = "RentalPerDay";
            this.RentalPerDay.Width = 140;
            // 
            // DateRegistered
            // 
            this.DateRegistered.HeaderText = "DateRegistered";
            this.DateRegistered.MinimumWidth = 8;
            this.DateRegistered.Name = "DateRegistered";
            this.DateRegistered.Width = 140;
            // 
            // EngineSize
            // 
            this.EngineSize.HeaderText = "EngineSize";
            this.EngineSize.MinimumWidth = 8;
            this.EngineSize.Name = "EngineSize";
            this.EngineSize.Width = 150;
            // 
            // Make
            // 
            this.Make.HeaderText = "Make";
            this.Make.MinimumWidth = 8;
            this.Make.Name = "Make";
            this.Make.Width = 150;
            // 
            // VehicleRegNo
            // 
            this.VehicleRegNo.HeaderText = "VehicleRegNo";
            this.VehicleRegNo.MinimumWidth = 8;
            this.VehicleRegNo.Name = "VehicleRegNo";
            this.VehicleRegNo.Width = 140;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 450);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleRegNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Make;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngineSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRegistered;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentalPerDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available;
    }
}
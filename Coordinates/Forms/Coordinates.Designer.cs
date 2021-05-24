namespace BBI.JD.Forms
{
    partial class Coordinates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Coordinates));
            this.btn_Excel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ExcelPath = new System.Windows.Forms.TextBox();
            this.grid_Coordinates = new System.Windows.Forms.DataGridView();
            this.cX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmb_SurveyPoint = new System.Windows.Forms.ComboBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Pined = new System.Windows.Forms.Label();
            this.cmb_Point = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Coordinates)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Excel
            // 
            this.btn_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Excel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Excel.Location = new System.Drawing.Point(391, 40);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(36, 23);
            this.btn_Excel.TabIndex = 2;
            this.btn_Excel.Text = "...";
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Coordinates\'s Excel";
            // 
            // txt_ExcelPath
            // 
            this.txt_ExcelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ExcelPath.Location = new System.Drawing.Point(15, 42);
            this.txt_ExcelPath.Name = "txt_ExcelPath";
            this.txt_ExcelPath.ReadOnly = true;
            this.txt_ExcelPath.Size = new System.Drawing.Size(372, 20);
            this.txt_ExcelPath.TabIndex = 1;
            this.txt_ExcelPath.TextChanged += new System.EventHandler(this.txt_ExcelPath_TextChanged);
            // 
            // grid_Coordinates
            // 
            this.grid_Coordinates.AllowUserToAddRows = false;
            this.grid_Coordinates.AllowUserToDeleteRows = false;
            this.grid_Coordinates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Coordinates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Coordinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Coordinates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cX,
            this.cY,
            this.cZ,
            this.cTag});
            this.grid_Coordinates.Location = new System.Drawing.Point(15, 98);
            this.grid_Coordinates.Name = "grid_Coordinates";
            this.grid_Coordinates.ReadOnly = true;
            this.grid_Coordinates.Size = new System.Drawing.Size(412, 209);
            this.grid_Coordinates.TabIndex = 3;
            // 
            // cX
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.cX.DefaultCellStyle = dataGridViewCellStyle1;
            this.cX.HeaderText = "X";
            this.cX.Name = "cX";
            this.cX.ReadOnly = true;
            this.cX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cX.ToolTipText = "North/South";
            // 
            // cY
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.cY.DefaultCellStyle = dataGridViewCellStyle2;
            this.cY.HeaderText = "Y";
            this.cY.Name = "cY";
            this.cY.ReadOnly = true;
            this.cY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cY.ToolTipText = "East/West";
            // 
            // cZ
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.cZ.DefaultCellStyle = dataGridViewCellStyle3;
            this.cZ.HeaderText = "Z";
            this.cZ.Name = "cZ";
            this.cZ.ReadOnly = true;
            this.cZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cZ.ToolTipText = "Elevation";
            // 
            // cTag
            // 
            this.cTag.HeaderText = "Tag";
            this.cTag.Name = "cTag";
            this.cTag.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Coordinates";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Edit.Image = global::Coordinates.Properties.Resources.btn_edit;
            this.btn_Edit.Location = new System.Drawing.Point(193, 313);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(25, 25);
            this.btn_Edit.TabIndex = 5;
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Image = global::Coordinates.Properties.Resources.btn_add;
            this.btn_Add.Location = new System.Drawing.Point(155, 313);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(25, 25);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Image = global::Coordinates.Properties.Resources.btn_delete;
            this.btn_Delete.Location = new System.Drawing.Point(231, 313);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(25, 25);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Spreadsheets|*.xls;*.xlsx";
            // 
            // cmb_SurveyPoint
            // 
            this.cmb_SurveyPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SurveyPoint.FormattingEnabled = true;
            this.cmb_SurveyPoint.Items.AddRange(new object[] {
            "None",
            "Centroid polygon",
            "Point on the list"});
            this.cmb_SurveyPoint.Location = new System.Drawing.Point(15, 395);
            this.cmb_SurveyPoint.Name = "cmb_SurveyPoint";
            this.cmb_SurveyPoint.Size = new System.Drawing.Size(170, 21);
            this.cmb_SurveyPoint.TabIndex = 7;
            this.cmb_SurveyPoint.SelectedIndexChanged += new System.EventHandler(this.cmb_SurveyPoint_SelectedIndexChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(262, 445);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(352, 445);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_Pined
            // 
            this.lbl_Pined.AutoSize = true;
            this.lbl_Pined.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_Pined.ForeColor = System.Drawing.Color.Red;
            this.lbl_Pined.Location = new System.Drawing.Point(118, 355);
            this.lbl_Pined.Name = "lbl_Pined";
            this.lbl_Pined.Size = new System.Drawing.Size(204, 14);
            this.lbl_Pined.TabIndex = 8;
            this.lbl_Pined.Text = "Unpin Survey Point to update it";
            this.lbl_Pined.Visible = false;
            // 
            // cmb_Point
            // 
            this.cmb_Point.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Point.Enabled = false;
            this.cmb_Point.FormattingEnabled = true;
            this.cmb_Point.Items.AddRange(new object[] {
            "None",
            "Centroid polygon",
            "Point on the list"});
            this.cmb_Point.Location = new System.Drawing.Point(241, 395);
            this.cmb_Point.Name = "cmb_Point";
            this.cmb_Point.Size = new System.Drawing.Size(170, 21);
            this.cmb_Point.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(238, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Points";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Survey Point";
            // 
            // Coordinates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(439, 480);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Pined);
            this.Controls.Add(this.cmb_Point);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.cmb_SurveyPoint);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid_Coordinates);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ExcelPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Coordinates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coordinates";
            this.Load += new System.EventHandler(this.Coordinates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Coordinates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ExcelPath;
        private System.Windows.Forms.DataGridView grid_Coordinates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn cX;
        private System.Windows.Forms.DataGridViewTextBoxColumn cY;
        private System.Windows.Forms.DataGridViewTextBoxColumn cZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTag;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmb_SurveyPoint;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Pined;
        private System.Windows.Forms.ComboBox cmb_Point;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
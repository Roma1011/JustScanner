using System.Windows.Forms;

namespace FolderScanner
{
    partial class ScannerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerForm));
            MainTextBox = new TextBox();
            objectNameLabel = new Label();
            GetPathButton = new Button();
            SaveAsXlsx = new Button();
            DataGrid = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            AllTypeCheckBox = new CheckBox();
            ClearButton = new Button();
            SearchBox = new TextBox();
            SearchButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // MainTextBox
            // 
            MainTextBox.Location = new Point(186, 24);
            MainTextBox.Name = "MainTextBox";
            MainTextBox.ReadOnly = true;
            MainTextBox.Size = new Size(402, 23);
            MainTextBox.TabIndex = 0;
            // 
            // objectNameLabel
            // 
            objectNameLabel.AutoSize = true;
            objectNameLabel.Location = new Point(40, 27);
            objectNameLabel.Name = "objectNameLabel";
            objectNameLabel.Size = new Size(142, 15);
            objectNameLabel.TabIndex = 1;
            objectNameLabel.Text = "ობიექტის მდებაროება";
            // 
            // GetPathButton
            // 
            GetPathButton.Image = (Image)resources.GetObject("GetPathButton.Image");
            GetPathButton.Location = new Point(594, 5);
            GetPathButton.Name = "GetPathButton";
            GetPathButton.Size = new Size(80, 59);
            GetPathButton.TabIndex = 2;
            GetPathButton.UseVisualStyleBackColor = true;
            GetPathButton.Click += GetPathButton_Click;
            // 
            // SaveAsXlsx
            // 
            SaveAsXlsx.Image = (Image)resources.GetObject("SaveAsXlsx.Image");
            SaveAsXlsx.Location = new Point(690, 5);
            SaveAsXlsx.Name = "SaveAsXlsx";
            SaveAsXlsx.Size = new Size(75, 59);
            SaveAsXlsx.TabIndex = 3;
            SaveAsXlsx.UseVisualStyleBackColor = true;
            SaveAsXlsx.Click += SaveAsXlsx_Click;
            // 
            // DataGrid
            // 
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Columns.AddRange(new DataGridViewColumn[] { Name });
            DataGrid.Location = new Point(1, 169);
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            DataGrid.Size = new Size(797, 392);
            DataGrid.TabIndex = 4;
            // 
            // Name
            // 
            Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Name.HeaderText = "დასახელება";
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // AllTypeCheckBox
            // 
            AllTypeCheckBox.AutoSize = true;
            AllTypeCheckBox.BackColor = SystemColors.ButtonShadow;
            AllTypeCheckBox.Checked = true;
            AllTypeCheckBox.CheckState = CheckState.Checked;
            AllTypeCheckBox.Location = new Point(649, 144);
            AllTypeCheckBox.Name = "AllTypeCheckBox";
            AllTypeCheckBox.Size = new Size(149, 19);
            AllTypeCheckBox.TabIndex = 5;
            AllTypeCheckBox.Text = "ყველა ტიპის ფაილი";
            AllTypeCheckBox.UseVisualStyleBackColor = false;
            AllTypeCheckBox.CheckedChanged += AllTypeCheckBox_CheckedChanged;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(535, 139);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(108, 28);
            ClearButton.TabIndex = 6;
            ClearButton.Text = "გასუფთავება";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(171, 142);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(258, 23);
            SearchBox.TabIndex = 7;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(435, 142);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 9;
            SearchButton.Text = "ძებნა";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 600);
            Controls.Add(SearchButton);
            Controls.Add(SearchBox);
            Controls.Add(ClearButton);
            Controls.Add(AllTypeCheckBox);
            Controls.Add(DataGrid);
            Controls.Add(SaveAsXlsx);
            Controls.Add(GetPathButton);
            Controls.Add(objectNameLabel);
            Controls.Add(MainTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(820, 643);
            MinimumSize = new Size(820, 643);
            Text = "Scanner";
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MainTextBox;
        private Label objectNameLabel;
        private Button GetPathButton;
        private Button SaveAsXlsx;
        private DataGridView DataGrid;
        private DataGridViewTextBoxColumn Name;
        private CheckBox AllTypeCheckBox;
        private Button ClearButton;
        private TextBox SearchBox;
        private Button SearchButton;
    }
}

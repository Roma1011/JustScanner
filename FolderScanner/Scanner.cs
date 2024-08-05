using FolderScanner.Dto;
using ClosedXML.Excel;
using System;

namespace FolderScanner
{
    public partial class ScannerForm : Form
    {
        private FolderFileWhereHouse folderFileWhereHouse;
        public ScannerForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += ScannerForm_DragDrop;
            this.DragEnter += ScannerForm_DragEnter;
        }

        private void ScannerForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ScannerForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedItems = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (IsFolder(droppedItems[0]))
            {
                FillWhereHouse(droppedItems[0]);
                LoadDataGridViewData(folderFileWhereHouse);
            }
            else
            {
                MessageBox.Show("ფორმატი არასწორია", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillWhereHouse(string path)
        {
            DataGrid.Rows.Clear();
            folderFileWhereHouse = new FolderFileWhereHouse(new List<string[]>());
            if (AllTypeCheckBox.Checked)
            {
                folderFileWhereHouse.FileFolderWhereHouse.Add(Directory.GetDirectories(path));
                folderFileWhereHouse.FileFolderWhereHouse.Add(Directory.GetFiles(path));
            }
            else
                folderFileWhereHouse.FileFolderWhereHouse.Add(Directory.GetDirectories(path));
            MainTextBox.Text = path;
        }

        private bool IsFolder(string path)
        {
            FileAttributes attr = System.IO.File.GetAttributes(path);
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private void LoadDataGridViewData(FolderFileWhereHouse whereHouse)
        {
            FileInfo fileInfo;
            foreach (var file in whereHouse.FileFolderWhereHouse)
            {
                foreach (var item in file)
                {
                    var res = Path.GetExtension(item).Trim();
                    if (res == "")
                        fileInfo = new FileInfo(item);
                    else
                        fileInfo = new FileInfo(item.Replace(res, ""));

                    DataGrid.Rows.Add(fileInfo.Name);
                }
            }
        }

        private void AllTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        { }

        private void SaveAsXlsx_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "Excel file|*.xlsx";
            saveFile1.Title = "Save Results as Excel Spreadsheet";
            saveFile1.FileName = DateTime.Now.ToString("yyMMdd") + ".xlsx";
            if (saveFile1.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(() => Save(ref saveFile1));
                t.Start();
                t.Join();
            }

        }
        private bool Save(ref SaveFileDialog saveFile1)
        {
            try
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Data");

                ws.Cell(1, 1).Value = DataGrid.Columns[0].HeaderText;

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    object cellValue = DataGrid.Rows[i].Cells[0].Value;
                    string cellText = cellValue != null ? cellValue.ToString() : "";
                    ws.Cell(i + 2, 1).Value = cellText;
                }

                wb.SaveAs(saveFile1.FileName);
                MessageBox.Show("შემახვა წარმატებით განხორციელდა");
            }
            catch (Exception exception)
            {
                MessageBox.Show("შეცდომა", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;

        }

        private void GetPathButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    filePath = folderBrowserDialog.SelectedPath;
                    FillWhereHouse(filePath);
                    LoadDataGridViewData(folderFileWhereHouse);
                    MainTextBox.Text = filePath;
                }
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            folderFileWhereHouse = default;
            MainTextBox.Text = string.Empty;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchValue = SearchBox.Text;
            DataGrid.ClearSelection();
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in DataGrid.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("სიტყვის ზუსტი მსგავსება ვერ მოიძებნა");
            }
        }
    }
}

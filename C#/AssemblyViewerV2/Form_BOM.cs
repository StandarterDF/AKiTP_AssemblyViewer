using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace AssemblyViewerV2
{
    public partial class Form_BOM : Form
    {
        public static Utils.Types.Assemblies Assembly;
        public Form_BOM()
        {
            InitializeComponent();
        }

        public Form_BOM(Utils.Types.Assemblies Assembly)
        {
            InitializeComponent();
            Form_BOM.Assembly = Assembly;
        }

        private void Form_BOM_Load(object sender, EventArgs e)
        {
            try
            {
                var partsList = Utils.SQLUtils.GetParts(Form_BOM.Assembly.ID);

                var bindingSource = new BindingSource();
                bindingSource.DataSource = partsList;
                TableSQL_BOM.DataSource = bindingSource;
                TableSQL_BOM.AutoGenerateColumns = true;
                TableSQL_BOM.Columns["Photo"].Visible = false;
                TableSQL_BOM.Refresh();

                int Count = 0;
                int CountStandart = 0;
                int Price = 0;
                foreach (Utils.Types.Parts Part in partsList)
                {
                    Count += Part.Count;
                    CountStandart += Part.isStandartPart ? Part.Count : 0;
                    Price += Part.Count * Part.Price;
                }

                TextBox_Count.Text = Count.ToString();
                TextBox_CountStandart.Text = CountStandart.ToString();
                TextBox_Price.Text = Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_ExportBOM_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Сохранить спецификацию как...";
                saveFileDialog.FileName = $"Спецификация ({Assembly.Name}).xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = saveFileDialog.FileName;

                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;

                try
                {
                    // Фильтруем колонки
                    var columnsToExport = TableSQL_BOM.Columns.Cast<DataGridViewColumn>()
                        .Where(col => col.Name != "Photo" && col.Name != "ID_Assembly" && col.Name != "ID")
                        .ToList();

                    excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Заголовки
                    for (int i = 0; i < columnsToExport.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = columnsToExport[i].HeaderText;
                    }

                    // Данные
                    for (int rowIndex = 0; rowIndex < TableSQL_BOM.RowCount - 1; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < columnsToExport.Count; colIndex++)
                        {
                            var cellValue = TableSQL_BOM.Rows[rowIndex].Cells[columnsToExport[colIndex].Index].Value;
                            worksheet.Cells[rowIndex + 2, colIndex + 1] = cellValue ?? string.Empty;
                        }
                    }

                    workbook.SaveAs(filePath);
                    MessageBox.Show("Данные успешно экспортированы в Excel!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (workbook != null)
                    {
                        workbook.Close();
                        Marshal.ReleaseComObject(workbook);
                    }
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}

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

using Wp = DocumentFormat.OpenXml.Wordprocessing;
using Dml = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using Oxml = DocumentFormat.OpenXml;
using OxmlPack = DocumentFormat.OpenXml.Packaging;

using AssemblyViewerV2.Utils;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;

namespace AssemblyViewerV2
{
    public partial class ProgramMainForm : Form
    {
        public static int Assembly_ID;
        public static string Assembly_Name;
        public static int RowSelected_DetailID = -1;
        public ProgramMainForm()
        {
            InitializeComponent();
        }

        private void ProgramMainForm_Load(object sender, EventArgs e)
        {
            var assemblyList = new List<AssemblyItem>();
            foreach (Utils.Types.Assemblies Assembly in Utils.SQLUtils.GetAssemblies())
            {
                assemblyList.Add(
                    new AssemblyItem
                    {
                        Assembly = Assembly
                    }
                );
            }

            ComboBox_SelectAssembly.DisplayMember = "DisplayText";
            ComboBox_SelectAssembly.ValueMember = "ID";
            ComboBox_SelectAssembly.DataSource = assemblyList;
        }

        private void Button_DetailInfo_Click(object sender, EventArgs e)
        {
            Utils.Types.Parts CurrentPart = Utils.SQLUtils.GetPart(RowSelected_DetailID);
            Form_DetailInfo detailInfo = new Form_DetailInfo("View", CurrentPart);
            detailInfo.Show();
        }

        private void Button_EditDetail_Click(object sender, EventArgs e)
        {
            if (TableSQL_MainWindow.SelectedRows.Count == 1)
            {
                RowSelected_DetailID = Convert.ToInt32(TableSQL_MainWindow.SelectedRows[0].Cells[0].Value);
                Utils.Types.Parts CurrentPart = Utils.SQLUtils.GetPart(RowSelected_DetailID);
                Form_DetailInfo editDetailInfo = new Form_DetailInfo("Edit", CurrentPart);
                editDetailInfo.Show();
            }
            else
            {
                MessageBox.Show("Нет выделенных строк.");
            }
        }

        private void ContextMenu_Info_Click(object sender, EventArgs e)
        {
            Form_ProgramInfo programInfo = new Form_ProgramInfo();
            programInfo.Show();
        }

        private void Button_AssemblyBOM_Click(object sender, EventArgs e)
        {
            Form_BOM form_BOM = new Form_BOM(((AssemblyItem)ComboBox_SelectAssembly.SelectedItem).Assembly);
            form_BOM.Show();
        }

        private void ComboBox_SelectAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = 0;
            string AuthorName = "";
            string Version = "";
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
            Type ComboBoxType = comboBox.SelectedItem.GetType();
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                ID = Convert.ToInt32(((AssemblyItem)comboBox.SelectedItem).Assembly.ID);
                AuthorName = ((AssemblyItem)comboBox.SelectedItem).Assembly.AuthorName;
                Version = ((AssemblyItem)comboBox.SelectedItem).Assembly.Version;
                Assembly_ID = ID;
            }
            TextBox_AuthorName.Text = AuthorName;
            TextBox_Version.Text = Version;
            Utils.SQLUtils.UpdateDataGridView_MainWindow(TableSQL_MainWindow, ID);
        }

        private void TableSQL_MainWindow_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = (DataGridView)sender;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                RowSelected_DetailID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            else
            {
                MessageBox.Show("Нет выделенных строк.");
            }
        }

        private void Button_AddDetail_Click(object sender, EventArgs e)
        {
            Utils.Types.Parts CurrentPart = new Utils.Types.Parts();
            CurrentPart.ID_Assembly = Assembly_ID;

            Form_DetailInfo detailInfo = new Form_DetailInfo("Add", CurrentPart);
            detailInfo.Show();
        }

        private void Button_RemoveDetail_Click(object sender, EventArgs e)
        {
            if (TableSQL_MainWindow.SelectedRows.Count == 1)
            {
                RowSelected_DetailID = Convert.ToInt32(TableSQL_MainWindow.SelectedRows[0].Cells[0].Value);
                if (Utils.SQLUtils.DeletePart(RowSelected_DetailID))
                {
                    MessageBox.Show("Деталь успешно удалена!");
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при удалении детали!");
                }
            }
            else
            {
                MessageBox.Show("Нет выделенных строк.");
            }
        }
        private void Button_AssemblyInfo_Click(object sender, EventArgs e)
        {
            Form_AssemblyInfo assemblyInfo = new Form_AssemblyInfo("View", ((AssemblyItem)ComboBox_SelectAssembly.SelectedItem).Assembly);
            assemblyInfo.Show();
        }
        private void Button_AssemblyEdit_click(object sender, EventArgs e)
        {
            Form_AssemblyInfo assemblyEdit = new Form_AssemblyInfo("Edit", ((AssemblyItem)ComboBox_SelectAssembly.SelectedItem).Assembly);
            assemblyEdit.Show();
        }

        private void Button_AssemblyDelete_Click(object sender, EventArgs e)
        {
            //Form_DeleteAssembly form_DeleteAssembly = new Form_DeleteAssembly(((AssemblyItem)ComboBox_SelectAssembly.SelectedItem).Assembly);
            Form_DeleteAssembly form_DeleteAssembly = new Form_DeleteAssembly(ComboBox_SelectAssembly);
            form_DeleteAssembly.Show();
        }

        private void ContextMenu_CreateAssembly_Click(object sender, EventArgs e)
        {
            Form_AssemblyInfo AssemblyCreate = new Form_AssemblyInfo("Add");
            AssemblyCreate.Show();
        }

        private void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types.Assemblies assembly = new Types.Assemblies();
            List<Types.Parts> parts = new List<Types.Parts>();

            if (ComboBox_SelectAssembly != null && ComboBox_SelectAssembly.SelectedItem != null)
            {
                assembly = ((AssemblyItem)(ComboBox_SelectAssembly.SelectedItem)).Assembly;
                foreach (var part in SQLUtils.GetParts(assembly.ID))
                {
                    parts.Add(part);
                }
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FileName = $"{assembly.Name}_export.xlsx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("DefaultDF");

                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        var assemblyWorksheet = package.Workbook.Worksheets.Add("Сборка");

                        assemblyWorksheet.Cells[1, 1].Value = "ID";
                        assemblyWorksheet.Cells[1, 2].Value = "Название";
                        assemblyWorksheet.Cells[1, 3].Value = "Автор";
                        assemblyWorksheet.Cells[1, 4].Value = "Версия";
                        assemblyWorksheet.Cells[1, 5].Value = "Дата создания";
                        assemblyWorksheet.Cells[1, 6].Value = "Дата проверки";
                        assemblyWorksheet.Cells[1, 7].Value = "Описание";
                        assemblyWorksheet.Cells[1, 8].Value = "Информация";
                        assemblyWorksheet.Cells[1, 9].Value = "Фото (base64)";

                        if (assembly != null)
                        {
                            assemblyWorksheet.Cells[2, 1].Value = assembly.ID;
                            assemblyWorksheet.Cells[2, 2].Value = assembly.Name;
                            assemblyWorksheet.Cells[2, 3].Value = assembly.AuthorName;
                            assemblyWorksheet.Cells[2, 4].Value = assembly.Version;

                            assemblyWorksheet.Cells[2, 5].Value = assembly.CreationDate;
                            assemblyWorksheet.Cells[2, 5].Style.Numberformat.Format = "dd.mm.yyyy";

                            assemblyWorksheet.Cells[2, 6].Value = assembly.LastCheckDate;
                            assemblyWorksheet.Cells[2, 6].Style.Numberformat.Format = "dd.mm.yyyy";

                            assemblyWorksheet.Cells[2, 7].Value = assembly.Description;
                            assemblyWorksheet.Cells[2, 8].Value = assembly.Information;

                            if (assembly.Photo != null)
                                assemblyWorksheet.Cells[2, 9].Value = Convert.ToBase64String(assembly.Photo);
                        }

                        assemblyWorksheet.Cells.AutoFitColumns();

                        var partsWorksheet = package.Workbook.Worksheets.Add("Детали");

                        partsWorksheet.Cells[1, 1].Value = "ID_Сборки";
                        partsWorksheet.Cells[1, 2].Value = "PartNumber";
                        partsWorksheet.Cells[1, 3].Value = "Наименование";
                        partsWorksheet.Cells[1, 4].Value = "Информация";
                        partsWorksheet.Cells[1, 5].Value = "Стандартная деталь";
                        partsWorksheet.Cells[1, 6].Value = "Количество";
                        partsWorksheet.Cells[1, 7].Value = "Автор";
                        partsWorksheet.Cells[1, 8].Value = "Проверено";
                        partsWorksheet.Cells[1, 9].Value = "Подразделение";
                        partsWorksheet.Cells[1, 10].Value = "Материал";
                        partsWorksheet.Cells[1, 11].Value = "Цена";
                        partsWorksheet.Cells[1, 12].Value = "Дата создания";
                        partsWorksheet.Cells[1, 13].Value = "Дата проверки";
                        partsWorksheet.Cells[1, 14].Value = "ГОСТ";
                        partsWorksheet.Cells[1, 15].Value = "Фото (base64)";

                        for (int i = 0; i < parts.Count; i++)
                        {
                            var part = parts[i];
                            int row = i + 2;

                            partsWorksheet.Cells[row, 1].Value = part.ID_Assembly;
                            partsWorksheet.Cells[row, 2].Value = part.PartNumber;
                            partsWorksheet.Cells[row, 3].Value = part.Name;
                            partsWorksheet.Cells[row, 4].Value = part.Information;
                            partsWorksheet.Cells[row, 5].Value = part.isStandartPart;
                            partsWorksheet.Cells[row, 6].Value = part.Count;
                            partsWorksheet.Cells[row, 7].Value = part.AuthorName;
                            partsWorksheet.Cells[row, 8].Value = part.CheckedBy;
                            partsWorksheet.Cells[row, 9].Value = part.Department;
                            partsWorksheet.Cells[row, 10].Value = part.Material;
                            partsWorksheet.Cells[row, 11].Value = part.Price;

                            partsWorksheet.Cells[row, 12].Value = part.CreationDate;
                            partsWorksheet.Cells[row, 12].Style.Numberformat.Format = "dd.mm.yyyy";

                            partsWorksheet.Cells[row, 13].Value = part.LastCheckDate;
                            partsWorksheet.Cells[row, 13].Style.Numberformat.Format = "dd.mm.yyyy";

                            partsWorksheet.Cells[row, 14].Value = part.GOST;

                            if (part.Photo != null)
                                partsWorksheet.Cells[row, 15].Value = Convert.ToBase64String(part.Photo);
                        }

                        partsWorksheet.Cells.AutoFitColumns();

                        package.SaveAs(new FileInfo(saveDialog.FileName));

                        MessageBox.Show("Экспорт успешно завершен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("DefaultDF");

                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(openDialog.FileName)))
                {
                    if (!package.Workbook.Worksheets.Any(ws => ws.Name == "Сборка") ||
                        !package.Workbook.Worksheets.Any(ws => ws.Name == "Детали"))
                    {
                        MessageBox.Show("Файл не содержит обязательные листы: \"Сборка\" и \"Детали\".", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var assemblyWorksheet = package.Workbook.Worksheets["Сборка"];
                    var partsWorksheet = package.Workbook.Worksheets["Детали"];

                    if (assemblyWorksheet.Dimension == null || assemblyWorksheet.Dimension.Rows < 2)
                    {
                        MessageBox.Show("Лист \"Сборка\" пуст или не содержит данных.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var assembly = new Types.Assemblies
                    {
                        ID = 0,
                        Name = assemblyWorksheet.Cells[2, 2]?.Text ?? string.Empty,
                        AuthorName = assemblyWorksheet.Cells[2, 3]?.Text ?? string.Empty,
                        Version = assemblyWorksheet.Cells[2, 4]?.Text ?? string.Empty,
                        CreationDate = ExcelUtils.ParseExcelDate(assemblyWorksheet.Cells[2, 5]),
                        LastCheckDate = ExcelUtils.ParseExcelDate(assemblyWorksheet.Cells[2, 6]),
                        Description = assemblyWorksheet.Cells[2, 7]?.Text ?? string.Empty,
                        Information = assemblyWorksheet.Cells[2, 8]?.Text ?? string.Empty
                    };

                    if (!string.IsNullOrEmpty(assemblyWorksheet.Cells[2, 9]?.Text))
                    {
                        try
                        {
                            assembly.Photo = Convert.FromBase64String(assemblyWorksheet.Cells[2, 9].Text);
                        }
                        catch
                        {
                            assembly.Photo = Array.Empty<byte>();
                        }
                    }
                    else
                    {
                        assembly.Photo = Array.Empty<byte>();
                    }

                    bool assemblyExists = SQLUtils.GetAssemblies()
                        .Any(a => a.Name == assembly.Name && a.Version == assembly.Version);

                    if (assemblyExists)
                    {
                        var result = MessageBox.Show(
                            $"Сборка с названием \"{assembly.Name}\" и версией \"{assembly.Version}\" уже существует.\n\n" +
                            "Хотите импортировать её как новую (с новым ID)?",
                            "Подтверждение импорта",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result != DialogResult.Yes)
                        {
                            return; 
                        }
     
                    }

                    if (!SQLUtils.InsertAssembly(assembly))
                    {
                        MessageBox.Show("Не удалось сохранить сборку в базу данных.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var parts = new List<Types.Parts>();

                    if (partsWorksheet.Dimension != null && partsWorksheet.Dimension.Rows >= 2)
                    {
                        for (int row = 2; row <= partsWorksheet.Dimension.Rows; row++)
                        {
                            var part = new Types.Parts
                            {
                                ID_Assembly = assembly.ID,
                                PartNumber = partsWorksheet.Cells[row, 2]?.Text ?? string.Empty,
                                Name = partsWorksheet.Cells[row, 3]?.Text ?? string.Empty,
                                Information = partsWorksheet.Cells[row, 4]?.Text ?? string.Empty,
                                isStandartPart = partsWorksheet.Cells[row, 5]?.Value as bool? ?? false,
                                Count = int.TryParse(partsWorksheet.Cells[row, 6]?.Text, out int count) ? count : 0,
                                AuthorName = partsWorksheet.Cells[row, 7]?.Text ?? string.Empty,
                                CheckedBy = partsWorksheet.Cells[row, 8]?.Text ?? string.Empty,
                                Department = partsWorksheet.Cells[row, 9]?.Text ?? string.Empty,
                                Material = partsWorksheet.Cells[row, 10]?.Text ?? string.Empty,
                                Price = int.TryParse(partsWorksheet.Cells[row, 11]?.Text, out int price) ? price : 0,
                                CreationDate = ExcelUtils.ParseExcelDate(partsWorksheet.Cells[row, 12]),
                                LastCheckDate = ExcelUtils.ParseExcelDate(partsWorksheet.Cells[row, 13]),
                                GOST = partsWorksheet.Cells[row, 14]?.Text ?? string.Empty
                            };

                            if (!string.IsNullOrEmpty(partsWorksheet.Cells[row, 15]?.Text))
                            {
                                try
                                {
                                    part.Photo = Convert.FromBase64String(partsWorksheet.Cells[row, 15].Text);
                                }
                                catch
                                {
                                    part.Photo = Array.Empty<byte>();
                                }
                            }
                            else
                            {
                                part.Photo = Array.Empty<byte>();
                            }

                            parts.Add(part);
                        }
                    }

                    bool allPartsInserted = true;
                    foreach (var part in parts)
                    {
                        if (!SQLUtils.InsertPart(part))
                        {
                            allPartsInserted = false;
                            break;
                        }
                    }

                    var currentList = (List<AssemblyItem>)ComboBox_SelectAssembly.DataSource;

                    var updatedList = new List<AssemblyItem>(currentList)
                    {
                        new AssemblyItem { Assembly = assembly }
                    };

                    ComboBox_SelectAssembly.DataSource = updatedList;
                    ComboBox_SelectAssembly.SelectedIndex = updatedList.Count - 1;

                    if (!allPartsInserted)
                    {
                        MessageBox.Show("Сборка добавлена, но не все детали были успешно сохранены.", "Частичный успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Импорт успешно завершён!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types.Assemblies assembly = new Types.Assemblies();
            System.Collections.Generic.List<Types.Parts> parts = new System.Collections.Generic.List<Types.Parts>();

            if (ComboBox_SelectAssembly != null && ComboBox_SelectAssembly.SelectedItem != null)
            {
                assembly = ((AssemblyItem)(ComboBox_SelectAssembly.SelectedItem)).Assembly;
                parts.AddRange(SQLUtils.GetParts(assembly.ID));
            }

            System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog();
            saveDialog.Filter = "Word documents (*.docx)|*.docx|All files (*.*)|*.*";
            saveDialog.FileName = $"{assembly.Name}_export.docx";

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (var wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(
                        saveDialog.FileName,
                        DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        var mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                        var body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                        DocumentFormat.OpenXml.Wordprocessing.Paragraph CreateParagraph(string text, bool bold = false, int fontSizeHalfPoints = 28)
                        {
                            var runProps = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                            if (bold)
                                runProps.Append(new DocumentFormat.OpenXml.Wordprocessing.Bold());
                            runProps.Append(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = fontSizeHalfPoints.ToString() });
                            return new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                new DocumentFormat.OpenXml.Wordprocessing.Run(runProps, new DocumentFormat.OpenXml.Wordprocessing.Text(text)));
                        }

                        body.Append(CreateParagraph("Сборка", bold: true, fontSizeHalfPoints: 36));

                        if (assembly.Photo != null && assembly.Photo.Length > 0)
                        {
                            string mimeType = "image/jpeg";
                            if (assembly.Photo.Length >= 4 &&
                                assembly.Photo[0] == 0x89 && assembly.Photo[1] == 0x50 &&
                                assembly.Photo[2] == 0x4E && assembly.Photo[3] == 0x47)
                            {
                                mimeType = "image/png";
                            }

                            var imagePart = mainPart.AddImagePart(mimeType);
                            using (var stream = new System.IO.MemoryStream(assembly.Photo))
                            {
                                imagePart.FeedData(stream);
                            }
                            string imageId = mainPart.GetIdOfPart(imagePart);

                            var drawing = new DocumentFormat.OpenXml.Wordprocessing.Drawing(
                                new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent() { Cx = 3000000L, Cy = 2000000L },
                                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties() { Id = (uint)1, Name = "Изображение" },
                                    new DocumentFormat.OpenXml.Drawing.Graphic(
                                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = (uint)0, Name = "Изображение" },
                                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                                    new DocumentFormat.OpenXml.Drawing.Blip() { Embed = imageId },
                                                    new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())),
                                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                                    new DocumentFormat.OpenXml.Drawing.Transform2D(
                                                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 3000000L, Cy = 2000000L })))
                                        )
                                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                )
                            );
                            body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                new DocumentFormat.OpenXml.Wordprocessing.Run(drawing)));
                        }

                        var assemblyFields = new[]
                        {
                    $"ID: {assembly.ID}",
                    $"Название: {assembly.Name}",
                    $"Автор: {assembly.AuthorName}",
                    $"Версия: {assembly.Version}",
                    $"Дата создания: {assembly.CreationDate:dd.MM.yyyy}",
                    $"Дата проверки: {assembly.LastCheckDate:dd.MM.yyyy}",
                    $"Описание: {assembly.Description}",
                    $"Информация: {assembly.Information}"
                };

                        foreach (var field in assemblyFields)
                        {
                            body.Append(CreateParagraph(field, fontSizeHalfPoints: 28));
                        }

                        body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                            new DocumentFormat.OpenXml.Wordprocessing.Run(
                                new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = DocumentFormat.OpenXml.Wordprocessing.BreakValues.Page })));

                        for (int i = 0; i < parts.Count; i++)
                        {
                            var part = parts[i];

                            body.Append(CreateParagraph($"Деталь: {part.Name}", bold: true, fontSizeHalfPoints: 32));

                            if (part.Photo != null && part.Photo.Length > 0)
                            {
                                string mimeType = "image/jpeg";
                                if (part.Photo.Length >= 4 &&
                                    part.Photo[0] == 0x89 && part.Photo[1] == 0x50 &&
                                    part.Photo[2] == 0x4E && part.Photo[3] == 0x47)
                                {
                                    mimeType = "image/png";
                                }

                                var imagePart = mainPart.AddImagePart(mimeType);
                                using (var stream = new System.IO.MemoryStream(part.Photo))
                                {
                                    imagePart.FeedData(stream);
                                }
                                string imageId = mainPart.GetIdOfPart(imagePart);

                                var drawing = new DocumentFormat.OpenXml.Wordprocessing.Drawing(
                                    new DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline(
                                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent() { Cx = 3000000L, Cy = 2000000L },
                                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                                        new DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties() { Id = (uint)1, Name = "Изображение" },
                                        new DocumentFormat.OpenXml.Drawing.Graphic(
                                            new DocumentFormat.OpenXml.Drawing.GraphicData(
                                                new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = (uint)0, Name = "Изображение" },
                                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                                    new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                                        new DocumentFormat.OpenXml.Drawing.Blip() { Embed = imageId },
                                                        new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())),
                                                    new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                                        new DocumentFormat.OpenXml.Drawing.Transform2D(
                                                            new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                                            new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 3000000L, Cy = 2000000L })))
                                            )
                                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                    )
                                );
                                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                    new DocumentFormat.OpenXml.Wordprocessing.Run(drawing)));
                            }

                            var partFields = new[]
                            {
                        $"ID сборки: {part.ID_Assembly}",
                        $"PartNumber: {part.PartNumber}",
                        $"Информация: {part.Information}",
                        $"Стандартная деталь: {(part.isStandartPart ? "Да" : "Нет")}",
                        $"Количество: {part.Count}",
                        $"Автор: {part.AuthorName}",
                        $"Проверено: {part.CheckedBy}",
                        $"Подразделение: {part.Department}",
                        $"Материал: {part.Material}",
                        $"Цена: {part.Price}",
                        $"Дата создания: {part.CreationDate:dd.MM.yyyy}",
                        $"Дата проверки: {part.LastCheckDate:dd.MM.yyyy}",
                        $"ГОСТ: {part.GOST}"
                    };

                            foreach (var field in partFields)
                            {
                                body.Append(CreateParagraph(field, fontSizeHalfPoints: 28));
                            }

                            if (i < parts.Count - 1)
                            {
                                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                    new DocumentFormat.OpenXml.Wordprocessing.Run(
                                        new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = DocumentFormat.OpenXml.Wordprocessing.BreakValues.Page })));
                            }
                        }

                        body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                            new DocumentFormat.OpenXml.Wordprocessing.Run(
                                new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = DocumentFormat.OpenXml.Wordprocessing.BreakValues.Page })));

                        body.Append(CreateParagraph("Сводная таблица деталей", bold: true, fontSizeHalfPoints: 32));

                        var table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                        table.Append(new DocumentFormat.OpenXml.Wordprocessing.TableProperties(
                            new DocumentFormat.OpenXml.Wordprocessing.TableWidth() { Width = "5000", Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Pct },
                            new DocumentFormat.OpenXml.Wordprocessing.TableLayout() { Type = DocumentFormat.OpenXml.Wordprocessing.TableLayoutValues.Fixed }
                        ));

                        var headers = new[]
                        {
                    new { Text = "PartNumber", WidthPercent = "10" },
                    new { Text = "Наименование", WidthPercent = "25" },
                    new { Text = "Кол-во", WidthPercent = "7" },
                    new { Text = "Материал", WidthPercent = "20" },
                    new { Text = "Цена", WidthPercent = "8" },
                    new { Text = "ГОСТ", WidthPercent = "20" },
                    new { Text = "Стандартная", WidthPercent = "10" }
                };

                        var headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                        foreach (var hdr in headers)
                        {
                            var cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                            var runProps = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                            runProps.Append(new DocumentFormat.OpenXml.Wordprocessing.Bold());
                            runProps.Append(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "28" });
                            cell.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                new DocumentFormat.OpenXml.Wordprocessing.Run(runProps, new DocumentFormat.OpenXml.Wordprocessing.Text(hdr.Text))));

                            cell.TableCellProperties = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                                new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth()
                                {
                                    Width = hdr.WidthPercent,
                                    Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Pct
                                });
                            headerRow.Append(cell);
                        }
                        table.Append(headerRow);

                        foreach (var part in parts)
                        {
                            var row = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                            var values = new[]
                            {
                        new { Value = part.PartNumber ?? "", WidthPercent = "10" },
                        new { Value = part.Name ?? "", WidthPercent = "25" },
                        new { Value = part.Count.ToString(), WidthPercent = "7" },
                        new { Value = part.Material ?? "", WidthPercent = "20" },
                        new { Value = part.Price.ToString(), WidthPercent = "8" },
                        new { Value = part.GOST ?? "", WidthPercent = "20" },
                        new { Value = part.isStandartPart ? "Да" : "Нет", WidthPercent = "10" }
                    };

                            foreach (var val in values)
                            {
                                var cell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                                var runProps = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                                runProps.Append(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "28" });
                                cell.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                                    new DocumentFormat.OpenXml.Wordprocessing.Run(runProps, new DocumentFormat.OpenXml.Wordprocessing.Text(val.Value ?? ""))));

                                cell.TableCellProperties = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                                    new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth()
                                    {
                                        Width = val.WidthPercent,
                                        Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Pct
                                    });
                                row.Append(cell);
                            }
                            table.Append(row);
                        }

                        body.Append(table);

                        mainPart.Document.Save();
                    }

                    System.Windows.Forms.MessageBox.Show("Экспорт в Word успешно завершен!", "Успех",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Ошибка при экспорте в Word: {ex.Message}", "Ошибка",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings AppSettings = new Form_Settings();
            AppSettings.Show();
        }
    }
    public class AssemblyItem
    {
        public Utils.Types.Assemblies Assembly;
        public string DisplayText => $"({Assembly.ID}) {Assembly.Name}";
    }
}

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

using AssemblyViewerV2.Utils;

namespace AssemblyViewerV2
{
    public partial class Form_DetailInfo : Form
    {

        static string Mode;
        static int Assembly_ID;
        static int Part_ID;
        static bool isPhotoSet = false;

        public Form_DetailInfo()
        {
            InitializeComponent();
        }
        public Form_DetailInfo(string Mode, Utils.Types.Parts PartStruct) : this()
        {
            if (Mode == "View")
            {
                TextBox_Name.ReadOnly = true;
                TextBox_PartNumber.ReadOnly = true;
                CheckBox_isStandart.Enabled = false;
                TextBox_Material.ReadOnly = true;
                TextBox_GOST.ReadOnly = true;
                TextBox_Count.ReadOnly = true;
                TextBox_Price.ReadOnly = true;
                TextBox_Author.ReadOnly = true;
                TextBox_Validator.ReadOnly = true;
                Date_Creation.Enabled = false;
                Date_Validation.Enabled = false;
                TextBox_Departament.ReadOnly = true;
                RichTextBox_Info.ReadOnly = true;
                Button_ApplyChanges.Enabled = false;
                Button_AskAI.Visible = false;
                PictureBox.Size = new Size(PictureBox.Size.Width, 318);
                Button_Cancel.Text = "Выйти";
            }
            if (Mode == "Add")
            {
                Form_DetailInfo.Mode = "Add";
                Assembly_ID = PartStruct.ID_Assembly;
                Button_ApplyChanges.Text = "Добавить деталь";
                Button_Cancel.Text = "Отмена";
                this.Text = "Добавление новой детали";
            }
            if (Mode == "Edit")
            {
                Form_DetailInfo.Mode = "Edit";
                Part_ID = PartStruct.ID;
                Assembly_ID = PartStruct.ID_Assembly;
                Button_ApplyChanges.Text = "Сохранить изменения";
                Button_Cancel.Text = "Отмена";
                this.Text = "Редактирование детали";
            }

            TextBox_Name.Text = PartStruct.Name ?? "";
            TextBox_PartNumber.Text = PartStruct.PartNumber ?? "";
            CheckBox_isStandart.Checked = PartStruct.isStandartPart;
            TextBox_Material.Text = PartStruct.Material ?? "";
            TextBox_GOST.Text = PartStruct.Information ?? "";
            TextBox_Count.Text = PartStruct.Count.ToString();
            TextBox_Price.Text = PartStruct.Price.ToString();
            TextBox_Author.Text = PartStruct.AuthorName ?? "";
            TextBox_Validator.Text = PartStruct.CheckedBy ?? "";
            Date_Creation.Value = PartStruct.CreationDate;
            Date_Validation.Value = PartStruct.LastCheckDate;
            TextBox_Departament.Text = PartStruct.Department ?? "";
            RichTextBox_Info.Text = PartStruct.Information ?? "";
            TextBox_GOST.Text = PartStruct.GOST ?? "";
            if (PartStruct.Photo != null && PartStruct.Photo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(PartStruct.Photo))
                {
                    PictureBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void Button_ApplyChanges_Click(object sender, EventArgs e)
        {
            Utils.Types.Parts part = new Utils.Types.Parts();
            try
            {
                //if (Form_DetailInfo.Mode == "Add")
                //{
                //    // Оставлю как память тупому решению
                //    // part.ID = Utils.SQLUtils.GetPartRandomID(Assembly_ID);
                //}
                if (Form_DetailInfo.Mode == "Edit")
                {
                    part.ID = Part_ID;
                }
                part.ID_Assembly = Assembly_ID;

                // Имя
                part.Name = TextBox_Name.Text;
                if (part.Name.Length == 0 || part.Name.Length > 100)
                    throw new ArgumentException("Имя должно быть от 1 до 100 символов.");

                // Номер детали
                part.PartNumber = TextBox_PartNumber.Text;
                if (part.PartNumber.Length > 50)
                    throw new ArgumentException("Номер детали должен быть не более 50 символов.");

                // Стандартная деталь (лучше заменить на CheckBox позже)
                part.isStandartPart = CheckBox_isStandart.Checked;

                // Материал
                part.Material = TextBox_Material.Text;
                if (string.IsNullOrEmpty(part.Material) || part.Material.Length > 100)
                    throw new ArgumentException("Материал должен быть от 1 до 100 символов.");

                // Информация
                part.Information = RichTextBox_Info.Text;
                if (part.Information.Length > 1000)
                    throw new ArgumentException("Информация не должна превышать 1000 символов.");

                // Количество и цена
                if (!int.TryParse(TextBox_Count.Text, out int count) || count < 0)
                    throw new ArgumentException("Неверное значение в поле: Количество");
                part.Count = count;

                if (!int.TryParse(TextBox_Price.Text, out int price) || price < 0)
                    throw new ArgumentException("Неверное значение в поле: Цена");
                part.Price = price;

                // Автор
                part.AuthorName = TextBox_Author.Text;
                if (string.IsNullOrEmpty(part.AuthorName) || part.AuthorName.Length > 100)
                    throw new ArgumentException("Имя автора должно быть от 1 до 100 символов.");

                // Проверяющий
                part.CheckedBy = TextBox_Validator.Text;
                if (part.CheckedBy.Length > 100)
                    throw new ArgumentException("Проверяющий должен быть не более 100 символов.");

                // Отдел
                part.Department = TextBox_Departament.Text;
                if (part.Department.Length > 250)
                    throw new ArgumentException("Отдел должен быть не более 250 символов.");

                // Дата создания
                part.CreationDate = Date_Creation.Value;

                // Дата последней проверки
                part.LastCheckDate = Date_Validation.Value;

                part.GOST = TextBox_GOST.Text ?? string.Empty;
                if (part.GOST.Length > 50)
                    throw new ArgumentException("ГОСТ должен быть не более 50 символов.");

                using (MemoryStream ms = new MemoryStream())
                {
                    part.Photo = PictureBox.Image != null
                        ? (ms.ToArray() ?? Array.Empty<byte>())
                        : Array.Empty<byte>();
                }

                // Вставка в БД

                if (Form_DetailInfo.Mode == "Add")
                {
                    if (Utils.SQLUtils.InsertPart(part))
                    {
                        MessageBox.Show("Успешное добавление детали!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении детали в базу данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Form_DetailInfo.Mode == "Edit") {
                    if (Utils.SQLUtils.UpdatePart(part))
                    {
                        MessageBox.Show("Успешное обновление детали!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновление детали в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_UpdateDate_Click(object sender, EventArgs e)
        {
            if (Form_DetailInfo.Mode == "Add" ||  Form_DetailInfo.Mode == "Edit")
            {
                Date_Validation.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Невозможно изменить дату в данном режиме!");
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (Form_DetailInfo.Mode == "Add" || Form_DetailInfo.Mode == "Edit")
            {
                // Создаем диалог выбора файла
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Устанавливаем фильтры для отображения только изображений
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы|*.*";

                // Открываем диалог выбора файла
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получаем путь к выбранному файлу
                        string filePath = openFileDialog.FileName;

                        // Загружаем изображение в PictureBox
                        PictureBox pictureBox = sender as PictureBox;
                        pictureBox.Image = Image.FromFile(filePath);
                        isPhotoSet = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                    }
                }
            }
        }

        private void Button_AskAI_click(object sender, EventArgs e)
        {
            byte[] Photo = null;
            if (isPhotoSet)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Photo = ms.ToArray() ?? Array.Empty<byte>();
                }
                if (Photo != null && Photo.Length > 0)
                {
                    Utils.Types.Parts Part = new Types.Parts();
                    Part = Utils.OpenAIUtils.ExtractPartFromPhoto(Photo);
                    if (Part != null)
                    {
                        TextBox_Name.Text = Part.Name ?? "";
                        TextBox_PartNumber.Text = Part.PartNumber ?? "";
                        CheckBox_isStandart.Checked = Part.isStandartPart;
                        TextBox_Material.Text = Part.Material ?? "";
                        TextBox_GOST.Text = Part.GOST ?? "";
                        TextBox_Count.Text = Part.Count.ToString();
                        TextBox_Price.Text = Part.Price.ToString();
                        TextBox_Author.Text = Part.AuthorName ?? "";
                        TextBox_Validator.Text = Part.CheckedBy ?? "";
                        Date_Creation.Value = Part.CreationDate;
                        Date_Validation.Value = Part.LastCheckDate;
                        TextBox_Departament.Text = Part.Department ?? "";
                        RichTextBox_Info.Text = Part.Information ?? "";
                        TextBox_GOST.Text = Part.GOST ?? "";
                        MessageBox.Show("Успешное извлечение!");
                    }
                    else
                    {
                        MessageBox.Show("Извлечение не удалось!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Добавьте фото, прежде чем использовать AI");
            }
        }
    }
}

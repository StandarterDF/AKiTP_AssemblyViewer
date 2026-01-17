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

namespace AssemblyViewerV2
{
    public partial class Form_AssemblyInfo : Form
    {
        public static string Mode;
        public static int Assembly_ID;
        public Form_AssemblyInfo()
        {
            InitializeComponent();
        }
        public Form_AssemblyInfo(string Mode, Utils.Types.Assemblies Assembly = null)
        {
            InitializeComponent();
            Form_AssemblyInfo.Mode = Mode;

            if (Mode == "Add")
            {
                Button_SaveData.Text = "Добавить сборку";
                this.Text = "Добавление новой сборки";
            }
            else
            {
                Assembly_ID = Assembly.ID;

                TextBox_Name.Text = Assembly.Name;
                TextBox_Version.Text = Assembly.Version;
                TextBox_AuthorName.Text = Assembly.AuthorName;
                DateTime_Creation.Value = Assembly.CreationDate;
                DateTime_Validation.Value = Assembly.LastCheckDate;
                RichTextBox_Info.Text = Assembly.Information;
                RichTextBox_Work.Text = Assembly.Description;

                if (Assembly.Photo != null && Assembly.Photo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(Assembly.Photo))
                    {
                        PictureBox.Image = Image.FromStream(ms);
                    }
                }

                if (Mode == "View")
                {
                    TextBox_Name.ReadOnly = true;
                    TextBox_Version.ReadOnly = true;
                    TextBox_AuthorName.ReadOnly = true;
                    DateTime_Creation.Enabled = false;
                    DateTime_Validation.Enabled = false;
                    RichTextBox_Info.ReadOnly = true;
                    RichTextBox_Work.ReadOnly = true;
                    Button_SaveData.Enabled = false;
                    Button_Cancel.Enabled = false;

                }
                if (Mode == "Edit")
                {
                    this.Text = "Редактирование сборки";
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (Form_AssemblyInfo.Mode == "View")
            {

            }
            if (Form_AssemblyInfo.Mode == "Add" || Form_AssemblyInfo.Mode == "Edit")
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
                    }
                    catch (Exception ex)
                    {
                        // Обработка ошибок (например, если файл поврежден)
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                    }
                }
            }
        }

        private void Button_UpdateData_Click(object sender, EventArgs e)
        {
            if (Form_AssemblyInfo.Mode == "View")
            {

            }
            if (Form_AssemblyInfo.Mode == "Edit" || Form_AssemblyInfo.Mode == "Add")
            {
                DateTime_Validation.Value = DateTime.Now;
            }
        }

        private void Button_SaveData_Click(object sender, EventArgs e)
        {
            Utils.Types.Assemblies Assembly = new Utils.Types.Assemblies();

            Assembly.ID = Assembly_ID;
            Assembly.Name = TextBox_Name.Text;
            Assembly.Version = TextBox_Version.Text;
            Assembly.AuthorName = TextBox_AuthorName.Text;
            Assembly.CreationDate = DateTime_Creation.Value;
            Assembly.LastCheckDate = DateTime_Validation.Value;
            Assembly.Information = RichTextBox_Info.Text;
            Assembly.Description = RichTextBox_Work.Text;

            using (MemoryStream ms = new MemoryStream())
            {
                PictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Assembly.Photo = ms.ToArray() ?? Array.Empty<byte>();
            }

            if (Form_AssemblyInfo.Mode == "Edit")
            {
                if (Utils.SQLUtils.UpdateAssembly(Assembly)) { MessageBox.Show("Успешное изменение данных в сборке!"); return; };
                MessageBox.Show("Неудачное изменение данных в сборке!"); return;
            }
            if (Form_AssemblyInfo.Mode == "Add")
            {
                if (Utils.SQLUtils.InsertAssembly(Assembly)) { MessageBox.Show("Успешное создание новой сборки!"); return; };
                MessageBox.Show("Ошибка при создании сборки!"); return;
            }
            this.Close();
        }
    }
}

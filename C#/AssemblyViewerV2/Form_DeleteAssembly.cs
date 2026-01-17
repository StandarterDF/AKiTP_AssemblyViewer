using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewerV2
{
    public partial class Form_DeleteAssembly : Form
    {
        public static string Password;
        public static Utils.Types.Assemblies Assembly;
        public static ComboBox ComboBox_Main;
        public static string GeneratePassword(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            Form_DeleteAssembly.Password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
            return Password;
        }
        public Form_DeleteAssembly()
        {
            InitializeComponent();
        }

        public Form_DeleteAssembly(ComboBox comboBox)
        {
            InitializeComponent();
            ComboBox_Main = comboBox;
            Form_DeleteAssembly.Assembly = ((AssemblyItem)ComboBox_Main.SelectedItem).Assembly;
            GeneratePassword(6);
            Label_Name.Text = $"Пароль: {Password}";
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_DeleteAssembly_Click(object sender, EventArgs e)
        {
            if (TextBox_DeleteConfirm.Text != Password)
            {
                MessageBox.Show("Пароль введен неверно!");
                return;
            }

            if (Utils.SQLUtils.DeleteAssembly(Assembly))
            {
                MessageBox.Show("Сборка успешно удалена!");

                var currentList = (List<AssemblyItem>)ComboBox_Main.DataSource;

                var itemToRemove = currentList.FirstOrDefault(item => item.Assembly.ID == Assembly.ID);

                if (itemToRemove != null)
                {
                    currentList.Remove(itemToRemove);

                    var updatedList = new List<AssemblyItem>(currentList);
                    ComboBox_Main.DataSource = updatedList;

                    if (updatedList.Count > 0)
                        ComboBox_Main.SelectedIndex = 0;
                    else
                        ComboBox_Main.SelectedItem = null;
                }

                this.Close();
                return;
            }

            MessageBox.Show("Ошибка при удалении сборки!");
        }
    }
}

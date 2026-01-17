using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace AssemblyViewerV2
{
    public partial class Form_Settings : Form
    {

        // TODO:
        /*
         * Настройки для:
         * OpenAI провайдер
         * SQL база данных
         * Тема?
         */

        public Form_Settings()
        {
            InitializeComponent();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            TextBox_SQLHost.Text = Program.AppSettings.DB.Host.ToString();
            TextBox_SQLPort.Text = Program.AppSettings.DB.Port.ToString();
            TextBox_SQLDatabase.Text = Program.AppSettings.DB.Database.ToString();
            TextBox_SQLUsername.Text = Program.AppSettings.DB.Username.ToString();
            TextBox_SQLPassword.Text = Program.AppSettings.DB.Password.ToString();

            TextBox_OpenAI_URL.Text = Program.AppSettings.OpenAI.OpenAI_URL.ToString();
            TextBox_OpenAI_Model.Text = Program.AppSettings.OpenAI.OpenAI_Model.ToString();
            TextBox_OpenAI_APIKey.Text = Program.AppSettings.OpenAI.OpenAI_APIKey.ToString();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // === Проверка порта ===
                if (!int.TryParse(TextBox_SQLPort.Text, out int port) || port <= 0 || port > 65535)
                {
                    MessageBox.Show("Порт должен быть целым числом в диапазоне от 1 до 65535.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // === Проверка URL ===
                string urlInput = TextBox_OpenAI_URL.Text.Trim();
                if (string.IsNullOrWhiteSpace(urlInput))
                {
                    MessageBox.Show("URL OpenAI не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Uri.IsWellFormedUriString(urlInput, UriKind.Absolute))
                {
                    MessageBox.Show("Указан некорректный URL для OpenAI.\nПример: https://text.pollinations.ai/openai", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // === Обновляем настройки БД ===
                Program.AppSettings.DB.Host = TextBox_SQLHost.Text;
                Program.AppSettings.DB.Port = port; // уже проверено
                Program.AppSettings.DB.Database = TextBox_SQLDatabase.Text;
                Program.AppSettings.DB.Username = TextBox_SQLUsername.Text;
                Program.AppSettings.DB.Password = TextBox_SQLPassword.Text;

                // === Обновляем настройки OpenAI ===
                Program.AppSettings.OpenAI.OpenAI_URL = urlInput;
                Program.AppSettings.OpenAI.OpenAI_Model = TextBox_OpenAI_Model.Text;
                Program.AppSettings.OpenAI.OpenAI_APIKey = TextBox_OpenAI_APIKey.Text;

                // === Сохраняем в файл ===
                Program.AppSettings.Save();

                MessageBox.Show("Настройки успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить настройки:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_TestDB_Click(object sender, EventArgs e)
        {
            try
            {
                // Берём данные из текстовых полей (или можно из Program.AppSettings.DB — см. примечание ниже)
                string host = TextBox_SQLHost.Text.Trim();
                string portText = TextBox_SQLPort.Text.Trim();
                string database = TextBox_SQLDatabase.Text.Trim();
                string username = TextBox_SQLUsername.Text.Trim();
                string password = TextBox_SQLPassword.Text;

                // Валидация порта
                if (!int.TryParse(portText, out int port) || port <= 0 || port > 65535)
                {
                    MessageBox.Show("Некорректный порт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Формируем строку подключения
                var connString = $"Host={host};Port={port};Database={database};Username={username};Password={password};Timeout=5;CommandTimeout=5";

                using (var connection = new NpgsqlConnection(connString))
                {
                    connection.Open(); // Пытаемся подключиться
                    MessageBox.Show("Подключение к базе данных успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к PostgreSQL:\n{ex.Message}", "Ошибка PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

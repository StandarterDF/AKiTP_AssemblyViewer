using Newtonsoft.Json;
using System;
using System.IO;

namespace AssemblyViewerV2
{
    public class Settings
    {
        private const string SettingsFilePath = "settings.json";

        public class DataBase
        {
            public string Host { get; set; } = "localhost";
            public int Port { get; set; } = 5432;
            public string Database { get; set; } = "AKITP_Univercity_Work";
            public string Username { get; set; } = "postgres";
            public string Password { get; set; } = "16689527";

            [JsonIgnore]
            public string ConnectionString =>
                $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
        }

        public class OpenAISettings
        {
            public string OpenAI_URL { get; set; } = "https://gen.pollinations.ai/v1/chat/completions";
            public string OpenAI_Model { get; set; } = "gemini-fast";
            public string OpenAI_APIKey { get; set; } = "sk_EAMqBTaWynI2c60DzyrRzVaY9gs7VyOx";
        }

        public DataBase DB { get; set; } = new DataBase();
        public OpenAISettings OpenAI { get; set; } = new OpenAISettings();

        public static Settings LoadOrCreate()
        {
            if (!File.Exists(SettingsFilePath))
            {
                var settings = new Settings();
                settings.Save();
                return settings;
            }

            try
            {
                var json = File.ReadAllText(SettingsFilePath);
                return JsonConvert.DeserializeObject<Settings>(json) ?? new Settings();
            }
            catch (Exception)
            {
                var settings = new Settings();
                settings.Save();
                return settings;
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, json);
        }
    }
}
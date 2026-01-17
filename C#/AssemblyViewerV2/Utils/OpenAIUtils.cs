using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AssemblyViewerV2.Utils.Types;

namespace AssemblyViewerV2.Utils
{
    public class OpenAIUtils
    {
        public static string apiUrl = Program.AppSettings.OpenAI.OpenAI_URL;
        public static string modelName = Program.AppSettings.OpenAI.OpenAI_Model;
        public static string apiKey = Program.AppSettings.OpenAI.OpenAI_APIKey;

        private static readonly HttpClient httpClient = new HttpClient();

        public static string SendMessage(string Text, byte[] Photo = null)
        {
            try
            {
                object content;
                if (Photo != null)
                {
                    string base64Image = Convert.ToBase64String(Photo);
                    content = new object[]
                    {
                        new { type = "text", text = Text },
                        new { type = "image_url", image_url = new { url = $"data:image/jpeg;base64,{base64Image}" } }
                    };
                }
                else
                {
                    content = Text;
                }

                var request = new
                {
                    model = modelName,
                    messages = new[]
                    {
                        new { role = "user", content = content }
                    },
                    stream = false
                };

                string json = JsonSerializer.Serialize(request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                }

                using (var response = httpClient.PostAsync(apiUrl, httpContent).GetAwaiter().GetResult())
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    using (var doc = JsonDocument.Parse(responseBody))
                    {
                        var contentResponse = doc.RootElement
                            .GetProperty("choices")[0]
                            .GetProperty("message")
                            .GetProperty("content")
                            .GetString();
                        return contentResponse ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        public static Utils.Types.Parts ExtractPartFromPhoto(byte[] photo)
        {
            try
            {
                if (photo == null || photo.Length == 0)
                    return null;

                string base64Image = Convert.ToBase64String(photo);

                string prompt = @"Проанализируй изображение детали или чертежа и верни JSON-объект со следующими полями:
                                    - PartNumber (string)
                                    - Name (string)
                                    - Information (string)
                                    - isStandartPart (boolean)
                                    - Count (integer)
                                    - AuthorName (string)
                                    - CheckedBy (string)
                                    - Department (string)
                                    - Material (string)
                                    - Price (integer)
                                    - GOST (string)
                                    - CreationDate (string, формат yyyy-MM-dd)
                                    - LastCheckDate (string, формат yyyy-MM-dd)

                                    Если поле неизвестно — используй null.
                                    Верни ТОЛЬКО валидный JSON.";

                var request = new
                {
                    model = modelName,
                    messages = new[]
                    {
                        new
                        {
                            role = "user",
                            content = new object[]
                            {
                                new { type = "text", text = prompt },
                                new { type = "image_url", image_url = new { url = $"data:image/jpeg;base64,{base64Image}" } }
                            }
                        }
                    },
                    stream = false
                };

                string jsonRequest = JsonSerializer.Serialize(request);
                var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                }

                using (var response = httpClient.PostAsync(apiUrl, httpContent).GetAwaiter().GetResult())
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    using (var doc = JsonDocument.Parse(responseBody))
                    {
                        string contentText = doc.RootElement
                            .GetProperty("choices")[0]
                            .GetProperty("message")
                            .GetProperty("content")
                            .GetString();

                        if (string.IsNullOrWhiteSpace(contentText))
                            return null;

                        contentText = contentText.Trim();
                        if (contentText.StartsWith("```json", StringComparison.OrdinalIgnoreCase))
                            contentText = contentText.Substring(7);
                        else if (contentText.StartsWith("```", StringComparison.OrdinalIgnoreCase))
                            contentText = contentText.Substring(3);

                        if (contentText.EndsWith("```"))
                            contentText = contentText.Substring(0, contentText.Length - 3);

                        contentText = contentText.Trim();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            AllowTrailingCommas = true,
                            ReadCommentHandling = JsonCommentHandling.Skip,
                            Converters =
                            {
                                new FuzzyDateTimeConverter(),
                                new FuzzyIntConverter(),
                                new FuzzyStringConverter(),
                                new FuzzyBoolConverter()
                            }
                        };

                        var part = JsonSerializer.Deserialize<Utils.Types.Parts>(contentText, options);

                        if (part == null)
                            return null;

                        part.Photo = photo;

                        if (part.CreationDate == DateTime.MinValue) part.CreationDate = DateTime.Now;
                        if (part.LastCheckDate == DateTime.MinValue) part.LastCheckDate = DateTime.Now;

                        return part;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка извлечения детали: " + ex.Message);
                return null;
            }
        }

        #region Converters

        public class FuzzyDateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return DateTime.MinValue;

                if (reader.TokenType == JsonTokenType.String)
                {
                    string dateString = reader.GetString();
                    if (string.IsNullOrWhiteSpace(dateString)) return DateTime.MinValue;

                    if (DateTime.TryParse(dateString, out DateTime result)) return result;

                    string[] formats = { "dd.MM.yyyy", "yyyy.MM.dd", "dd-MM-yyyy", "yyyy/MM/dd" };
                    if (DateTime.TryParseExact(dateString, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result)) return result;
                }
                return DateTime.MinValue;
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
            }
        }

        public class FuzzyIntConverter : JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return 0;

                if (reader.TokenType == JsonTokenType.String)
                {
                    string text = reader.GetString();
                    if (int.TryParse(text, out int val)) return val;
                    return 0;
                }

                if (reader.TokenType == JsonTokenType.Number)
                    return reader.GetInt32();

                return 0;
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }

        public class FuzzyStringConverter : JsonConverter<string>
        {
            public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return string.Empty;

                if (reader.TokenType == JsonTokenType.String) return reader.GetString();

                if (reader.TokenType == JsonTokenType.Number) return reader.GetDouble().ToString();

                if (reader.TokenType == JsonTokenType.True) return "true";
                if (reader.TokenType == JsonTokenType.False) return "false";

                return string.Empty;
            }

            public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value ?? string.Empty);
            }
        }

        public class FuzzyBoolConverter : JsonConverter<bool>
        {
            public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.True) return true;
                if (reader.TokenType == JsonTokenType.False) return false;
                if (reader.TokenType == JsonTokenType.Null) return false;

                if (reader.TokenType == JsonTokenType.String)
                {
                    string val = reader.GetString()?.ToLower().Trim();
                    return val == "true" || val == "1" || val == "yes";
                }

                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32() > 0;
                }

                return false;
            }

            public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            {
                writer.WriteBooleanValue(value);
            }
        }

        #endregion
    }
}
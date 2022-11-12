using System.Text.Json;

namespace CustomAttribute
{
    public class FileProvider : IProvider
    {
        private readonly Dictionary<string, string> _appJsonFile;
        private const string JsonFilePath = "app_file.json";

        public FileProvider()
        {
            _appJsonFile = GetAppFile();
        }

        private Dictionary<string, string> GetAppFile()
        {
            var jsonFile = File.ReadAllText(JsonFilePath);
            Dictionary<string, string> jsonData = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonFile);

            return jsonData;
        }

        public string GetValue(string key)
        {
            return _appJsonFile[key];
        }


        public void SetValue(string key, string value)
        {
            _appJsonFile[key] = value;
        }

        public void SaveChanges(string key, string value)
        {
            var jsonObject = JsonSerializer.Serialize<Dictionary<string, string>>(_appJsonFile);
            File.WriteAllText(JsonFilePath,jsonObject);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Model;

namespace Storage
{
    public class JsonFileProvider<T> : IProvider<T> where T : Document
    {
        private const string FileType = ".json";
        private const string ModelDll = "Model.dll"; //Dll with derived types

        public void SaveItem(T item)
        {
            var typeName = item.GetType().FullName;
            var fileName = CreateFileName(typeName, item.Id).ToLower();

            var jsonString = JsonSerializer.Serialize(item, item.GetType());

            File.WriteAllText(fileName, jsonString);
        }

        public List<T> SearchItemById(int id)
        {
            var directoryFiles = GetDirectoryFiles(FileType);

            var result = new List<T>();

            foreach (var stringPath in directoryFiles)
            {
                var fullFileName = Path.GetFileNameWithoutExtension(stringPath).Split('_', '#');
                if (fullFileName.Contains(id.ToString()))
                {
                    var fileId = Convert.ToInt32(fullFileName.LastOrDefault());

                    TextInfo txtInfo = new CultureInfo("en-en", false).TextInfo;
                    var typeName = txtInfo.ToTitleCase(fullFileName.FirstOrDefault());

                    if (id == fileId && typeName != null)
                    {
                        var itemType = GetItemType(typeName);

                        var jsonString = File.ReadAllText(stringPath);
                        var doc = JsonSerializer.Deserialize(jsonString, itemType);

                        result.Add((T)doc);
                    }
                }
            }

            return result;
        }

        private Type GetItemType(string typeName)
        {
            var modelDll = GetDirectoryFiles(ModelDll).FirstOrDefault();
            var assembly = Assembly.LoadFrom(modelDll);

            foreach (var type in assembly.GetTypes())
            {
                if (typeName == type.FullName)
                {
                    return type.GetTypeInfo().AsType();
                }
            }

            return null;
        }

        private static List<string> GetDirectoryFiles(string fileType)
        {
            var root = Environment.CurrentDirectory;
            var directoryFiles = Directory.GetFiles(root, string.Concat("*", fileType)).ToList();

            return directoryFiles;
        }

        private string CreateFileName(string typeName, int itemId)
        {
            var sb = new StringBuilder();
            sb.Append(typeName);
            sb.Append("_#");
            sb.Append(itemId);
            sb.Append(FileType);

            return sb.ToString();
        }
    }
}

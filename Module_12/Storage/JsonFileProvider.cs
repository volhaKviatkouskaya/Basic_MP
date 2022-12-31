using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Storage
{
    public class JsonFileProvider<T> : IProvider<T>
    {
        private const string FileType = ".json";
        private const string ModelDll = "Model.dll";

        public void SaveItem(T item)
        {
            var typeName = item.GetType().FullName;
            var propertyInfo = item.GetType().GetProperty("Id");
            var idValue = (int)propertyInfo.GetValue(item);
            var fileName = CreateFileName(typeName, idValue);

            var jsonString = JsonSerializer.Serialize(item, item.GetType());

            File.WriteAllText(fileName, jsonString);
        }

        public List<T> SearchItemById(int id)
        {
            var directoryFiles = GetDirectoryFiles(FileType);
            var filesList = directoryFiles.Where(file => file.Contains(id.ToString())).ToList();

            var result = new List<T>();

            foreach (var stringPath in filesList)
            {
                var name = Path.GetFileName(stringPath).Split('_').FirstOrDefault();
                var itemType = GetItemType(name);

                if (itemType != null)
                {
                    var jsonString = File.ReadAllText(stringPath);
                    var doc = JsonSerializer.Deserialize(jsonString, itemType);

                    result.Add((T)doc);
                }
            }

            return result;
        }

        public Type GetItemType(string typeName)
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

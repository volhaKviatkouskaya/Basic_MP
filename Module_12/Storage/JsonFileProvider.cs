using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using Model;

namespace Storage
{
    public class JsonFileProvider : IProvider
    {
        private const string FileType = ".json";
        private const string ModelDll = "Model.dll";

        public void SaveItem(DocumentBase doc)
        {
            var typeName = doc.GetType().FullName;
            var fileName = CreateFileName(typeName, doc.Id);
            var jsonString = JsonSerializer.Serialize(doc);

            File.WriteAllText(fileName, jsonString);
        }

        public List<DocumentBase> SearchItemById(int id)
        {
            var directoryFiles = GetDirectoryFiles(FileType);
            var filesList = directoryFiles.Where(file => file.Contains(id.ToString())).ToList();

            var result = new List<DocumentBase>();

            foreach (var stringPath in filesList)
            {
                var name = Path.GetFileName(stringPath).Split('_').FirstOrDefault();
                ////TODO determine type and create it
                var itemType = GetItemType(name);

                var jsonString = File.ReadAllText(stringPath);

                var doc = JsonSerializer.Deserialize<DocumentBase>(jsonString);
                result.Add(doc);
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
                    return type;
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using Model;

namespace Storage
{
    public class JsonFileProvider : IProvider
    {
        private const string fileType = ".json";
        public void SaveItem(DocumentBase doc)
        {
            var typeName = doc.GetType().Name;
            var fileName = CreateFileName(typeName, doc.Id);
            var jsonString = JsonSerializer.Serialize(doc);

            File.WriteAllText(fileName, jsonString);
        }

        public List<DocumentBase> SearchItemById(int id)
        {
            var result = new List<DocumentBase>();

            ////TODO: find pass to FILESSTORAGE folder(Save into/read from this folder)
            /// 
            var directoryInfo = new DirectoryInfo(@"Debug\");
            var files = directoryInfo.GetFiles(fileType);

            foreach (var file in files)
            {

            }

            return result;
        }

        private string CreateFileName(string typeName, int itemId)
        {
            var sb = new StringBuilder();
            sb.Append(typeName);
            sb.Append("_#");
            sb.Append(itemId);
            sb.Append(fileType);

            return sb.ToString();
        }
    }
}

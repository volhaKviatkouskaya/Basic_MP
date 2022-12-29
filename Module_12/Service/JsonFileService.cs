using System;
using System.Collections.Generic;
using Model;
using Storage;

namespace Service
{
    public class JsonFileService : IService
    {
        public IProvider _storageProvider;
        public JsonFileService() => _storageProvider = new JsonFileProvider();

        public void SaveItem(DocumentBase doc)
        {
            _storageProvider.SaveItem(doc);
        }

        public List<DocumentBase> SearchItemById(int id)
        {
            return _storageProvider.SearchItemById(id);
        }
    }
}

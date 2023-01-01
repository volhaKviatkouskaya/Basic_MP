using System.Collections.Generic;
using Model;
using Storage;

namespace Service
{
    public class FileService<T> : IService<T> where T : Document
    {
        private IProvider<T> _storageProvider;
        public FileService() => _storageProvider = new JsonFileProvider<T>();

        public void SaveItem(T doc)
        {
            _storageProvider.SaveItem(doc);
        }

        public List<T> SearchItemById(int id)
        {
            return _storageProvider.SearchItemById(id);
        }
    }
}

using System.Collections.Generic;
using Storage;

namespace Service
{
    public class JsonFileService<T> : IService<T>
    {
        public IProvider<T> _storageProvider;
        public JsonFileService() => _storageProvider = new JsonFileProvider<T>();

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

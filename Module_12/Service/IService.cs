using System.Collections.Generic;

namespace Service
{
    public interface IService<T>
    {
        public void SaveItem(T document);
        public List<T> SearchItemById(int itemId);
    }
}

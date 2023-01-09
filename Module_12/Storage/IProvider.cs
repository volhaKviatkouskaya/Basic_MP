using System.Collections.Generic;

namespace Storage
{
    public interface IProvider<T>
    {
        public void SaveItem(T item);
        public List<T> SearchItemById(int id);
    }
}

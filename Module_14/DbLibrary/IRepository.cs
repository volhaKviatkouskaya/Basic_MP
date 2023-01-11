using System.Collections.Generic;

namespace DbLibrary
{
    public interface IRepository<T> where T : class
    {
        void InsertItem(T item);
        T SelectItemById(int itemId);
        List<T> SelectAll();
        void UpdateItem(T item);
        void DeleteItem(int itemId);
    }
}

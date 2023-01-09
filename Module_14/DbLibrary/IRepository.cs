using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary
{
    public interface IRepository<T> where T : class
    {
        void CreateItem(T product);
        T SelectItemById(int productId);
        List<T> SelectAll();
        void UpdateItem(T product);
        void DeleteItem(int productId);
    }
}

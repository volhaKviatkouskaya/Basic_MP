using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary
{
    public class OrderRepository<T> : IRepository<T> where T : OrderEntity
    {
        public void CreateItem(T product) => throw new NotImplementedException();
        public void DeleteItem(int productId) => throw new NotImplementedException();
        public List<T> SelectAll() => throw new NotImplementedException();
        public T SelectItemById(int productId) => throw new NotImplementedException();
        public void UpdateItem(T product) => throw new NotImplementedException();
    }
}

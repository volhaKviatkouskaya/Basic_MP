using DbLibrary;
using System;

namespace OrdersApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var product = new ProductEntity()
            {
                Name = "Green apple",
                Description = "Green apples",
                Weight = 50,
                Height = 1,
                Length = 0,
                Width = 0
            };

            var repo = new ProductRepository<ProductEntity>();
            repo.InsertItem(product);
            repo.UpdateItem(new ProductEntity()
            {
                ProductId = 33,
                Name = "All green apple",
                Description = "Green apples",
                Weight = 20,
                Height = 10,
                Length = 1,
                Width = 1
            });

            var result = repo.SelectItemById(33);
            var all = repo.SelectAll();
            repo.DeleteItem(33);
            */
            
            var order = new OrderEntity()
            {
                Status = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var repo = new OrderRepository<OrderEntity>();
            repo.InsertItem(order);
            repo.UpdateItem(new OrderEntity()
            {
                OrderId = 5,
                Status = 2,
                UpdatedDate = DateTime.Today,
                ProductId = 3
            });

            var result = repo.SelectItemById(1);
            var all = repo.SelectAll();
            repo.DeleteItem(1);
            
        }
    }
}

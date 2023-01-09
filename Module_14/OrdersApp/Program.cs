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
                Height = 1,
                Weight = 50,
                Length = 0,
                Width = 0
            };

            var repo = new ProductRepository<ProductEntity>();
            repo.CreateItem(product);
            repo.UpdateItem(new ProductEntity()
            {
                ProductId = 5,
                Name = "Green apple",
                Description = "Green and red apples",
                Height = 10,
                Weight = 20,
                Length = 1,
                Width = 1
            });

            var result = repo.SelectItemById(6);
            var all = repo.SelectAll();
            repo.DeleteItem(6);
            */
            var order = new OrderEntity()
            {
                Status = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var repo = new OrderRepository<OrderEntity>();
            repo.CreateItem(order);
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

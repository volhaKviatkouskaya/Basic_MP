using DbLibrary;

namespace OrdersApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var product = new ProductEntity()
            {
                Name = "Green apple",
                Description = "Green apples",
                Height = 1,
                Weight = 50,
                Length = 0,
                Width = 0
            };

            DbAccess.CreateProduct(product);
            DbAccess.UpdateProduct(new ProductEntity()
            {
                ProductId = 5,
                Name = "Green apple",
                Description = "Green and red apples",
                Height = 10,
                Weight = 20,
                Length = 1,
                Width = 1
            });

            var result = DbAccess.SelectProduct(6);
            var all = DbAccess.SelectAllProducts();
            DbAccess.DeleteProduct(6);
        }
    }
}

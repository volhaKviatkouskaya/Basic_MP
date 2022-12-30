using System;
using Model;
using Service;

namespace Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            DocumentBase doc = new()
            {
                Id = 100,
                Title = "MyFirstDoc",
                Author = "Volha",
                DatePublished = DateTime.Now
            };

            Book book = new()
            {
                Id = 1001,
                Title = "MyFirstDoc",
                Author = "Volha",
                DatePublished = DateTime.Now,
                ExpirationDate = DateTime.Today
            };

            IService service = new JsonFileService();
            service.SaveItem(doc);
            service.SaveItem(book);

            var doc2 = service.SearchItemById(1001);
        }
    }
}

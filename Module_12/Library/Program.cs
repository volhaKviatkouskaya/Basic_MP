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
                Id = 0,
                Title = "DocumentBase",
                Author = "Volha",
                DatePublished = DateTime.Now
            };

            IService service = new JsonFileService();
            service.SaveItem(doc);

            var doc2 = service.SearchItemById(0);
        }
    }
}

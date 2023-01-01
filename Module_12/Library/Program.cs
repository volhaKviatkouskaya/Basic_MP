using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Library
{
    public class Program
    {
        private static void ShowItems(List<Document> itemsList)
        {
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Book book = new()
            {
                Id = 1,
                ISBN = 1000000000000,
                Title = "My first Book",
                Authors = new List<string>() { "Volha" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "Some publisher"
            };

            LocalizedBook localized = new()
            {
                Id = 10,
                ISBN = 1000000000001,
                Title = "My first Localized Book",
                Authors = new List<string>() { "Volha", "Toma" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "Some publisher",
                CountryOfLocalization = "Poland",
                LocalPublisher = "Poland publisher"
            };

            Patent patent = new()
            {
                Id = 101,
                Title = "My first patent",
                Authors = new List<string>() { "Volha" },
                DatePublished = DateTime.Today,
                ExpirationDate = DateTime.Today
            };

            Magazine magazine = new()
            {
                Id = 1010,
                Title = "My first magazine",
                DatePublished = DateTime.Now,
                ReleaseNumber = "14.100.1",
                Publisher = "EPAM publisher"
            };

            IService<Document> service = new FileService<Document>();

            service.SaveItem(book);
            service.SaveItem(localized);
            service.SaveItem(patent);
            service.SaveItem(magazine);

            var doc2 = service.SearchItemById(1);

            ShowItems(doc2);
        }
    }
}

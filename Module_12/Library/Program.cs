using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Library
{
    public class Program
    {
        public static void ShowItems(List<DocumentBase> itemsList)
        {
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            DocumentBase doc = new()
            {
                Id = 100,
                Title = "My first document",
                Author = new List<string>() { "Volha", "Toma" },
                DatePublished = DateTime.Now
            };

            Book book = new()
            {
                Id = 1001,
                ISBN = 1000000000000,
                Title = "My first Book",
                Author = new List<string>() { "Volha" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "Some publisher"
            };

            LocalizedBook localized = new()
            {
                Id = 100111,
                ISBN = 1000000000001,
                Title = "My first Localized Book",
                Author = new List<string>() { "Volha" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "Some publisher",
                CountryOfLocalization = "Poland",
                LocalPublisher = "Poland publisher"
            };

            Patent patent = new()
            {
                Id = 10011,
                Title = "My first patent",
                Author = new List<string>() { "Volha" },
                DatePublished = DateTime.Today,
                ExpirationDate = DateTime.Today
            };

            Magazine magazine = new()
            {
                Id = 11100,
                Title = "My first magazine",
                Author = new List<string>() { "Volha", "Toma" },
                DatePublished = DateTime.Now,
                ReleaseNumber = "14.100.1",
                Publisher = "EPAM publisher"
            };

            IService<DocumentBase> service = new JsonFileService<DocumentBase>();

            service.SaveItem(doc);
            service.SaveItem(book);
            service.SaveItem(localized);
            service.SaveItem(patent);
            service.SaveItem(magazine);

            var doc2 = service.SearchItemById(100);

            ShowItems(doc2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LocalizedBook : Book
    {
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");

            var authors = string.Empty;
            foreach (var item in Author)
            {
                authors = string.Concat(authors, $"{item} ");
            }

            sb.AppendLine($"Author: {authors}");
            sb.AppendLine($"DatePublished: {DatePublished}");
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"NumberOfPages: {NumberOfPages}");
            sb.AppendLine($"Publisher: {Publisher}");
            sb.AppendLine($"CountryOfLocalization: {CountryOfLocalization}");

            return sb.ToString();
        }
    }
}

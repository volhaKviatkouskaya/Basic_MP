using System;
using System.Globalization;
using System.Text;

namespace Model
{
    public class Book : DocumentBase
    {
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }

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
            sb.AppendLine($"NumberOfPages: {NumberOfPages}");
            sb.AppendLine($"Publisher: {Publisher}");

            return sb.ToString();
        }
    }
}

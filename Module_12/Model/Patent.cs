using System;
using System.Text;

namespace Model
{
    public class Patent : Book
    {
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");

            var authors = string.Empty;
            foreach (var item in Authors)
            {
                authors = string.Concat(authors, $"{item} ");
            }

            sb.AppendLine($"Authors: {authors}");
            sb.AppendLine($"Date Published: {DatePublished}");
            sb.AppendLine($"Expiration Date: {ExpirationDate}");

            return sb.ToString();
        }
    }
}

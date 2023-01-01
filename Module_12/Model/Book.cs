using System;
using System.Text;

namespace Model
{
    public class Book : BookBase
    {
        public DateTime DatePublished { get; set; }
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
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Number Of Pages: {NumberOfPages}");
            sb.AppendLine($"Publisher: {Publisher}");

            return sb.ToString();
        }
    }
}

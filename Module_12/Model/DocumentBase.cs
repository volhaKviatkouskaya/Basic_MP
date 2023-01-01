using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DocumentBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Author { get; set; }
        public DateTime DatePublished { get; set; }

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

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patent : DocumentBase
    {
        public DateTime ExpirationDate { get; set; }

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
            sb.AppendLine($"ExpirationDate: {ExpirationDate}");

            return sb.ToString();
        }
    }
}

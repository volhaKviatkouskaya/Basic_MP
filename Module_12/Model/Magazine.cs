using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Magazine : DocumentBase
    {
        public string ReleaseNumber { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Publisher: {Publisher}");
            sb.AppendLine($"ReleaseNumber: {ReleaseNumber}");
            sb.AppendLine($"DatePublished: {DatePublished}");

            return sb.ToString();
        }
    }
}

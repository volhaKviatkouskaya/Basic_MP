using System;
using System.Text;

namespace DbLibrary
{
    public class OrderEntity
    {
        public int OrderId { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ProductId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Order:");
            sb.AppendLine($"Id: {OrderId}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Created date: {CreatedDate}");
            sb.AppendLine($"Updated date: {UpdatedDate}");
            sb.AppendLine($"Product id: {ProductId}");

            return sb.ToString();
        }
    }
}

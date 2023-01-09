using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbLibrary
{
    public class OrderEntity
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}

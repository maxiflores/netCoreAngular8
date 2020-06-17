using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Dto
{
    public class OrderDetailDto
    {
        public int IdOrder { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}

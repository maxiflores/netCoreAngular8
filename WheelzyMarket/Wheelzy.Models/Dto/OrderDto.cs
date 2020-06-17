using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public double Price { get; set; }
        public DateTime DateOrder { get; set; }
        public int Quantity { get; set; }
    }
}

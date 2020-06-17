using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Entities
{
    public class OrderHistory
    {
        public DateTime DateOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

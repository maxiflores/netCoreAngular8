using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Entities
{
    public class OrderDetail
    {
        #region Properties
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        #endregion

        #region Relations
        public Product Product { get; set; }
        public Order Order { get; set; }
        #endregion
    }
}

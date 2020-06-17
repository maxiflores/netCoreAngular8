using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Entities
{
    public class Product
    {
        #region Properties
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        #endregion

        #region Relations
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        #endregion

    }
}
